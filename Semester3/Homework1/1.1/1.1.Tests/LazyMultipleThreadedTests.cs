using System;
using NUnit.Framework;

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
        public void FirstSingleThreadedGetTest()
        {
            Assert.AreEqual(-27, lazy.Get());
        }

        [Test]
        public void SecondSingleThreadedGetTest()
        {
            lazy.Get();
            Assert.AreEqual("test 123", lazy.Get());
        }

        [Test]
        public void ThirdSingleThreadedGetTest()
        {
            lazy.Get();
            lazy.Get();
            Assert.AreEqual("test 123", lazy.Get());
        }

        [Test]
        public void ManySingleThreadedGetTest()
        {
            for (int i = 0; i < 100500; ++i)
            {
                Assert.AreEqual("test 123", lazy.Get());
            }
        }
    }
}