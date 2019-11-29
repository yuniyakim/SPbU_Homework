using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task<TResult> : ITask<TResult>
    {
        private TResult result;
        private Func<TResult> func;
        private AutoResetEvent resultSignal = new AutoResetEvent(false);
        private ThreadPool threadPool;
        private AggregateException exception;
        private static Object lockObject = new Object();
        private Queue<Action> tasksQueue = new Queue<Action>();

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
