using System;
using NUnit.Framework;
using System.Collections;

namespace _3._1
{
    [TestFixtureSource(typeof(FixtureDataCalculator), "FixtureParameters")]
    public class CalculatorTests
    {
        private IStack stack;
        private Calculator calculator;
        private string str;

        public CalculatorTests(IStack stack)
        {
            this.stack = stack;
        }

        [SetUp]
        public void Initialize()
        {
            stack.Clear();
            calculator = new Calculator(stack);
            str = "";
        }

        [Test]
        public void AdditionOfTwoNumbersTest()
        {
            str = "1 99999 +";
            Assert.AreEqual(100000, calculator.Calculate(str));
        }

        [Test]
        public void AdditionOfZeroTest()
        {
            str = "0 987654321 +";
            Assert.AreEqual(987654321, calculator.Calculate(str));
        }

        [Test]
        public void AdditionOfTwoLargeNumbersTest()
        {
            str = "999999 999999 +";
            Assert.AreEqual(1999998, calculator.Calculate(str));
        }

        [Test]
        public void ManyAdditionTest()
        {
            str = "1111 2222 3333 4444 5555 6666 7777 8888 9999 + + + + + + + +";
            Assert.AreEqual(49995, calculator.Calculate(str));
        }

        [Test]
        public void SubstractionOfTwoNumbersTest()
        {
            str = "1 999999 -";
            Assert.AreEqual(-999998, calculator.Calculate(str));
        }

        [Test]
        public void SubstractionOfZeroTest()
        {
            str = "123456789 0 -";
            Assert.AreEqual(123456789, calculator.Calculate(str));
        }

        [Test]
        public void SubstractionOfTwoLargeNumbersTest()
        {
            str = "987654321 1133557799 -";
            Assert.AreEqual(-145903478, calculator.Calculate(str));
        }

        [Test]
        public void ManySubstractionTest()
        {
            str = "987654 321987 654321 8765 4321 765 432 109 - - - - - - -";
            Assert.AreEqual(1315102, calculator.Calculate(str));
        }

        [Test]
        public void DivisionOfTwoNumbersTest()
        {
            str = "9999999 12345 /";
            Assert.AreEqual(810, calculator.Calculate(str));
        }

        [Test]
        public void DivisionByZeroTest()
        {
            str = "789512 0 /";
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                calculator.Calculate(str);
            });
        }

        [Test]
        public void ManyDivisionTest()
        {
            str = "1234567890 9753100 13579 2468 57 13 / / / / /";
            Assert.AreEqual(2784, calculator.Calculate(str));
        }

        [Test]
        public void MultiplyOfTwoNumbersTest()
        {
            str = "99999 12345 *";
            Assert.AreEqual(1234487655, calculator.Calculate(str));
        }

        [Test]
        public void MultiplyOfZeroTest()
        {
            str = "0 48816597 *";
            Assert.AreEqual(0, calculator.Calculate(str));
        }

        [Test]
        public void MultiplyOfTwoLargeNumbersTest()
        {
            str = "112358 3927 *";
            Assert.AreEqual(441229866, calculator.Calculate(str));
        }

        [Test]
        public void ManyMultiplyTest()
        {
            str = "64 49 36 25 16 9 4 1 * * * * * * *";
            Assert.AreEqual(1625702400, calculator.Calculate(str));
        }

        [Test]
        public void AllOperationsTest()
        {
            str = "51648 612 * 64889 987135 - + 13598 /";
            Assert.AreEqual(2256, calculator.Calculate(str));
        }

        [Test]
        public void NoSpacesBetweenOperationsTest()
        {
            str = "1359618 400 311 94 51 -*+/";
            Assert.AreEqual(98, calculator.Calculate(str));
        }

        [Test]
        public void InvalidInputTest()
        {
            str = "12 + 58";
            Assert.Throws<InvalidOperationException>(delegate()
            {
                calculator.Calculate(str);
            });
        }
    }

    public class FixtureDataCalculator
    {
        public static IEnumerable FixtureParameters()
        {
            yield return new StackArray();
            yield return new StackList();
        }
    }
}
