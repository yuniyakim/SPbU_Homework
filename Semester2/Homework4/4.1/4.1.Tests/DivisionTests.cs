using System;
using NUnit.Framework;

namespace _4._1
{
    public class DivisionTests
    {
        private Operation operation;
        private Number leftChild;
        private Number rightChild;

        [SetUp]
        public void Initialize()
        {
            operation = new Division();
            leftChild = new Number(0);
            rightChild = new Number(0);
            operation.LeftChild = leftChild;
            operation.RightChild = rightChild;
        }

        [Test]
        public void PositiveNumbersDivisionTest()
        {
            leftChild.Value = 10222362;
            rightChild.Value = 162;
            Assert.AreEqual(63101, operation.Calculate());
        }

        [Test]
        public void NegativeNumbersDivisionTest()
        {
            leftChild.Value = -11058930;
            rightChild.Value = -1845;
            Assert.AreEqual(5994, operation.Calculate());
        }

        [Test]
        public void PositiveAndNegativeNumbersDivisionTest()
        {
            leftChild.Value = 59856696;
            rightChild.Value = -6312;
            Assert.AreEqual(-9483, operation.Calculate());
        }

        [Test]
        public void DivisionByZeroTest()
        {
            leftChild.Value = 2246219;
            rightChild.Value = 0;
            Assert.Throws<DivideByZeroException>(() => operation.Calculate());
        }
    }
}
