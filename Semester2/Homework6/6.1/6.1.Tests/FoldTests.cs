using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _6._1
{
    public class FoldTests
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
            for (int i = 6; i < 333; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(55278, Functions.Fold(list, 15, (n, x) => n + x));
        }

        [Test]
        public void AdditionOfZeroTest()
        {
            for (int i = -94562; i < 161320; ++i)
            {
                list.Add(0);
            }
            Assert.AreEqual(56321, Functions.Fold(list, 56321, (n, x) => n + x));
        }

        [Test]
        public void SubtractionTest()
        {
            for (int i = 4; i < 11625; ++i)
            {
                if (i % 2 == 1)
                {
                    list.Add(i);
                }
            }
            Assert.AreEqual(-33779340, Functions.Fold(list, 0, (n, x) => n - x));
        }

        [Test]
        public void SubtractionOfZeroTest()
        {
            for (int i = -6420; i < 11111; ++i)
            {
                list.Add(0);
            }
            Assert.AreEqual(-94949, Functions.Fold(list, -94949, (n, x) => n - x));
        }

        [Test]
        public void MultiplicationTest()
        {
            for (int i = 1; i < 13; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(479001600, Functions.Fold(list, 1, (n, x) => n * x));
        }

        [Test]
        public void MultiplicationByZeroTest()
        {
            for (int i = -92; i < 1664; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(0, Functions.Fold(list, 61234798, (n, x) => n * x));
        }

        [Test]
        public void DivisionTest()
        {
            for (int i = 1; i < 7; ++i)
            {
                list.Add(i);
            }
            Assert.AreEqual(1, Functions.Fold(list, 720, (n, x) => n / x));
        }

        [Test]
        public void DivisionByZeroTest()
        {
            for (int i = -94; i < 11; ++i)
            {
                list.Add(i);
            }
            Assert.Throws<DivideByZeroException>(() => Functions.Fold(list, 9423, (n, x) => n / x));
        }

        [Test]
        public void AllOperationsTest()
        {
            for (int i = 1; i < 10; ++i)
            {
                if (i % 3 == 0)
                {
                    list.Add(i);
                }
            }
            Assert.AreEqual(505, Functions.Fold(list, 1, (n, x) => (n + x - (x / 3)) * 5));
        }
    }
}