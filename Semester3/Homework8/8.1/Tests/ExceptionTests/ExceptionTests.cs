using System;
using Attributes;

namespace ExceptionTests
{
    public class ExceptionTests
    {
        [Test(Expected = typeof(DivideByZeroException))]
        public void DivideByZeroExceptionTest()
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
    }
}
