using System;
using Attributes;


namespace ParametersTests
{
    public class ParametersTests
    {
        [Test]
        public void OneIntParameterTest(int number)
        {
            number += 12;
        }

        [Test]
        public void TwoIntParametersTest(int number1, int number2)
        {
            number1 *= number2;
        }

        [Test]
        public void OneStringParameterTest(string str)
        {
            str += "something";
        }

        [Test]
        public void TwoStringParametersTest(string str1, string str2)
        {
            str1 += str2;
        }

        [Test]
        public void TwoDifferentParametersTest(int number, string str)
        {
            number *= 2;
            str += "string";
        }
    }
}
