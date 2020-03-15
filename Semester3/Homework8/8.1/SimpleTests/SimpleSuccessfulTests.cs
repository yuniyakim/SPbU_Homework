using System;
using Attributes;

namespace SimpleSuccessfulTests
{
    public class SimpleSuccessfulTests
    {
        [Test]
        public void SumTest()
        {
            var sum = 10 + 8;
        }

        [Test]
        public void SubTest()
        {
            var sub = 239 - 107;
        }
    }
}
