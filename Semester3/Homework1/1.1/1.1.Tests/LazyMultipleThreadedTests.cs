using System;
using NUnit.Framework;
using System.Threading;

namespace _1._1
{
    public class LazyMultipleThreadedTests
    {
        [Test]
        public void FuncNullExceptionTest()
        {
            Assert.Throws<FuncNullException>(() => LazyFactory<int>.CreateLazyMultipleThreaded(null));
        }

        [Test]
        public void GetIntTest()
        {
            const int n = 10;
            Func<int> func = () => 11 - 38;
            var lazy = LazyFactory<int>.CreateLazyMultipleThreaded(func);
            var threads = new Thread[n];
            var results = new int[n];
            for (int i = 0; i < n; ++i)
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

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(-27, results[0]);
            for (int i = 0; i < n - 1; ++i)
            {
                Assert.IsTrue(results[i].Equals(results[i + 1]));
            }
        }

        [Test]
        public void GetStringTest()
        {
            const int n = 5;
            Func<string> func = () => "Test string";
            var lazy = LazyFactory<string>.CreateLazyMultipleThreaded(func);
            var threads = new Thread[n];
            var results = new string[n];
            for (int i = 0; i < n; ++i)
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

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual("Test string", results[0]);
            for (int i = 0; i < n - 1; ++i)
            {
                Assert.IsTrue(results[i].Equals(results[i + 1]));
            }
        }
    }
}