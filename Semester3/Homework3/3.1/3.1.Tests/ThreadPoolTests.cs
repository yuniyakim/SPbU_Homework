using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace _3._1
{
    public class Tests
    {
        //[Test]
        //public void AmountOfThreadsTest()
        //{
        //    var threadPool = new ThreadPool(9);
        //}

        [Test]
        public void ThreadPoolTest()
        {
            var threadPoolAmount = 3;
            var threadPool = new ThreadPool(threadPoolAmount);
            var tasksAmount = 10;
            var tasks = new ITask<int>[tasksAmount];

            for (var i = 0; i < tasksAmount; ++i)
            {
                tasks[i] = threadPool.AddTask(new Func<int>(() => i));
            }
            for (var i = 0; i < tasksAmount; ++i)
            {
                 Assert.AreEqual(i, tasks[i].Result);
            }
            threadPool.Shutdown();
        }

        [Test]
        public void ManyTasksOneThreadTest()
        {
            var threadPool = new ThreadPool(1);
            var amount = 10;
            var tasks = new ITask<int>[amount];

            for (var i = 0; i < amount; ++i)
            {
                tasks[i] = threadPool.AddTask(new Func<int>(() => i));
            }
            for (var i = 0; i < amount; ++i)
            {
                Assert.AreEqual(i, tasks[i].Result);
            }
            threadPool.Shutdown();
        }
    }
}