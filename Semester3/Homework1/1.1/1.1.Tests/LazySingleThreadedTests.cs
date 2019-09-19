using System;
using NUnit.Framework;

namespace _1._1
{
    public class LazySingleThreadedTests
    {
        private LazySingleThreaded<string> lazy;
        private Func<string> func;

        [SetUp]
        public void Setup()
        {
            func = () => "test 123";
        }

        [Test]
        public void FuncNullExceptionTest()
        {
            Assert.Throws<FuncNullException>(() => lazy = LazyFactory<string>.CreateLazySingleThreaded(null));
        }
    }
}