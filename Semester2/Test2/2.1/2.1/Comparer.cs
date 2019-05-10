using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1
{
    public class Comparer<T> : IComparer<List<T>>
    {
        public int Compare(List<T> list1, List<T> list2)
        {
            if (list1.Count > list2.Count)
            {
                return 1;
            }
            else if (list1.Count < list2.Count)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
