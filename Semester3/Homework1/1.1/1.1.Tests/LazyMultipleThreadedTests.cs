using System;
using System.Collections.Generic;
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
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}