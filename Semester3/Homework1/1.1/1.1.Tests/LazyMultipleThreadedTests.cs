using System;
using NUnit.Framework;
using System.Threading;

namespace _1._1
{
    public class LazyMultipleThreadedTests
    {
        private LazyMultipleThreaded<int> lazy;
        private Func<int> func;

        [SetUp]
        public void Setup()
        {
            func = () => 11 - 38;
            lazy = LazyFactory<int>.CreateLazyMultipleThreaded(func);
        }

        [Test]
        public void FuncNullExceptionTest()
        {
            Assert.Throws<FuncNullException>(() => lazy = LazyFactory<int>.CreateLazyMultipleThreaded(null));
        }

        [Test]
        public void GetTest()
        {
            var threads = new Thread[10];
            var results = new int[10];
            for (int i = 0; i < 10; ++i)
            {
                var localI = i;
                threads[i] = new Thread(() =>
                {
                    results[localI] = lazy.Get();
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            for (int k = 0; k < 10; ++k)
            {
                Assert.AreEqual(-27, results[k]);
            }
        }
    }
}