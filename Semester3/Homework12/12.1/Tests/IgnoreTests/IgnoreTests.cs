using System;
using Attributes;

namespace IgnoreTests
{
    public class IgnoreTests
    {
        [Test(Ignore = "First ignore test")]
        public void FirstIgnoreTest()
        {
        }

        [Test(Ignore = "Second ignore test")]
        public void SecondIgnoreTest()
        {
        }
    }
}
