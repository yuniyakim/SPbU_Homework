using System;
using System.IO;
using NUnit.Framework;

namespace _6._2
{
    public class MapTests
    {
        private Map map;

        [SetUp]
        public void Initialize()
        {
            map = new Map();
        }

        [Test]
        public void ReadAndFillTest()
        {
            var path = Directory.GetCurrentDirectory() + "../../../../6.2.Test.txt";
            map.ReadAndFill(path);
            Assert.AreEqual(map.Field[0, 1], '#');
            Assert.AreEqual(map.Field[0, 6], '.');
            Assert.AreEqual(map.Field[1, 1], '.');
            Assert.AreEqual(map.Field[1, 0], '.');
            Assert.AreEqual(map.Field[2, 2], '#');
            Assert.AreEqual(map.Field[2, 3], '.');
            Assert.AreEqual(map.Field[3, 9], '#');
            Assert.AreEqual(map.Field[4, 9], '.');
            Assert.AreEqual(map.Field[5, 2], '.');
            Assert.AreEqual(map.Field[5, 7], '.');
            Assert.AreEqual(map.Field[6, 2], '.');
            Assert.AreEqual(map.Field[6, 5], '#');
        }
    }
}