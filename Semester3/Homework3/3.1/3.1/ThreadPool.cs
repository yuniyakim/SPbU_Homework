using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    /// <summary>
    /// Thread pool
    /// </summary>
    public class ThreadPool<T>
    {
        private int amount;
        private volatile int amountOfWorking;
        private Thread[] threads;
        private Queue<Action> tasks = new Queue<Action>();
        private static Object lockObject = new Object();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private AutoResetEvent executeNewTask = new AutoResetEvent(false);

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
                            executeNewTask.WaitOne();
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

        private void Work()
        {
            while (true)
            {

                lock (lockObject)
                {
                    //buffer.Enqueue(item);
                }

            }
        }

        private ITask<T> AddTask(Func<T> func)
        {

        }

        public void Shutdown()
        {

        }
    }
}
