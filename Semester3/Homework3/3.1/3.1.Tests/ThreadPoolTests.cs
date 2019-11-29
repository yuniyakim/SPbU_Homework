using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace _3._1
{
    public class Tests
    {
        [Test]
        public void InvalidAmountOfThreadsTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ThreadPool(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ThreadPool(0));
        }

        [Test]
        public void AmountOfThreadsTest()
        {
            var amount = 12;
            var threadPool = new ThreadPool(amount);
            var bag = new ConcurrentBag<int>();

            for (var i = 0; i < amount; ++i)
            {
                threadPool.AddTask(() =>
                {
                    bag.Add(Thread.CurrentThread.ManagedThreadId);
                    return 1;
                });
            }
            threadPool.Shutdown();
            Assert.AreEqual(bag.Count(), bag.Distinct().Count());
        }

        [Test]
        public void ThreadPoolTest()
        {
            var threadPoolAmount = 3;
            var threadPool = new ThreadPool(threadPoolAmount);
            var tasksAmount = 10;
            var tasks = new ITask<int>[tasksAmount];
            var taskExecute = new ManualResetEvent(false);

            for (var i = 0; i < tasksAmount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() =>
                {
                    taskExecute.WaitOne();
                    Thread.Sleep(100);
                    return localI;
                });
            }
            taskExecute.Set();
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
            var amount = 20;
            var tasks = new ITask<int>[amount];

            for (var i = 0; i < amount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() => localI);
            }
            for (var i = 0; i < amount; ++i)
            {
                Assert.AreEqual(i, tasks[i].Result);
            }
            threadPool.Shutdown();
        }

        [Test]
        public void ShutdownTest()
        {
            var threadPool = new ThreadPool(3);
            var amount = 5;
            var tasks = new ITask<string>[amount];

            for (var i = 0; i < amount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() => $"number {localI}");
            }

            threadPool.Shutdown();
            Assert.Throws<ThreadPoolShutdownException>(() => threadPool.AddTask(new Func<string>(() => "string")));
            for (var i = 0; i < amount; ++i)
            {
                Assert.Throws<ThreadPoolShutdownException>(() => tasks[i].ContinueWith((result) => result + "exeption"));
            }
            Assert.IsTrue(threadPool.IsClosed);
        }

        [Test]
        public void IsCompletedTest()
        {
            var threadPoolAmount = 2;
            var threadPool = new ThreadPool(threadPoolAmount);
            var tasksAmount = 5;
            var tasks = new ITask<int>[tasksAmount];
            var random = new Random();
            var taskExecute = new ManualResetEvent(false);

            for (var i = 0; i < tasksAmount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() =>
                {
                    taskExecute.WaitOne();
                    return random.Next(0, 100) * 9 - (localI + 13) * 31;
                });
            }

            for (var i = 0; i < tasksAmount; ++i)
            {
                Assert.IsFalse(tasks[i].IsCompleted);
            }
            taskExecute.Set();
            for (var i = 0; i < tasksAmount; ++i)
            {
                Assert.NotNull(tasks[i].Result);
                Assert.IsTrue(tasks[i].IsCompleted);
            }
            threadPool.Shutdown();
        }

        [Test]
        public void ContinueWithTest()
        {
            var threadPoolAmount = 3;
            var threadPool = new ThreadPool(threadPoolAmount);
            var tasksAmount = 10;
            var tasks = new ITask<int>[tasksAmount];

            for (var i = 0; i < tasksAmount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() => localI).ContinueWith((result) => result * 18);
                Thread.Sleep(100);
            }
            for (var i = 0; i < tasksAmount; ++i)
            {
                Assert.AreEqual(i * 18, tasks[i].Result);
            }
            threadPool.Shutdown();
        }

        [Test]
        public void ManyContinueWithTest()
        {
            var threadPoolAmount = 3;
            var threadPool = new ThreadPool(threadPoolAmount);
            var task1 = threadPool.AddTask(() => 9);
            var task2 = task1.ContinueWith((result) => result > 0 ? false : true);
            var task3 = task2.ContinueWith((result) => result ? 15 * 6 : 13 * 8);
            var task4 = task3.ContinueWith((result) => result.ToString());
            var task5 = task4.ContinueWith((result) => "hello" + result + "world");
            Assert.AreEqual("hello104world", task5.Result);
            threadPool.Shutdown();
        }

        [Test]
        public void AggregateExceptionTest()
        {
            var threadPoolAmount = 8;
            var threadPool = new ThreadPool(threadPoolAmount);
            var tasksAmount = 3;
            var tasks = new ITask<int>[tasksAmount];

            for (var i = 0; i < tasksAmount; ++i)
            {
                var localI = i;
                tasks[localI] = threadPool.AddTask(() => localI).ContinueWith((result) => result / 0);
            }
            for (var i = 0; i < tasksAmount; ++i)
            {
                Assert.Throws<AggregateException>(() => _ = tasks[i].Result);
            }
            threadPool.Shutdown();
        }
    }
}