using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _8._1
{
    public class GenericListTests
    {
        private GenericList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new GenericList<int>();
        }

        [Test]
        public void IsReadOnlyTest()
        {
            Assert.IsFalse(list.IsReadOnly());
        }
    }
}