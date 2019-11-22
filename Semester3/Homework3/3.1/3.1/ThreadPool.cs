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
        private Thread[] threads;
        private ConcurrentQueue<Action> tasks = new ConcurrentQueue<Action>();
        private static Object lockObject = new Object();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private AutoResetEvent newTaskSignal = new AutoResetEvent(false);
        private AutoResetEvent shutdownSignal = new AutoResetEvent(false);

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
                });
                threads[i].Start();
                shutdownSignal.Set();
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
    }
}
