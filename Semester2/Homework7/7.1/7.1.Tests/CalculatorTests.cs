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


    }
}