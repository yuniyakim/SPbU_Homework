using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _2._2
{
    public class ListIntBubbleSortTests
    {
        private List<int> list = new List<int>();
        private BubbleSort bubbleSort = new BubbleSort();

        /// <summary>
        /// Int comparer
        /// </summary>
        public class IntComparer : IComparer<int>
        {
            public int Compare(int element1, int element2)
            {
                return (element1 > element2) ? 1 : ((element1 < element2) ? -1 : 0);
            }
        }

        [Test]
        public void ListIntBubbleSortTest()
        {
            list.Add(4);
            list.Add(8);
            list.Add(-10);
            list.Add(3);
            list.Add(5);
            list.Add(11);
            list.Add(0);
            list.Add(4);

            var sortedList = new List<int>();
            sortedList.Add(-10);
            sortedList.Add(0);
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