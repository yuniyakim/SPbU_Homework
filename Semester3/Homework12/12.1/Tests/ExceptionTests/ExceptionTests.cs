using System;
using Attributes;

namespace ExceptionTests
{
    public class ExceptionTests
    {
        [Test(Expected = typeof(DivideByZeroException))]
        public void DivideByZeroExceptionPassedTest()
        {
            var zero = 0;
            var x = 14 / zero;
        }

        [Test(Expected = typeof(IndexOutOfRangeException))]
        public void IndexOutOfRangeExceptionTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var element = array[5];
        }

        [Test]
        public void DivideByZeroExceptionFailedTest()
        {
            var zero = 0;
            var y = 1 / zero;
        }
    }
}
