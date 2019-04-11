using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _6._1
{
    public class MapTests
    {
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int>();
        }

        [Test]
        public void AdditionTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x + 5);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i + 5, list[i]);
            }
        }

        [Test]
        public void AdditionOfZeroTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x + 0);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        public void ManyAdditionTest()
        {
            for (int i = -123; i <= 55555; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x + 1234);
            for (int i = -123; i <= 55555; ++i)
            {
                Assert.AreEqual(i + 1234, list[i + 123]);
            }
        }

        [Test]
        public void SubstractionTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x - 24);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i - 24, list[i]);
            }
        }

        [Test]
        public void SubstractionOfZeroTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x - 0);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        [Test]
        public void ManySubstractionTest()
        {
            for (int i = -50000; i <= 42000; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x - 99);
            for (int i = -50000; i <= 42000; ++i)
            {
                Assert.AreEqual(i - 99, list[i + 50000]);
            }
        }

        [Test]
        public void MultiplicationTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x * 2);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i * 2, list[i]);
            }
        }

        [Test]
        public void MultiplicationByZeroTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x * 0);
            foreach (var element in list)
            {
                Assert.AreEqual(0, element);
            }
        }

        [Test]
        public void ManyMultiplicationTest()
        {
            for (int i = -6420; i <= 13579; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x * 46);
            for (int i = -6420; i <= 13579; ++i)
            {
                Assert.AreEqual(i * 46, list[i + 6420]);
            }
        }

        [Test]
        public void DivisionTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x / 3);
            for (int i = 0; i <= 10; ++i)
            {
                Assert.AreEqual(i / 3, list[i]);
            }
        }

        [Test]
        public void DivisionByZeroTest()
        {
            list.Add(3612);
            Assert.Throws<DivideByZeroException>(() => list = Functions.Map(list, x => x / 0));
        }

        [Test]
        public void ManyDivisionTest()
        {
            for (int i = -4444; i <= 88888; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => x / 60);
            for (int i = -4444; i <= 88888; ++i)
            {
                Assert.AreEqual(i / 60, list[i + 4444]);
            }
        }

        [Test]
        public void AllOperationsTest()
        {
            for (int i = -10; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Map(list, x => (x + 18) * 5 + (x - 6) / 3);
            for (int i = -10; i <= 10; ++i)
            {
                Assert.AreEqual(((i + 18) * 5 + (i - 6) / 3), list[i + 10]);
            }
        }
    }
}