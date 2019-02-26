using System;

namespace _2._2
{
    class Program
    {
        static void Main()
        {
            HashTable HashTable = new HashTable(50);
            HashTable.Push("Water");
            HashTable.Push("Fire");
            HashTable.Push("Earth");
            HashTable.Push("Air");
            HashTable.Push("Blue");
            HashTable.Push("Red");
            HashTable.Push("Green");
            HashTable.Push("Yellow");
            HashTable.Push("White");
            HashTable.Push("Black");
            if (HashTable.IsContained("Blue"))
            {
                Console.WriteLine("Contained");
            }
            HashTable.Delete("Blue");
            if (!HashTable.IsContained("Blue"))
            {
                Console.WriteLine("Not contained");
            }
            HashTable.Delete("White");
            HashTable.Delete("Water");
            if (!HashTable.IsContained("White"))
            {
                Console.WriteLine("Not contained");
            }
            if (HashTable.IsContained("Fire"))
            {
                Console.WriteLine("Contained");
            }
            HashTable.Push("White");
            if (HashTable.IsContained("White"))
            {
                Console.WriteLine("Contained");
            }
            if (!HashTable.IsContained("Check"))
            {
                Console.WriteLine("Not contained");
            }
        }
    }
}

// Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи.Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность
