using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1
{
    public class SortedSet<T>
    {
        private List<T>[] array;

        public void Sort(Comparer<T> comparer)
        {
        }
    }
}

// Реализовать интерфейс IComparer<T> для объектов классов List, сравнивающих 2 объекта по количеству элементов, содержащихся в списке. 
// Реализовать на его основе класс SortedSet, представляющий АТД отсортированное множество. 
// Реализовать приложение, принимающее массивы строк и формирующее объекты класса List, содержащее слова строки, 
// помещающее полученные объекты в объект класса SortedSet и выводящее на экран содержимого созданного множества.