using System;
using NUnit.Framework;

namespace _4._1
{
    public class AdditionTests
    {
        private Operation operation;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Initialize()
        {
            operation = new Addition();
            leftChild = new Number(0);
            rightChild = new Number(0);
            operation.LeftChild = leftChild;
            operation.RightChild = rightChild;
        }

        [Test]
        public void PositiveNumbersAdditionTest()
        {
            leftChild.Value = 10324;
            rightChild.Value = 423103297;
            Assert.AreEqual(423113621, operation.Calculate());
        }

        [Test]
        public void NegativeNumbersAdditionTest()
        {
            leftChild.Value = -13206477;
            rightChild.Value = -3123;
            Assert.AreEqual(-13209600, operation.Calculate());
        }

        [Test]
        public void AdditionOfZeroTest()
        {
            leftChild.Value = 6123014;
            rightChild.Value = 0;
            Assert.AreEqual(6123014, operation.Calculate());
        }
    }
}
