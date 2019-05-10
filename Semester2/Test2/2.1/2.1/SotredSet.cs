using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1
{
    public class SortedSet<T>
    {
        private List<string>[] array = new List<string>[50];

        public SortedSet()
        {
            for (int i = 0; i < 50; ++i)
            {
                array[i] = new List<string>();
            }
        }

        public void ReadAndInsert(string[] str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] != null)
                {
                    string[] split = str[i].Split(' ');
                    foreach (string s in split)
                    {
                        if (s != null)
                        {
                            array[i].Add(s);
                        }
                    }
                }
            }
        }

        public void Sort()
        {
            var comparer = new Comparer<string>();
            var index = 0;
            for (int i = 0; i < array.Length * array.Length; ++i)
            {
                if (comparer.Compare(array[index], array[index + 1]) > 1)
                {
                    Swap(array[index], array[index + 1]);
                }
                ++index;
                if (index == array.Length)
                {
                    index = 0;
                }
            }
        }

        private void Swap(List<string> list1, List<string> list2)
        {
            var temp = list1;
            list1 = list2;
            list2 = temp;
        }

        public void Print()
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i].ForEach(Console.Write);
                Console.Write(" "); // needed?
            }
            Console.WriteLine();
        }
    }
}

// Реализовать интерфейс IComparer<T> для объектов классов List, сравнивающих 2 объекта по количеству элементов, содержащихся в списке. 
// Реализовать на его основе класс SortedSet, представляющий АТД отсортированное множество. 
// Реализовать приложение, принимающее массивы строк и формирующее объекты класса List, содержащее слова строки, 
// помещающее полученные объекты в объект класса SortedSet и выводящее на экран содержимого созданного множества.