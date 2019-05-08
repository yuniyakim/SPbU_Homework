using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _8._1
{
    public class GenericListTests
    {
        private GenericList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new GenericList<int>();
        }

        [Test]
        public void IsReadOnlyTest()
        {
            Assert.IsFalse(list.IsReadOnly);
        }

        [Test]
        public void AddTest()
        {
            list.Add(5);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void AddTwiceTest()
        {
            list.Add(5);
            list.Add(-103);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void InsertTest()
        {
            list.Insert(1, 0);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void InsertInvalidPositionTest()
        {
            Assert.Throws<InvalidPositionException>(() => list.Insert(0, 9826));
        }

        [Test]
        public void IndexOfTest()
        {
            list.Add(29);
            list.Add(0);
            list.Insert(3, -894);
            list.Insert(2, 2130);
            Assert.AreEqual(3, list.IndexOf(0));
        }

        [Test]
        public void ContainsTest()
        {
            list.Insert(1, 291);
            list.Insert(1, -91);
            Assert.IsTrue(list.Contains(291));
            Assert.IsFalse(list.Contains(0));
        }

        [Test]
        public void RemoveAtTest()
        {
            list.Add(2);
            list.Insert(1, 1);
            list.Add(4);
            list.Insert(3, 3);
            list.Add(5);
            list.RemoveAt(2);
            Assert.AreEqual(4, list.IndexOf(5));
            Assert.AreEqual(3, list.IndexOf(4));
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void RemoveAtInvalidPositionTest()
        {
            list.Insert(1, 200);
            list.Add(-232);
            Assert.Throws<InvalidPositionException>(() => list.RemoveAt(3));
        }

        [Test]
        public void ClearTest()
        {
            list.Add(777);
            list.Insert(1, -91);
            list.Add(777);
            list.Add(0);
            list.Insert(4, 0);
            list.Clear();
            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Contains(0));
        }
    }
}