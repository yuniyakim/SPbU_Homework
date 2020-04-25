using System;
using Attributes;

namespace SimpleFailedTests
{
    public class SimpleFailedTests
    {
        public int Number = 0;

        [Before]
        public void Before()
        {
            Number += 12;
        }

        [AfterClass]
        public void AfterClass()
        {
            Number -= 0;
        }

        [Test]
        public void FirstTest()
        {
            Number /= 2;
            throw new Exception();
        }

        [Test]
        public void SecondTest()
        {
            throw new Exception();
        }
    }
}
