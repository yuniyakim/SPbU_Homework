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
            lazy = LazyFactory<string>.CreateLazySingleThreaded(func);
        }

        [Test]
        public void FuncNullExceptionTest()
        {
            Assert.Throws<FuncNullException>(() => lazy = LazyFactory<string>.CreateLazySingleThreaded(null));
        }

        [Test]
        public void FirstGetTest()
        {
            Assert.AreEqual("test 123", lazy.Get());
        }

        [Test]
        public void SecondGetTest()
        {
            lazy.Get();
            Assert.AreEqual("test 123", lazy.Get());
        }

        [Test]
        public void ThirdGetTest()
        {
            lazy.Get();
            lazy.Get();
            Assert.AreEqual("test 123", lazy.Get());
        }

        [Test]
        public void ManyGetTest()
        {
            for (int i = 0; i < 100500; ++i)
            {
                Assert.AreEqual("test 123", lazy.Get());
            }
        }
    }
}