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
    }
}