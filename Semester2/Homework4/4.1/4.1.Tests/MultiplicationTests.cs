using System;
using NUnit.Framework;

namespace _4._1
{
    public class MultiplicationTests
    {
        private Operation operation;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Initialize()
        {
            operation = new Multiplication();
            leftChild = new Number(0);
            rightChild = new Number(0);
            operation.LeftChild = leftChild;
            operation.RightChild = rightChild;
        }

        [Test]
        public void PositiveNumbersMultiplicationTest()
        {
            leftChild.Value = 23106;
            rightChild.Value = 584;
            Assert.AreEqual(13493904, operation.Calculate());
        }

        [Test]
        public void NegativeNumbersMultiplicationTest()
        {
            leftChild.Value = -6139;
            rightChild.Value = -803;
            Assert.AreEqual(4929617, operation.Calculate());
        }

        [Test]
        public void PositiveAndNegativeNumbersMultiplicationTest()
        {
            leftChild.Value = 4848;
            rightChild.Value = -1356;
            Assert.AreEqual(-6573888, operation.Calculate());
        }

        [Test]
        public void MultiplicationOfZeroTest()
        {
            leftChild.Value = 0;
            rightChild.Value = 16220314;
            Assert.AreEqual(0, operation.Calculate());
        }
    }
}
