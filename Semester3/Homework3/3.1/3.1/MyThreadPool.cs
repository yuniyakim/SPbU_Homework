using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._1
{
    public class MyThreadPool<T>
    {
        private int amount;
        private Thread[] threads;
        private Queue<T> buffer = new Queue<T>();
        private Semaphore semaphore;
        private static Object lockObject = new Object();

        public MyThreadPool(int amount)
        {
            this.amount = amount;
            semaphore = new Semaphore(0, amount);
            for (int i = 0; i < amount; ++i)
            {
                threads[i] = new Thread(() =>
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
                });
            }
        }

        public void Shutdown()
        {

        }
    }
}
