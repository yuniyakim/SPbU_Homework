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
        public void IsReadOnlyTest()
        {
            Assert.IsFalse(tree.IsReadOnly);
        }
    }
}