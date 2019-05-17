using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    /// <summary>
    /// Bubble sort
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// Sorts the list
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <param name="comparer">Given comparer</param>
        /// <returns>Sorted list</returns>
        public List<T> Sort<T>(List<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = 0; j < list.Count - 1; ++j)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Swaps two elements
        /// </summary>
        /// <param name="index1">First element's index</param>
        /// <param name="index2">Second element's index</param>
        private void Swap<T>(List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}

// Реализовать generic метод пузырьковой сортировки. Метод должен принимать список объектов произвольного типа и объект, позволяющий их сравнивать. 
// Результатом должен быть список, отсортированный в соответствии с порядком, заданным объектом-компаратором.