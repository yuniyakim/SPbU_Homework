using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    public class ThreadPool<T>
    {
        private int amount;
        private Thread[] threads;
        private Queue<T> buffer = new Queue<T>();
        private Semaphore semaphore;
        private static Object lockObject = new Object();
        private CancellationTokenSource cts;

        public ThreadPool(int amount)
        {
            this.amount = amount;
            semaphore = new Semaphore(0, amount);
            for (int i = 0; i < amount; ++i)
            {
                threads[i] = new Thread(() => Work());
                threads[i].Start();
            }
        }

        private void Work()
        {
            while (true)
            {
                semaphore.WaitOne();
                lock (lockObject)
                {
                    //buffer.Enqueue(item);
                }
                semaphore.Release();
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
