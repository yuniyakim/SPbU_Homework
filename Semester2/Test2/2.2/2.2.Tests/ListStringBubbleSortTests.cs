using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace _2._2
{
    public class ListStringBubbleSortTests
    {
        private List<string> list = new List<string>();
        private BubbleSort bubbleSort = new BubbleSort();

        /// <summary>
        /// String comparer
        /// </summary>
        public class StringComparer : IComparer<string>
        {
            public int Compare(string element1, string element2)
            {
                return string.Compare(element1, element2);
            }
        }

        [Test]
        public void ListIntBubbleSortTest()
        {
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            list.Add("six");
            list.Add("seven");
            list.Add("eight");
            list.Add("");

            var sortedList = new List<string>();
            sortedList.Add("");
            sortedList.Add("eight");
            sortedList.Add("five");
            sortedList.Add("four");
            sortedList.Add("one");
            sortedList.Add("seven");
            sortedList.Add("six");
            sortedList.Add("three");
            sortedList.Add("two");

            var newlist = bubbleSort.Sort<string>(list, new StringComparer());
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], newlist[i]);
            }
        }
    }
}
