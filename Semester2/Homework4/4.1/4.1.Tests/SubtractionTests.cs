using System;
using NUnit.Framework;

namespace _4._1
{
    public class SubtractionTests
    {
        private Operation operation;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Initialize()
        {
            operation = new Subtraction();
            leftChild = new Number(0);
            rightChild = new Number(0);
            operation.LeftChild = leftChild;
            operation.RightChild = rightChild;
        }

        [Test]
        public void PositiveNumbersSubtractionTest()
        {
            leftChild.Value = 945120;
            rightChild.Value = 15329;
            Assert.AreEqual(929791, operation.Calculate());
        }

        [Test]
        public void NegativeNumbersSubtractionTest()
        {
            leftChild.Value = -613944;
            rightChild.Value = -8033164;
            Assert.AreEqual(7419220, operation.Calculate());
        }

        [Test]
        public void SubtractionOfZeroTest()
        {
            leftChild.Value = -1320644;
            rightChild.Value = 0;
            Assert.AreEqual(-1320644, operation.Calculate());
        }

        [Test]
        public void SubtractionFromZeroTest()
        {
            leftChild.Value = 0;
            rightChild.Value = 9456211;
            Assert.AreEqual(-9456211, operation.Calculate());
        }
    }
}
