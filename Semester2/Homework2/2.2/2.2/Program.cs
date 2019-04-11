using System;

namespace _2._2
{
    class Program
    {
        static void Main()
        {
            var hashTable = new HashTable(3);
            hashTable.Add("Water");
            hashTable.Add("Fire");
            hashTable.Add("Earth");
            hashTable.Add("Air");
            hashTable.Add("Blue");
            hashTable.Add("Red");
            hashTable.Add("Green");
            hashTable.Add("Yellow");
            hashTable.Add("White");
            hashTable.Add("Black");
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
            hashTable.Add("White");
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
