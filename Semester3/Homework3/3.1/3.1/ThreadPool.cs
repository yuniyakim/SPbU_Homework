using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    /// <summary>
    /// Thread pool
    /// </summary>
    public class ThreadPool
    {
        private int amount;
        private volatile int amountOfWorking;
        private Thread[] threads;
        private Queue<Action> tasks = new Queue<Action>();
        private static Object lockObject = new Object();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private AutoResetEvent waitForNewTask = new AutoResetEvent(false);

        /// <summary>
        /// Shows if the thread pool is closed
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

            this.amount = amount;
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
                            action();
                        }
                        else
                        {
                            waitForNewTask.WaitOne();
                        }
                    }
                    lock (lockObject)
                    {
                        --amountOfWorking;
                    }
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
                return null;
            }

            var task = TaskFactory<TResult>.CreateTask(func, this);
            return AddTaskIntoThreadPool(task);
        }

        /// <summary>
        /// Adds task into the thread pool
        /// </summary>
        /// <typeparam name="TResult">task result type</typeparam>
        /// <param name="task">Incoming task to add</param>
        /// <returns>Added task</returns>
        protected internal ITask<TResult> AddTaskIntoThreadPool<TResult>(Task<TResult> task)
        {
            if (cts.IsCancellationRequested)
            {
                return null;
            }

            tasks.Enqueue(task.Execute);
            waitForNewTask.Set();
            return task;
        }

        public void Shutdown()
        {
            cts.Cancel();

        }
    }
}
