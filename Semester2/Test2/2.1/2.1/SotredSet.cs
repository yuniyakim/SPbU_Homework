using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1
{
    /// <summary>
    /// Sorted set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortedSet<T>
    {
        public List<string>[] Array { get; private set; } = new List<string>[50];
        private int amount = 0;

        /// <summary>
        /// Sorted set's constructor
        /// </summary>
        public SortedSet()
        {
            for (int i = 0; i < 50; ++i)
            {
                Array[i] = new List<string>();
            }
        }

        /// <summary>
        /// Fills array from input array
        /// </summary>
        /// <param name="str">Input array</param>
        public void Fill(string[] str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] != null)
                {
                    string[] split = str[i].Split(' ');
                    foreach (string s in split)
                    {
                        if (s != null && s != "")
                        {
                            Array[i].Add(s);
                        }
                    }
                    ++amount;
                }
            }
        }

        /// <summary>
        /// Sorts lists in array
        /// </summary>
        public void Sort()
        {
            var comparer = new Comparer<string>();
            var index = 0;
            for (int i = 0; i < amount * amount; ++i)
            {
                if (comparer.Compare(Array[index], Array[index + 1]) < 0)
                {
                    Swap(index, index + 1);
                }
                ++index;
                if (index == amount)
                {
                    index = 0;
                }
            }
        }

        /// <summary>
        /// Swaps two lists
        /// </summary>
        /// <param name="number1">First list's number in array</param>
        /// <param name="number2">Second list's number in array</param>
        private void Swap(int number1, int number2)
        {
            var temp = Array[number1];
            Array[number1] = Array[number2];
            Array[number2] = temp;
        }

        /// <summary>
        /// Prints sorted set
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < amount; ++i)
            {
                foreach (var str in Array[i])
                {
                    Console.Write(str);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }
    }
}

// Реализовать интерфейс IComparer<T> для объектов классов List, сравнивающих 2 объекта по количеству элементов, содержащихся в списке. 
// Реализовать на его основе класс SortedSet, представляющий АТД отсортированное множество. 
// Реализовать приложение, принимающее массивы строк и формирующее объекты класса List, содержащее слова строки, 
// помещающее полученные объекты в объект класса SortedSet и выводящее на экран содержимого созданного множества.