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
        public void AddExistingTest()
        {
            tree.Add("string1");
            tree.Add("tests");
            tree.Add("example");
            Assert.AreEqual(3, tree.Count);
            Assert.IsFalse(tree.Add("string1"));
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
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            tree.Add("six");
            tree.Add("seven");
            tree.Add("eight");
            tree.Add("nine");
            Assert.AreEqual(9, tree.Count);
            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        [Test]
        public void ContainsTest()
        {
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            Assert.IsTrue(tree.Contains("five"));
            Assert.IsTrue(tree.Contains("one"));
            Assert.IsTrue(tree.Contains("three"));
            Assert.IsFalse(tree.Contains("odd str"));
            Assert.IsFalse(tree.Contains("something"));
        }

        [Test]
        public void RemoveTest()
        {
            tree.Add("oneone");
            tree.Add("thing");
            tree.Add("testagain");
            tree.Add("some string");
            tree.Add("hey you");
            Assert.AreEqual(5, tree.Count);
            Assert.IsTrue(tree.Contains("oneone"));
            tree.Remove("oneone");
            Assert.AreEqual(4, tree.Count);
            Assert.IsFalse(tree.Contains("oneone"));
        }
    }
}