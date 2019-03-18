using System;
using NUnit.Framework;

namespace _4._1
{
    public class TreeTests
    {
        [SetUp]
        public void Setup()
        {
            tree = new Tree();
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(tree.IsEmpty());
        }

        private Tree tree;
    }
}