using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _1._1
{
    public class LazySingleThreadedTests
    {
        private LazySingleThreaded<int> lazy;
        private Func<int> func;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FuncNullExceptionTest()
        {
            Assert.Throws<FuncNullException>(() => );
        }
    }
}