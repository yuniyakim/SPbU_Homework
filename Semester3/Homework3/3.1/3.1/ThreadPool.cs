using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    /// <summary>
    /// Thread pool
    /// </summary>
    public class ThreadPool
    {
        private int amountOfWorking;
        private readonly Thread[] threads;
        private readonly ConcurrentQueue<Action> tasks = new ConcurrentQueue<Action>();
        private static Object lockObject = new Object();
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private readonly AutoResetEvent newTaskSignal = new AutoResetEvent(false);
        private readonly AutoResetEvent shutdownSignal = new AutoResetEvent(false);

        /// <summary>
        /// Defines whether or not thread pool is closed
        /// </summary>
        public bool IsClosed { get => cts.IsCancellationRequested; }

        /// <summary>
        /// Thread pool's constructor
        /// </summary>
        /// <param name="amount">Amount of threads</param>
        public ThreadPool(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid argument");
            }

            amountOfWorking = amount;
            threads = new Thread[amount];
            for (int i = 0; i < amount; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        if (tasks.TryDequeue(out Action action))
                        {
                            action.Invoke();
                        }
                        else
                        {
                            newTaskSignal.WaitOne();
                        }
                    }
                    Interlocked.Decrement(ref amountOfWorking);
                    shutdownSignal.Set();
                });
                threads[i].Start();
            }
        }

        /// <summary>
        /// Adds a new task into the thread pool
        /// </summary>
        /// <typeparam name="TResult">Task result type</typeparam>
        /// <param name="func">Incoming function</param>
        /// <returns>Added task</returns>
        public ITask<TResult> AddTask<TResult>(Func<TResult> func)
        {
            if (cts.IsCancellationRequested)
            {
                throw new ThreadPoolShutdownException();
            }

            var task = TaskFactory<TResult>.CreateTask(func, this);
            AddAction(task.Execute);
            return task;
        }

        /// <summary>
        /// Adds task into the thread pool
        /// </summary>
        /// <typeparam name="TResult">task result type</typeparam>
        /// <param name="task">Incoming task to add</param>
        /// <returns>Added task</returns>
        protected internal void AddAction(Action action)
        {
            lock (lockObject)
            {
                if (cts.IsCancellationRequested)
                {
                    throw new ThreadPoolShutdownException();
                }

                tasks.Enqueue(action);
                newTaskSignal.Set();
            }
        }

        /// <summary>
        /// Shutdowns everything
        /// </summary>
        public void Shutdown()
        {
            cts.Cancel();
            lock (lockObject)
            {
                newTaskSignal.Set();
                while (amountOfWorking != 0)
                {
                    shutdownSignal.WaitOne();
                    newTaskSignal.Set();
                }
            }
        }

        /// <summary>
        /// Task
        /// </summary>
        private class Task<TResult> : ITask<TResult>
        {
            private TResult result;
            private Func<TResult> func;
            private readonly AutoResetEvent resultSignal = new AutoResetEvent(false);
            private readonly ThreadPool threadPool;
            private AggregateException exception;
            private static Object lockObject = new Object();
            private readonly Queue<Action> tasksQueue = new Queue<Action>();

            /// <summary>
            /// Defines whether or not task is completed
            /// </summary>
            public bool IsCompleted { get; private set; }

            /// <summary>
            /// Task's constructor
            /// </summary>
            /// <param name="func">Incoming function</param>
            /// <param name="threadPool">Thread pool to which task belongs</param>
            protected internal Task(Func<TResult> func, ThreadPool threadPool)
            {
                this.func = func;
                this.threadPool = threadPool;
            }

            /// <summary>
            /// Returns result of task's completion
            /// </summary>
            /// <returns>Task's result</returns>
            public TResult Result
            {
                get
                {
                    resultSignal.WaitOne();
                    if (exception != null)
                    {
                        throw exception;
                    }
                    return result;
                }
            }

            /// <summary>
            /// Returns a new task which is going to be completed
            /// </summary>
            /// <param name="func">Incoming function</param>
            /// <returns>New task</returns>
            public ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
            {
                if (threadPool.IsClosed)
                {
                    throw new ThreadPoolShutdownException();
                }

                var task = new Task<TNewResult>(() => func(result), threadPool);
                lock (lockObject)
                {
                    if (!IsCompleted)
                    {
                        tasksQueue.Enqueue(task.Execute);
                    }
                    else
                    {
                        threadPool.AddAction(task.Execute);
                    }
                    return task;
                }
            }

            /// <summary>
            /// Executes the task
            /// </summary>
            public Action Execute => () =>
            {
                try
                {
                    result = func();
                    func = null;
                }
                catch (Exception e)
                {
                    exception = new AggregateException(e);
                }
                finally
                {
                    lock (lockObject)
                    {
                        IsCompleted = true;
                        resultSignal.Set();
                        if (tasksQueue.Count != 0)
                        {
                            if (exception != null)
                            {
                                throw exception;
                            }

                            if (!threadPool.IsClosed)
                            {
                                foreach (var action in tasksQueue)
                                {
                                    threadPool.AddAction(action);
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
