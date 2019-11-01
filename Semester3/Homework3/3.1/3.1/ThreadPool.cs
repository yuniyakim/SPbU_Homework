using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    public class ThreadPool<T>
    {
        private int amount;
        private volatile int amountOfWorking;
        private Thread[] threads;
        private Queue<Action> tasks = new Queue<Action>();
        private static Object lockObject = new Object();
        private CancellationTokenSource cts = new CancellationTokenSource();

        public ThreadPool(int amount)
        {
            this.amount = amount;
            for (int i = 0; i < amount; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        if (tasks.TryDequeue(out Action action))
                        {
                            action();
                            ++amountOfWorking;
                        }
                        else
                        {

                        }
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
