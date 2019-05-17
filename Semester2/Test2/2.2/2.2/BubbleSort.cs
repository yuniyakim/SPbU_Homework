using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    public class BubbleSort
    {
        public List<T> Sort<T>(List<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = 1; j < list.Count - 1; ++j)
                {
                    if (comparer.Compare(list[j], list[j - 1]) < 0)
                    {
                        Swap(list[j], list[j - 1]);
                    }
                }
            }

            return list;
        }

        private void Swap<T>(T element1, T element2)
        {
            var temp = element1;
            element1 = element2;
            element2 = temp;
        }
    }
}

// Реализовать generic метод пузырьковой сортировки. Метод должен принимать список объектов произвольного типа и объект, позволяющий их сравнивать. 
// Результатом должен быть список, отсортированный в соответствии с порядком, заданным объектом-компаратором.