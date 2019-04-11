using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _6._1
{
    public class FilterTests
    {
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int>();
        }

        [Test]
        public void EvenNumbersTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x % 2 == 0);
            for (int i = 0; i <= 10; ++i)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(i, list[i / 2]);
                }
            }
        }

        [Test]
        public void OddNumbersTest()
        {
            for (int i = 0; i <= 10; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x % 2 == 1);
            for (int i = 0; i <= 10; ++i)
            {
                if (i % 2 == 1)
                {
                    Assert.AreEqual(i, list[i / 2]);
                }
            }
        }

        [Test]
        public void PositiveNumbersTest()
        {
            for (int i = -21; i <= 49; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x > 0);
            for (int i = -21; i <= 49; ++i)
            {
                if (i > 0)
                {
                    Assert.AreEqual(i, list[i - 1]);
                }
            }
        }

        [Test]
        public void NegativeNumbersAndZeroTest()
        {
            for (int i = -59; i <= 3; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x <= 0);
            for (int i = -59; i <= 3; ++i)
            {
                if (i <= 0)
                {
                    Assert.AreEqual(i, list[i + 59]);
                }
            }
        }

        [Test]
        public void EqualToZeroTest()
        {
            for (int i = -15000; i <= 32120; ++i)
            {
                if (i % 7 == 0)
                {
                    list.Add(0);
                }
                else
                {
                    list.Add(1);
                }
            }
            list = Functions.Filter(list, x => x == 0);
            for (int i = -15000; i <= 32120; ++i)
            {
                if (i % 7 == 0)
                {
                    Assert.AreEqual(0, list[(i + 15000) / 7]);
                }
            }
        }

        [Test]
        public void GreaterThanAPositiveNumberTest()
        {
            for (int i = -55555; i <= 43210; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x > 569);
            for (int i = -55555; i <= 43210; ++i)
            {
                if (i > 569)
                {
                    Assert.AreEqual(i, list[i - 570]);
                }
            }
        }

        [Test]
        public void GreaterThanANegativeNumberTest()
        {
            for (int i = -55555; i <= 43210; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x > -321);
            for (int i = -55555; i <= 43210; ++i)
            {
                if (i > -321)
                {
                    Assert.AreEqual(i, list[i + 320]);
                }
            }
        }

        [Test]
        public void LessThanAPositiveNumberTest()
        {
            for (int i = -55555; i <= 43210; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x < 2525);
            for (int i = -55555; i <= 43210; ++i)
            {
                if (i < 2525)
                {
                    Assert.AreEqual(i, list[i + 55555]);
                }
            }
        }

        [Test]
        public void LessThanANegativeNumberTest()
        {
            for (int i = -55555; i <= 43210; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x < -777);
            for (int i = -55555; i <= 43210; ++i)
            {
                if (i < -777)
                {
                    Assert.AreEqual(i, list[i + 55555]);
                }
            }
        }

        [Test]
        public void SeveralConditionsTest()
        {
            for (int i = 0; i < 1234567; ++i)
            {
                list.Add(i);
            }
            list = Functions.Filter(list, x => x % 11 == 0 && x >= 3232 && x < 99999);
            for (int i = 0; i < 1234567; ++i)
            {
                if (i % 11 == 0 && i >= 3232 && i < 99999)
                {
                    Assert.AreEqual(i, list[(i -3232) / 11]);
                }
            }
        }
    }
}