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
        public void CopyToTest()
        {
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            var array = new string[5];
            tree.CopyTo(array, 0);
            Assert.AreEqual("four", array[1]);
            Assert.AreEqual("two", array[3]);
            Assert.AreEqual("five", array[2]);
            Assert.AreEqual("three", array[4]);
            Assert.AreEqual("one", array[0]);
        }

        [Test]
        public void ExceptWithTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            testTree.Add("ten");
            testTree.Add("eleven");
            testTree.Add("twelve");
            testTree.Add("three");
            testTree.ExceptWith(tree);
            Assert.IsFalse(testTree.Contains("three"));
            Assert.IsTrue(testTree.Contains("eleven"));
            Assert.IsTrue(testTree.Contains("twelve"));
            Assert.IsTrue(testTree.Contains("ten"));
            Assert.AreEqual(3, testTree.Count);
        }

        [Test]
        public void IntersectWithTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            testTree.Add("ten");
            testTree.Add("twenty");
            testTree.Add("eleven");
            testTree.Add("twelve");
            testTree.Add("seven");
            testTree.IntersectWith(tree);
            Assert.IsFalse(testTree.Contains("ten"));
            Assert.IsFalse(testTree.Contains("twenty"));
            Assert.IsFalse(testTree.Contains("eleven"));
            Assert.IsFalse(testTree.Contains("twelve"));
            Assert.IsFalse(testTree.Contains("seven"));
            Assert.AreEqual(0, testTree.Count);
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("string1");
            tree.Add("string0");
            tree.Add("str");
            tree.Add("string28");
            tree.Add("str-3");
            testTree.Add("str");
            testTree.Add("string0");
            testTree.Add("str-3");
            Assert.IsTrue(testTree.IsProperSubsetOf(tree));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("string1");
            tree.Add("string0");
            tree.Add("str");
            tree.Add("str-3");
            testTree.Add("str");
            testTree.Add("string0");
            testTree.Add("str-3");
            Assert.IsFalse(testTree.IsProperSupersetOf(tree));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("one1");
            tree.Add("zerooo");
            tree.Add("test13");
            tree.Add("another");
            testTree.Add("test13");
            testTree.Add("another");
            Assert.IsTrue(testTree.IsSubsetOf(tree));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("11one");
            tree.Add("two22");
            tree.Add("minus4");
            tree.Add("test00");
            testTree.Add("test00");
            testTree.Add("two22");
            testTree.Add("minus4");
            testTree.Add("11one");
            Assert.IsTrue(testTree.IsSupersetOf(tree));
        }

        [Test]
        public void OverlapsTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("five");
            tree.Add("six");
            tree.Add("seven");
            tree.Add("eight");
            tree.Add("nine");
            testTree.Add("ten");
            testTree.Add("eleven");
            testTree.Add("five");
            testTree.Add("zero");
            Assert.IsTrue(testTree.Overlaps(tree));
        }

        [Test]
        public void SetEqualsTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("five");
            tree.Add("six");
            tree.Add("seven");
            tree.Add("eight");
            tree.Add("nine");
            testTree.Add("six");
            testTree.Add("eight");
            testTree.Add("five");
            testTree.Add("zero");
            testTree.Add("nine");
            testTree.Add("seven");
            Assert.IsFalse(testTree.SetEquals(tree));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            tree.Add("four");
            tree.Add("five");
            testTree.Add("five");
            testTree.Add("four");
            testTree.Add("three");
            testTree.Add("two");
            testTree.Add("one");
            testTree.SymmetricExceptWith(tree);
            Assert.IsFalse(testTree.Contains("three"));
            Assert.IsFalse(testTree.Contains("one"));
            Assert.IsFalse(testTree.Contains("four"));
            Assert.IsFalse(testTree.Contains("one"));
            Assert.IsFalse(testTree.Contains("two"));
            Assert.AreEqual(0, testTree.Count);
        }

        [Test]
        public void UnionWithTest()
        {
            var testTree = new GenericTree<string>();
            tree.Add("one");
            tree.Add("two");
            tree.Add("three");
            testTree.Add("five");
            testTree.Add("six");
            testTree.UnionWith(tree);
            Assert.IsTrue(testTree.Contains("three"));
            Assert.IsTrue(testTree.Contains("one"));
            Assert.IsTrue(testTree.Contains("six"));
            Assert.IsTrue(testTree.Contains("five"));
            Assert.IsTrue(testTree.Contains("two"));
            Assert.AreEqual(5, testTree.Count);
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
            Assert.IsTrue(tree.Contains("hey you"));
        }
    }
}