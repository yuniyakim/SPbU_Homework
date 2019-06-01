using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1
{
    /// <summary>
    /// Compare
    /// </summary>
    public class Comparer<T> : IComparer<List<T>>
    {
        /// <summary>
        /// Compares the length of two lists
        /// </summary>
        /// <param name="list1">First list</param>
        /// <param name="list2">Second list</param>
        /// <returns>1 if length of first is larger than second's, -1 if length of first is smaller than second's, 0 if equal</returns>
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
