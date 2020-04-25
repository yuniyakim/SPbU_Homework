using System;
using Attributes;

namespace SimpleSucceededlTests
{
    public class SimpleSucceededTests
    {
        public int Number1 = 0;
        public int Number2 = 0;

        [BeforeClass]
        public void BeforeClass()
        {
            Number1 += 4;
            Number2 -= 7;
        }

        [Before]
        public void Before()
        {
            Number1 /= 2;
            Number2 *= 4;
        }

        [AfterClass]
        public void AfterClass()
        {
            Number1 -= 0;
            Number2 -= 1;
        }

        [After]
        public void After()
        {
            Number1 *= 2;
            Number2 += 4;
        }

        [Test]
        public void FirstTest()
        {
            Number1 += 10;
            Number2 += 5;
        }

        [Test]
        public void SecondTest()
        {
            Number1 -= 1;
            Number2 *= 0;
        }

        [Test]
        public void ThirdTest()
        {
            Number1 += -9;
            Number2 /= 2;
        }
    }
}
