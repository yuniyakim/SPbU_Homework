using System;
using NUnit.Framework;

namespace _4._2
{
    public class ListTests
    {
        private List list;

        [SetUp]
        public void Initialize()
        {
            list = new List();
        }

        [Test]
        public void IsEmptyListTest()
        {
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void AddTest()
        {
            list.Add("A very looooooooooooong string with many words and letters", 1245);
            Assert.IsFalse(list.IsEmpty);
        }

        [Test]
        public void DeleteTest()
        {
            list.Add("Delete test string", -3012);
            list.Delete(1);
            Assert.IsTrue(list.IsEmpty);
        }

        [Test]
        public void ManyElementsAddTest()
        {
            for (int i = -10000; i < 10000; ++i)
            {
                list.Add("Many elements Add test", 1);
            }
        }

        [Test]
        public void ManyAddAndDeleteTest()
        {
            for (int i = -10000; i < 10000; ++i)
            {
                list.Add(i.ToString(), i + 10000);
            }
            for (int i = 10000; i > 10000; --i)
            {
                list.Delete(1);
            }
        }

        [Test]
        public void AddOverflowListTest()
        {
            list.Add("Number1", 1);
            Assert.Throws<InvalidOperationException>(() => list.Add("Number3", 3));
        }

        [Test]
        public void DeleteFromEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(() => list.Delete(542));
        }

        [Test]
        public void DeleteOverflowListTest()
        {
            list.Add("Number1", 1);
            list.Add("Number3", 2);
            list.Add("Number2", 2);
            Assert.Throws<InvalidOperationException>(() => list.Delete(-8));
        }

        [Test]
        public void IsContainedByPositionListTest()
        {
            list.Add("One", 1);
            list.Add("Two", 1);
            list.Add("Three", 2);
            list.Add("Four", 4);
            Assert.IsTrue(list.IsContained(3));
        }

        [Test]
        public void IsNotContainedByPositionListTest()
        {
            list.Add("One", 1);
            list.Add("Two", 1);
            list.Add("Three", 1);
            list.Add("Four", 2);
            Assert.IsFalse(list.IsContained(-8));
        }

        [Test]
        public void IsContainedByValueListTest()
        {
            list.Add("One", 1);
            list.Add("Two", 2);
            list.Add("Three", 1);
            list.Add("Four", 1);
            Assert.IsTrue(list.IsContainedByValue("Four"));
        }

        [Test]
        public void IsNotContainedByValueListTest()
        {
            list.Add("One", 1);
            list.Add("Two", 1);
            list.Add("Three", 3);
            list.Add("Four", 1);
            Assert.IsFalse(list.IsContainedByValue("Five"));
        }

        [Test]
        public void PositionByValueTest()
        {
            list.Add("2", 1);
            list.Add("3", 2);
            list.Add("1", 1);
            list.Add("0", 1);
            Assert.AreEqual(3, list.PositionByValue("2"));
        }

        [Test]
        public void ZeroPositionByValueTest()
        {
            list.Add("2", 1);
            list.Add("3", 2);
            list.Add("1", 1);
            list.Add("0", 1);
            Assert.AreEqual(0, list.PositionByValue("5"));
        }

        [Test]
        public void GetValueFromEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(() => list.GetValue(0));
        }

        [Test]
        public void GetValueOverflowListTest()
        {
            list.Add("Number2", 1);
            list.Add("Number3", 2);
            list.Add("Number1", 1);
            Assert.Throws<InvalidOperationException>(() => list.GetValue(-1356));
        }

        [Test]
        public void SetValueInEmptyListTest()
        {
            Assert.Throws<InvalidOperationException>(() => list.SetValue("Set value in empty list test", 1));
        }

        [Test]
        public void SetValueOverflowListTest()
        {
            list.Add("22222", 1);
            list.Add("33333", 2);
            list.Add("11111", 1);
            Assert.Throws<InvalidOperationException>(() => list.SetValue("Set value overflow list test", 0));
        }
    }
}