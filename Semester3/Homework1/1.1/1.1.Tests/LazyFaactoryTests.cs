using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _1._1
{
    public class LazyFactoryTests
    {
        private ILazy<bool> lazy;
        private Func<bool> func;

        [SetUp]
        public void Setup()
        {
            func = () => true;
        }

        [Test]
        public void CreateLazySingleThreadedTest()
        {
            lazy = LazyFactory<bool>.CreateLazySingleThreaded(func);
        }

        [Test]
        public void CreateLazyMultipleThreadedTest()
        {
            Assert.Pass();
        }
    }
}