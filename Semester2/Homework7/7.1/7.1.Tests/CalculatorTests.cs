using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7._1
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void NumberTest()
        {
            calculator.Number("2");
            Assert.AreEqual("2", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [TestMethod]
        public void AnotherNumberTest()
        {
            calculator.Number("2");
            calculator.Number("0");
            Assert.AreEqual("20", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [TestMethod]
        public void ZeroNumberTest()
        {
            calculator.Number("0");
            calculator.Number("0");
            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("", calculator.WholeInput);
        }

        [TestMethod]
        public void OperationTest()
        {
            calculator.Number("1");
            calculator.Number("7");
            calculator.Operation("+");
            Assert.AreEqual("17 +", calculator.WholeInput);
        }

        [TestMethod]
        public void OperationTwiceTest()
        {
            calculator.Number("8");
            calculator.Operation("*");
            Assert.AreEqual("8 *", calculator.WholeInput);
            calculator.Operation("/");
            Assert.AreEqual("8 /", calculator.WholeInput);
        }

        [TestMethod]
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

        [TestMethod]
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

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void DivideByZeroTest()
        {
            calculator.Number("1");
            calculator.Number("7");
            calculator.Operation("/");
            calculator.Number("0");
            calculator.Equality();
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void OperationWithoutSecondTest()
        {
            calculator.Number("3");
            calculator.Number("2");
            calculator.Operation("+");
            calculator.Equality();
            Assert.AreEqual("64", calculator.Input);
        }

        [TestMethod]
        public void EqualityTwiceTest()
        {
            calculator.Number("1");
            calculator.Number("4");
            calculator.Operation("-");
            calculator.Number("2");
            calculator.Number("7");
            calculator.Equality();
            Assert.AreEqual("-13", calculator.Input);
            calculator.Equality();
            Assert.AreEqual("-13", calculator.Input);
        }

        [TestMethod]
        public void ClearTest()
        {
            calculator.Number("1");
            calculator.Number("5");
            calculator.Operation("-");
            calculator.Number("6");
            calculator.Operation("*");
            calculator.Number("4");
            calculator.Operation("/");
            calculator.Number("1");
            calculator.Number("2");
            calculator.Operation("+");
            calculator.Number("8");
            Assert.AreEqual("8", calculator.Input);
            Assert.AreEqual("15 - 6 * 4 / 12 +", calculator.WholeInput);
            calculator.Clear();
            Assert.AreEqual("", calculator.WholeInput);
            Assert.AreEqual("0", calculator.Input);
        }

        [TestMethod]
        public void ClearEntryTest()
        {
            calculator.Number("6");
            calculator.Number("2");
            calculator.Number("1");
            calculator.Operation("+");
            calculator.Number("9");
            calculator.Number("6");
            calculator.Operation("-");
            calculator.Number("1");
            calculator.Number("1");
            Assert.AreEqual("11", calculator.Input);
            Assert.AreEqual("621 + 96 -", calculator.WholeInput);
            calculator.ClearEntry();
            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("621 + 96 -", calculator.WholeInput);
        }

        [TestMethod]
        public void ClearEntryAfterOperationTest()
        {
            calculator.Number("2");
            calculator.Operation("-");
            calculator.Number("6");
            calculator.Number("9");
            calculator.Operation("*");
            Assert.AreEqual("-67", calculator.Input);
            Assert.AreEqual("2 - 69 *", calculator.WholeInput);
            calculator.ClearEntry();
            Assert.AreEqual("0", calculator.Input);
            Assert.AreEqual("2 - 69 *", calculator.WholeInput);
        }

        [TestMethod]
        public void BackspaceTest()
        {
            calculator.Number("2");
            calculator.Number("7");
            calculator.Number("3");
            calculator.Operation("-");
            calculator.Number("9");
            calculator.Number("8");
            calculator.Number("7");
            calculator.Number("0");
            Assert.AreEqual("9870", calculator.Input);
            calculator.Backspace();
            Assert.AreEqual("987", calculator.Input);
            calculator.Backspace();
            Assert.AreEqual("98", calculator.Input);
            calculator.Equality();
            Assert.AreEqual("175", calculator.Input);
        }

        [TestMethod]
        public void BackspaceAfterOperationTest()
        {
            calculator.Number("7");
            calculator.Number("2");
            calculator.Operation("+");
            calculator.Number("3");
            calculator.Number("1");
            calculator.Number("8");
            calculator.Operation("-");
            calculator.Backspace();
            calculator.Backspace();
            Assert.AreEqual("3", calculator.Input);
            Assert.AreEqual("72 + 318 -", calculator.WholeInput);
            calculator.Equality();
            Assert.AreEqual("387", calculator.Input);
        }

        [TestMethod]
        public void BackspaceAfterEqualityTest()
        {
            calculator.Number("5");
            calculator.Number("7");
            calculator.Operation("+");
            calculator.Number("8");
            calculator.Number("1");
            calculator.Equality();
            Assert.AreEqual("138", calculator.Input);
            calculator.Backspace();
            Assert.AreEqual("13", calculator.Input);
        }

        [TestMethod]
        public void BackspaceToZeroTest()
        {
            calculator.Number("4");
            calculator.Number("7");
            Assert.AreEqual("47", calculator.Input);
            calculator.Backspace();
            calculator.Backspace();
            Assert.AreEqual("0", calculator.Input);
            calculator.Backspace();
            Assert.AreEqual("0", calculator.Input);
        }

        [TestMethod]
        public void PlusMinusPositiveTest()
        {
            calculator.Number("9");
            calculator.Number("0");
            Assert.AreEqual("90", calculator.Input);
            calculator.PlusMinus();
            Assert.AreEqual("-90", calculator.Input);
        }

        [TestMethod]
        public void PlusMinusNegativeTest()
        {
            calculator.Number("1");
            calculator.Number("0");
            calculator.Operation("-");
            calculator.Number("6");
            calculator.Number("1");
            calculator.Equality();
            Assert.AreEqual("-51", calculator.Input);
            calculator.PlusMinus();
            Assert.AreEqual("51", calculator.Input);
        }

        [TestMethod]
        public void PlusMinusTwiceTest()
        {
            calculator.Number("8");
            Assert.AreEqual("8", calculator.Input);
            calculator.PlusMinus();
            Assert.AreEqual("-8", calculator.Input);
            calculator.PlusMinus();
            Assert.AreEqual("8", calculator.Input);
        }

        [TestMethod]
        public void PlusMinusAfterEqualityTest()
        {
            calculator.Number("1");
            calculator.Number("0");
            calculator.Operation("-");
            calculator.Number("1");
            calculator.Number("4");
            calculator.Equality();
            calculator.PlusMinus();
            Assert.AreEqual("4", calculator.Input);
        }

        [TestMethod]
        public void PlusMinusAfterOperationTest()
        {
            calculator.Number("2");
            calculator.Number("0");
            calculator.Operation("/");
            calculator.Number("5");
            calculator.Operation("-");
            calculator.PlusMinus();
            Assert.AreEqual("-4", calculator.Input);
            calculator.Equality();
            Assert.AreEqual("8", calculator.Input);
        }

        [TestMethod]
        public void DotTest()
        {
            calculator.Number("2");
            calculator.Number("0");
            calculator.Dot();
            calculator.Number("5");
            calculator.Number("6");
            calculator.Operation("-");
            calculator.Number("1");
            calculator.Number("4");
            calculator.Equality();
            Assert.AreEqual("6.56", calculator.Input);
        }

        [TestMethod]
        public void DotTwiceTest()
        {
            calculator.Number("3");
            calculator.Number("4");
            calculator.Dot();
            calculator.Dot();
            Assert.AreEqual("34.", calculator.Input);
            calculator.Number("6");
            calculator.Number("1");
            calculator.Dot();
            Assert.AreEqual("34.61", calculator.Input);
        }

        [TestMethod]
        public void DotAfterOperationTest()
        {
            calculator.Number("3");
            calculator.Number("4");
            calculator.Number("0");
            calculator.Operation("/");
            calculator.Number("1");
            calculator.Number("7");
            calculator.Operation("+");
            calculator.Dot();
            Assert.AreEqual("20.", calculator.Input);
        }

        [TestMethod]
        public void DotAfterEqualityTest()
        {
            calculator.Number("1");
            calculator.Number("2");
            calculator.Operation("*");
            calculator.Number("8");
            calculator.Equality();
            calculator.Dot();
            calculator.Number("3");
            Assert.AreEqual("96.3", calculator.Input);
        }

        [TestMethod]
        public void NoNumbersAfterDotTest()
        {
            calculator.Number("5");
            calculator.Number("3");
            calculator.Dot();
            calculator.Operation("-");
            calculator.Number("4");
            calculator.Number("6");
            calculator.Equality();
            Assert.AreEqual("7", calculator.Input);
        }

        [TestMethod]
        public void DecimalNumbersTest()
        {
            calculator.Number("5");
            calculator.Dot();
            calculator.Number("8");
            calculator.Operation("-");
            calculator.Number("4");
            calculator.Dot();
            calculator.Number("1");
            Assert.AreEqual("5.8 -", calculator.WholeInput);
            calculator.Equality();
            Assert.AreEqual("1.7", calculator.Input);
        }
    }
}
