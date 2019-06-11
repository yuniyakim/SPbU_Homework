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
        public void CopyToTest()
        {
            tree.Add(1);
            tree.Add(22);
            tree.Add(333);
            tree.Add(4444);
            tree.Add(55555);
            var array = new int[5];
            tree.CopyTo(array, 0);
            Assert.AreEqual(4444, array[3]);
            Assert.AreEqual(22, array[1]);
            Assert.AreEqual(55555, array[4]);
            Assert.AreEqual(333, array[2]);
            Assert.AreEqual(1, array[0]);
        }

        [Test]
        public void ExceptWithTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(1);
            tree.Add(3);
            tree.Add(5);
            tree.Add(4);
            tree.Add(2);
            testTree.Add(1);
            testTree.Add(4);
            testTree.Add(-6);
            testTree.Add(5);
            testTree.ExceptWith(tree);
            Assert.IsFalse(testTree.Contains(1));
            Assert.IsFalse(testTree.Contains(4));
            Assert.IsFalse(testTree.Contains(5));
            Assert.IsTrue(testTree.Contains(-6));
            Assert.AreEqual(1, testTree.Count);
        }

        [Test]
        public void IntersectWithTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(6);
            tree.Add(2);
            tree.Add(8);
            tree.Add(-11);
            tree.Add(3);
            testTree.Add(1);
            testTree.Add(3);
            testTree.Add(-6);
            testTree.Add(8);
            testTree.Add(2);
            testTree.IntersectWith(tree);
            Assert.IsFalse(testTree.Contains(1));
            Assert.IsFalse(testTree.Contains(-6));
            Assert.IsTrue(testTree.Contains(2));
            Assert.IsTrue(testTree.Contains(8));
            Assert.IsTrue(testTree.Contains(3));
            Assert.AreEqual(3, testTree.Count);
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(11);
            tree.Add(2);
            tree.Add(33);
            tree.Add(0);
            testTree.Add(33);
            testTree.Add(2);
            testTree.Add(0);
            testTree.Add(11);
            Assert.IsFalse(testTree.IsProperSubsetOf(tree));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(11);
            tree.Add(2);
            tree.Add(33);
            testTree.Add(33);
            testTree.Add(2);
            testTree.Add(44);
            testTree.Add(-12);
            testTree.Add(0);
            testTree.Add(11);
            Assert.IsTrue(testTree.IsProperSupersetOf(tree));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(11);
            tree.Add(2);
            tree.Add(33);
            testTree.Add(33);
            testTree.Add(2);
            testTree.Add(11);
            Assert.IsTrue(testTree.IsSubsetOf(tree));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(11);
            tree.Add(2);
            tree.Add(33);
            testTree.Add(33);
            testTree.Add(2);
            testTree.Add(44);
            testTree.Add(-12);
            testTree.Add(0);
            testTree.Add(11);
            Assert.IsTrue(testTree.IsSupersetOf(tree));
        }

        [Test]
        public void OverlapsTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(31);
            tree.Add(27);
            tree.Add(-99);
            testTree.Add(33);
            testTree.Add(2);
            testTree.Add(44);
            testTree.Add(-12);
            testTree.Add(0);
            testTree.Add(11);
            Assert.IsFalse(testTree.Overlaps(tree));
        }

        [Test]
        public void SetEqualsTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(-1);
            tree.Add(82);
            tree.Add(-44);
            tree.Add(2000);
            testTree.Add(-44);
            testTree.Add(82);
            testTree.Add(2000);
            testTree.Add(-1);
            Assert.IsTrue(testTree.SetEquals(tree));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(0);
            tree.Add(4);
            testTree.Add(5);
            testTree.Add(2);
            testTree.Add(0);
            testTree.Add(-1);
            testTree.Add(-4);
            testTree.SymmetricExceptWith(tree);
            Assert.IsFalse(testTree.Contains(2));
            Assert.IsFalse(testTree.Contains(0));
            Assert.IsTrue(testTree.Contains(1));
            Assert.IsTrue(testTree.Contains(-1));
            Assert.IsTrue(testTree.Contains(4));
            Assert.IsTrue(testTree.Contains(-4));
            Assert.IsTrue(testTree.Contains(5));
            Assert.AreEqual(5, testTree.Count);
        }

        [Test]
        public void UnionWithTest()
        {
            var testTree = new GenericTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(0);
            testTree.Add(0);
            testTree.Add(-1);
            testTree.Add(-4);
            testTree.UnionWith(tree);
            Assert.IsTrue(testTree.Contains(-4));
            Assert.IsTrue(testTree.Contains(2));
            Assert.IsTrue(testTree.Contains(0));
            Assert.IsTrue(testTree.Contains(-4));
            Assert.IsTrue(testTree.Contains(-1));
            Assert.AreEqual(5, testTree.Count);
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
            Assert.IsTrue(tree.Contains(-13));
        }
    }
}