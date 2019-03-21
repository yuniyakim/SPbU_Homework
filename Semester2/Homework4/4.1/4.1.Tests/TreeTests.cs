using System;
using NUnit.Framework;

namespace _4._1
{
    public class TreeTests
    {
        [SetUp]
        public void Initialize()
        {
            tree = new Tree();
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(tree.IsEmpty());
        }

        [Test]
        public void AdditionStringTest()
        {
            Assert.AreEqual(187, tree.FillAndCalculate("(+ 184 3)"));
        }

        [Test]
        public void SubstractionStringTest()
        {
            Assert.AreEqual(-31022, tree.FillAndCalculate("(- 0 31022)"));
        }

        [Test]
        public void MultiplicationStringTest()
        {
            Assert.AreEqual(11062720, tree.FillAndCalculate("(* 1810 6112)"));
        }

        [Test]
        public void DivisionStringTest()
        {
            Assert.AreEqual(1010, tree.FillAndCalculate("(/ 1552370 1537)"));
        }

        [Test]
        public void AllOperationsStringTest()
        {
            Assert.AreEqual(6, tree.FillAndCalculate("(/(* 12 (-86 84))(+30(- 1 27)))"));
        }

        private Tree tree;
    }
}