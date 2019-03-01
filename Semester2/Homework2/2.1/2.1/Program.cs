using System;

namespace _2._1
{
    class Program
    {
        static void Main()
        {
            var list = new List();
            if (list.IsEmpty)
            {
                Console.WriteLine("Empty");
            }
            list.Delete(4);
            list.Push("one", 4);
            list.Delete(2);
            if (!list.IsEmpty)
            {
                Console.WriteLine("Not empty");
            }
            list.Push("three", 2);
            list.Print();
            Console.WriteLine($"Length is {list.Length}");
            list.Push("four", 1);
            list.Push("five", 3);
            list.Delete(1);
            list.Push("one", 3);
            list.Delete(4);
            list.Push("six", 2);
            list.Push("two", 7);
            list.Print();
            list.Push("seven", 5);
            Console.WriteLine($"Length is {list.Length}");
            list.Delete(4);
            if (list.IsContained(4))
            {
                Console.WriteLine("Contained");
            }
            list.Print();
            list.SetValue("check", 3);
            list.SetValue("one-one", 1);
            list.GetValue(2);
            list.GetValue(1);
            list.GetValue(4);
            if (!list.IsContained(7))
            {
                Console.WriteLine("Not contained");
            }
            list.Print();
        }
    }
}

/* Написать связный список в виде класса. От списка хочется:
- Добавлять/удалять элемент по произвольной позиции, задаваемой целым числом
- Узнавать размер, проверять на пустоту
- Получать или устанавливать значение элемента по позиции, задаваемой целым числом */
