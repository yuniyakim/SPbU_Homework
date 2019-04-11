using System;
using System.Collections.Generic;

namespace _6._1
{
    /// <summary>
    /// Class of Map, Filter and Fold functions
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Map function
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="func">Given function</param>
        /// <returns>A list with elements calculated` with given function</returns>
        public static List<int> Map(List<int> list, Func<int, int> func)
        {
            var newList = new List<int>();
            foreach (var element in list)
            {
                newList.Add(func(element));
            }
            return newList;
        }

        /// <summary>
        /// Filter function
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="func">Given function</param>
        /// <returns>A list with elements that returned true</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            var newList = new List<int>();
            foreach (var element in list)
            {
                if (func(element))
                {
                    newList.Add(element);
                }
            }
            return newList;
        }

        /// <summary>
        /// Fold function
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="initial">Initial value</param>
        /// <param name="func">Given function</param>
        /// <returns>Accumulated value</returns>
        public static int Fold(List<int> list, int initial, Func<int, int, int> func)
        {
            var result = initial;
            foreach (var element in list)
            {
                result = func(result, element);
            }
            return result;
        }
    }
}

// Реализовать функции Map, Filter и Fold:

// Map принимает список и функцию, преобразующую элемент списка.
// Возвращаться должен список, полученный применением переданной функции к каждому элементу переданного списка.
// Например, Map(new List<int>() {1, 2, 3}, x => x* 2) должен возвращать список[2; 4; 6].

// Filter принимает список и функцию, возвращающую булевое значение по элементу списка.
// Возвращаться должен список, составленный из тех элементов переданного списка, для которых переданная функция вернула true.

// Fold принимает список, начальное значение и функцию, которая берёт текущее накопленное значение и текущий элемент списка, 
// и возвращает следующее накопленное значение.Сама Fold возвращает накопленное значение, получившееся после всего прохода списка.
// Например, Fold(new List<int>() {1, 2, 3}, 1, (acc, elem) => acc* elem) работала бы так: сначала в acc клался бы 1, 
// потом умножался бы на 1, потом результат(1) умножался бы на 2, потом результат(2) умножался бы на 3, 
// потом результат(6) возвращался бы в качестве ответа
