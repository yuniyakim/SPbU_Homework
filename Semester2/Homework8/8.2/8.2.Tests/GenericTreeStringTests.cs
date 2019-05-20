using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace _8._2
{
    public class GenericTreeStringTests
    {
        private GenericTree<string> tree;

        [SetUp]
        public void Setup()
        {
            tree = new GenericTree<string>();
        }

        [Test]
        public void AddTest()
        {
            tree.Add("one");
            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void AddTwiceTest()
        {
            tree.Add("one");
            tree.Add("four");
            Assert.AreEqual(2, tree.Count);
        }

        [Test]
        public void IsReadOnlyTest()
        {
            Assert.IsFalse(tree.IsReadOnly);
        }
    }
}