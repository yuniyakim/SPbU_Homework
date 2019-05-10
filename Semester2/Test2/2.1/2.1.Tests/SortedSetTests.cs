using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _2._1
{
    public class SortedSetTests
    {
        private SortedSet<string> sortedSet = new SortedSet<string>();
        private string[] array;

        [SetUp]
        public void Setup()
        {
            array = new string[7];
            array[0] = "";
            array[1] = "c d e";
            array[2] = " f g h i";
            array[3] = "j   k";
            array[4] = "l m n ! ! !";
            array[5] = "o    p   q r s  ";
            array[6] = "t    ";
        }

        [Test]
        public void FillTest()
        {
            sortedSet.Fill(array);
            Assert.AreEqual(0, sortedSet.Array[0].Count);
            Assert.AreEqual(3, sortedSet.Array[1].Count);
            Assert.AreEqual(4, sortedSet.Array[2].Count);
            Assert.AreEqual(2, sortedSet.Array[3].Count);
            Assert.AreEqual(6, sortedSet.Array[4].Count);
            Assert.AreEqual(5, sortedSet.Array[5].Count);
            Assert.AreEqual(1, sortedSet.Array[6].Count);
        }

        [Test]
        public void SortTest()
        {
            sortedSet.Fill(array);
            sortedSet.Sort();
            Assert.AreEqual(6, sortedSet.Array[0].Count);
            Assert.AreEqual(5, sortedSet.Array[1].Count);
            Assert.AreEqual(4, sortedSet.Array[2].Count);
            Assert.AreEqual(3, sortedSet.Array[3].Count);
            Assert.AreEqual(2, sortedSet.Array[4].Count);
            Assert.AreEqual(1, sortedSet.Array[5].Count);
            Assert.AreEqual(0, sortedSet.Array[6].Count);
        }
    }
}