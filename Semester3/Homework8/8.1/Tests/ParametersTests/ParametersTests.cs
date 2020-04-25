using System;
using Attributes;


namespace ParametersTests
{
    public class ParametersTests
    {
        [Test]
        public void OneParameterTest(int number)
        {
            number += 12;
        }

        [Test]
        public void TwoParametersTest(int number1, int number2)
        {
            number1 *= number2;
        }
    }
}
