using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace _8._2
{
    public class GenericTreeIntTests
    {
        private GenericTree<int> tree;

        [SetUp]
        public void Setup()
        {
            tree = new GenericTree<int>();
        }

        [Test]
        public void AddTest()
        {
            tree.Add(12);
            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void AddTwiceTest()
        {
            tree.Add(-8);
            tree.Add(0);
            Assert.AreEqual(2, tree.Count);
        }

        [Test]
        public void AddExistingTest()
        {
            tree.Add(11);
            tree.Add(84);
            tree.Add(3);
            Assert.AreEqual(3, tree.Count);
            Assert.IsFalse(tree.Add(84));
            Assert.AreEqual(3, tree.Count);
        }

        [Test]
        public void IsReadOnlyTest()
        {
            Assert.IsFalse(tree.IsReadOnly);
        }

        [Test]
        public void ClearTest()
        {
            tree.Add(12);
            tree.Add(0);
            tree.Add(18);
            tree.Add(4);
            tree.Add(-11);
            tree.Add(20);
            tree.Add(14);
            tree.Add(3);
            tree.Add(21);
            Assert.AreEqual(9, tree.Count);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [Test]
        public void ContainsTest()
        {
            tree.Add(11);
            tree.Add(20);
            tree.Add(14);
            tree.Add(3);
            tree.Add(4);
            tree.Add(1);
            Assert.IsTrue(tree.Contains(20));
            Assert.IsTrue(tree.Contains(11));
            Assert.IsTrue(tree.Contains(3));
            Assert.IsFalse(tree.Contains(19));
            Assert.IsFalse(tree.Contains(0));
        }

        [Test]
        public void RemoveTest()
        {
            tree.Add(10);
            tree.Add(-8);
            tree.Add(13);
            tree.Add(1);
            tree.Add(-13);
            tree.Add(22);
            Assert.AreEqual(6, tree.Count);
            Assert.IsTrue(tree.Contains(1));
            tree.Remove(1);
            Assert.AreEqual(5, tree.Count);
            Assert.IsFalse(tree.Contains(1));
        }
    }
}