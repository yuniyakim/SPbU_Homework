using System;
using NUnit.Framework;
using System.Collections;

namespace _3._1
{
    [TestFixtureSource(typeof(FixtureDataCalculator), "FixtureParameters")]
    public class CalculatorTests
    {
        public CalculatorTests(IStack stack)
        {
            this.stack = stack;
        }

        [SetUp]
        public void Initialize()
        {
            stack.Clear();
            calculator = new Calculator(stack);
        }

        [Test]
        public void AdditionOfTwoNumbersTest()
        {
            string str = "1 99999 +";
            Assert.AreEqual(100000, calculator.Calculate(stack, str));
        }

        [Test]
        public void AdditionOfZeroTest()
        {
            string str = "0 987654321";
            Assert.AreEqual(987654321, calculator.Calculate(stack, str));
        }

        [Test]
        public void AdditionOfTwoLargeNumbersTest()
        {
            string str = "999999 999999 +";
            Assert.AreEqual(1999998, calculator.Calculate(stack, str));
        }

        [Test]
        public void ManyAdditionTest()
        {
            string str = "1111 2222 3333 4444 5555 6666 7777 8888 9999 + + + + + + + +";
            Assert.AreEqual(49995, calculator.Calculate(stack, str));
        }

        [Test]
        public void SubstractionOfTwoNumbersTest()
        {
            string str = "1 999999 -";
            Assert.AreEqual(-999998, calculator.Calculate(stack, str));
        }

        [Test]
        public void SubstractionOfZeroTest()
        {
            string str = "123456789 0 -";
            Assert.AreEqual(123456789, calculator.Calculate(stack, str));
        }

        [Test]
        public void SubstractionOfTwoLargeNumbersTest()
        {
            string str = "987654321 1133557799 -";
            Assert.AreEqual(-145903478, calculator.Calculate(stack, str));
        }

        [Test]
        public void ManySubstractionTest()
        {
            string str = "987654 321987 654321 8765 4321 765 432 109 - - - - - - -";
            Assert.AreEqual(1315102, calculator.Calculate(stack, str));
        }

        [Test]
        public void DivisionOfTwoNumbersTest()
        {
            string str = "9999999 12345 /";
            Assert.AreEqual(810, calculator.Calculate(stack, str));
        }

        [Test]
        public void DivisionByZeroTest()
        {
            string str = "789512 0 /";
            Assert.Throws<InvalidOperationException>(delegate ()
            {
                calculator.Calculate(stack, str);
            });
        }

        [Test]
        public void ManyDivisionTest()
        {
            string str = "1234567890 9753100 13579 2468 57 13 / / / / /";
            Assert.AreEqual(2784, calculator.Calculate(stack, str));
        }

        [Test]
        public void MultiplyOfTwoNumbersTest()
        {
            string str = "99999 12345 *";
            Assert.AreEqual(1234487655, calculator.Calculate(stack, str));
        }

        [Test]
        public void MultiplyOfZeroTest()
        {
            string str = "0 48816597 *";
            Assert.AreEqual(0, calculator.Calculate(stack, str));
        }

        [Test]
        public void MultiplyOfTwoLargeNumbersTest()
        {
            string str = "112358 3927 *";
            Assert.AreEqual(441229866, calculator.Calculate(stack, str));
        }

        [Test]
        public void ManyMultiplyTest()
        {
            string str = "64 49 36 25 16 9 4 1 * * * * * * *";
            Assert.AreEqual(1625702400, calculator.Calculate(stack, str));
        }

        [Test]
        public void AllOperationsTest()
        {
            string str = "51648 612 * 64889 987135 - + 13598 /";
            Assert.AreEqual(2256, calculator.Calculate(stack, str));
        }

        [Test]
        public void NoSpacesBetweenOperandsTest()
        {
            string str = "1359618 400 311 94 51 -*+/";
            Assert.AreEqual(98, calculator.Calculate(stack, str));
        }

        private IStack stack;
        private Calculator calculator;
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
