using System;
using NUnit.Framework;

namespace _4._1
{
    public class OperationsTests
    {
        public class AdditionTests
        {
            [SetUp]
            public void Initialize()
            {
                operation = new Addition();
                leftChild = new Number(0);
                rightChild = new Number(0);
                operation.leftChild = leftChild;
                operation.rigthChild = rightChild;
            }

            [Test]
            public void PositiveNumbersAdditionTest()
            {
                leftChild.number = 10324;
                rightChild.number = 423103297;
                Assert.AreEqual(423113621, operation.Calculate());
            }

            [Test]
            public void NegativeNumbersAdditionTest()
            {
                leftChild.number = -13206477;
                rightChild.number = -3123;
                Assert.AreEqual(-13209600, operation.Calculate());
            }

            [Test]
            public void AdditionOfZeroTest()
            {
                leftChild.number = 6123014;
                rightChild.number = 0;
                Assert.AreEqual(6123014, operation.Calculate());
            }

            private Operation operation;
            private Number leftChild;
            private Number rightChild;
        }

        public class SubstractionTests
        {
            [SetUp]
            public void Initialize()
            {
                operation = new Substraction();
                leftChild = new Number(0);
                rightChild = new Number(0);
                operation.leftChild = leftChild;
                operation.rigthChild = rightChild;
            }

            [Test]
            public void PositiveNumbersSubstractionTest()
            {
                leftChild.number = 945120;
                rightChild.number = 15329;
                Assert.AreEqual(929791, operation.Calculate());
            }

            [Test]
            public void NegativeNumbersSubstractionTest()
            {
                leftChild.number = -613944;
                rightChild.number = -8033164;
                Assert.AreEqual(7419220, operation.Calculate());
            }

            [Test]
            public void SubstractionOfZeroTest()
            {
                leftChild.number = -1320644;
                rightChild.number = 0;
                Assert.AreEqual(-1320644, operation.Calculate());
            }

            [Test]
            public void SubstractionFromZeroTest()
            {
                leftChild.number = 0;
                rightChild.number = 9456211;
                Assert.AreEqual(-9456211, operation.Calculate());
            }

            private Operation operation;
            private Number leftChild;
            private Number rightChild;
        }

        public class MultiplicationTests
        {
            [SetUp]
            public void Initialize()
            {
                operation = new Multiplication();
                leftChild = new Number(0);
                rightChild = new Number(0);
                operation.leftChild = leftChild;
                operation.rigthChild = rightChild;
            }

            [Test]
            public void PositiveNumbersMultiplicationTest()
            {
                leftChild.number = 23106;
                rightChild.number = 584;
                Assert.AreEqual(13493904, operation.Calculate());
            }

            [Test]
            public void NegativeNumbersMultiplicationTest()
            {
                leftChild.number = -6139;
                rightChild.number = -803;
                Assert.AreEqual(4929617, operation.Calculate());
            }

            [Test]
            public void PositiveAndNegativeNumbersMultiplicationTest()
            {
                leftChild.number = 4848;
                rightChild.number = -1356;
                Assert.AreEqual(-6573888, operation.Calculate());
            }

            [Test]
            public void MultiplicationOfZeroTest()
            {
                leftChild.number = 0;
                rightChild.number = 16220314;
                Assert.AreEqual(0, operation.Calculate());
            }

            private Operation operation;
            private Number leftChild;
            private Number rightChild;
        }

        public class DivisionTests
        {
            [SetUp]
            public void Initialize()
            {
                operation = new Division();
                leftChild = new Number(0);
                rightChild = new Number(0);
                operation.leftChild = leftChild;
                operation.rigthChild = rightChild;
            }

            [Test]
            public void PositiveNumbersDivisionTest()
            {
                leftChild.number = 10222362;
                rightChild.number = 162;
                Assert.AreEqual(63101, operation.Calculate());
            }

            [Test]
            public void NegativeNumbersDivisionTest()
            {
                leftChild.number = -11058930;
                rightChild.number = -1845;
                Assert.AreEqual(5994, operation.Calculate());
            }

            [Test]
            public void PositiveAndNegativeNumbersDivisionTest()
            {
                leftChild.number = 59856696;
                rightChild.number = -6312;
                Assert.AreEqual(-9483, operation.Calculate());
            }

            [Test]
            public void DivisionByZeroTest()
            {
                leftChild.number = 2246219;
                rightChild.number =  0;
                Assert.Throws<DivideByZeroException>(delegate ()
                {
                    operation.Calculate();
                });
            }

            private Operation operation;
            private Number leftChild;
            private Number rightChild;
        }
    }
}
