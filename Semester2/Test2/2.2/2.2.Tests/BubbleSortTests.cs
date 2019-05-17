using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _2._2
{
    public class ListIntBubbleSortTests
    {
        public class IntComparer : IComparer<int>
        {
            public int Compare(int element1, int element2)
            {
                return (element1 > element2) ? 1 : ((element1 < element2) ? -1 : 0);
            }
        }

        private List<int> list = new List<int>();
        private BubbleSort bubbleSort = new BubbleSort();

        [SetUp]
        public void Setup()
        {
            list.Add(4);
            list.Add(8);
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(11);
            list.Add(2);
            list.Add(4);
        }

        [Test]
        public void ListIntBubbleSortTest()
        {
            var sortedList = new List<int>();
            sortedList.Add(1);
            sortedList.Add(2);
            sortedList.Add(3);
            sortedList.Add(4);
            sortedList.Add(4);
            sortedList.Add(5);
            sortedList.Add(8);
            sortedList.Add(11);
            var newlist = bubbleSort.Sort<int>(list, new IntComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], newlist[i]);
            }
        }
    }
}