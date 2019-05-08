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
    }
}