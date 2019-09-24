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
            Func<int> func = () => 11 - 38;
            var lazy = LazyFactory<int>.CreateLazyMultipleThreaded(func);
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

            foreach (var thread in threads)
            {
                thread.Join();
            }

            foreach (var result in results)
            {
                Assert.AreEqual(-27, result);
            }
        }

        [Test]
        public void GetStringTest()
        {
            Func<string> func = () => "Test string";
            var lazy = LazyFactory<string>.CreateLazyMultipleThreaded(func);
            var threads = new Thread[5];
            var results = new string[5];
            for (int i = 0; i < 5; ++i)
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

            foreach (var result in results)
            {
                Assert.AreEqual("Test string", result);
            }
        }
    }
}