using System;
using NUnit.Framework;

namespace _7._1
{
    public class Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void NumberTest()
        {
            calculator.Number("2");
            Assert.AreEqual("2", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [Test]
        public void AnotherNumberTest()
        {
            calculator.Number("2");
            calculator.Number("0");
            Assert.AreEqual("20", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [Test]
        public void ZeroNumberTest()
        {
            calculator.Number("0");
            calculator.Number("0");
            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [Test]
        public void OperationTest()
        {
            calculator.Number("1");
            calculator.Number("7");
            calculator.Operation("+");
            Assert.AreEqual("17 +", calculator.WholeInput);
        }

        [Test]
        public void OperationTwiceTest()
        {
            calculator.Number("8");
            calculator.Operation("*");
            Assert.AreEqual("8 *", calculator.WholeInput);
            calculator.Operation("/");
            Assert.AreEqual("8 /", calculator.WholeInput);
        }

        [Test]
        public void SimpleExpressionTest()
        {
            calculator.Number("6");
            calculator.Number("1");
            calculator.Operation("-");
            calculator.Number("2");
            calculator.Number("7");
            Assert.AreEqual("61 -", calculator.WholeInput);
            Assert.AreEqual("27", calculator.Input);
        }

        [Test]
        public void EqualityTest()
        {
            calculator.Number("8");
            calculator.Operation("-");
            calculator.Number("1");
            calculator.Number("3");
            calculator.Equality();
            Assert.AreEqual("-5", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [Test]
        public void DivideByZeroTest()
        {
            calculator.Number("1");
            calculator.Number("7");
            calculator.Operation("/");
            calculator.Number("0");
            Assert.Throws<DivideByZeroException>(() => calculator.Equality());
        }

        [Test]
        public void MultipleOperationsTest()
        {
            calculator.Number("1");
            calculator.Number("4");
            calculator.Operation("*");
            calculator.Number("3");
            calculator.Operation("-");
            Assert.AreEqual("14 * 3 -", calculator.WholeInput);
            Assert.AreEqual("42", calculator.Input);
        }

        [Test]
        public void NumberAfterEqualityTest()
        {
            calculator.Number("2");
            calculator.Number("1");
            calculator.Operation("/");
            calculator.Number("7");
            calculator.Equality();
            calculator.Number("8");
            Assert.AreEqual("8", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [Test]
        public void OperationAfterEqualityTest()
        {
            calculator.Number("4");
            calculator.Number("7");
            calculator.Operation("+");
            calculator.Number("3");
            calculator.Number("6");
            calculator.Equality();
            calculator.Operation("-");
            Assert.AreEqual("83", calculator.Input);
            Assert.AreEqual("83 -", calculator.WholeInput);
        }
    }
}