using System;

namespace _2._2
{
    class Program
    {
        static void Main()
        {
            var hashTable = new HashTable(50);
            hashTable.Push("Water");
            hashTable.Push("Fire");
            hashTable.Push("Earth");
            hashTable.Push("Air");
            hashTable.Push("Blue");
            hashTable.Push("Red");
            hashTable.Push("Green");
            hashTable.Push("Yellow");
            hashTable.Push("White");
            hashTable.Push("Black");
            if (hashTable.IsContained("Blue"))
            {
                Console.WriteLine("Contained");
            }
            hashTable.Delete("Blue");
            if (!hashTable.IsContained("Blue"))
            {
                Console.WriteLine("Not contained");
            }
            hashTable.Delete("White");
            hashTable.Delete("Water");
            if (!hashTable.IsContained("White"))
            {
                Console.WriteLine("Not contained");
            }
            if (hashTable.IsContained("Fire"))
            {
                Console.WriteLine("Contained");
            }
            hashTable.Push("White");
            if (hashTable.IsContained("White"))
            {
                Console.WriteLine("Contained");
            }
            if (!hashTable.IsContained("Check"))
            {
                Console.WriteLine("Not contained");
            }
        }
    }
}

// Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи.Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность
