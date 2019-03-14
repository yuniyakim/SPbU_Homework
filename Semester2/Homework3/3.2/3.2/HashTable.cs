using System;

namespace _3._2
{
    /// <summary>
    /// Hash table on the array of lists
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Constructor of hash table
        /// </summary>
        /// <param name="length">Length of hash table</param>
        /// <param name="hash">Chosen hash function</param>
        public HashTable(int length, IHash hash)
        {
            this.length = length;
            buckets = new List[length];
            for (int i = 0; i < length; ++i)
            {
                buckets[i] = new List();
            }
            this.hash = hash;
        }

        /// <summary>
        /// Checks if the element with given value is contained in hash table
        /// </summary>
        /// <param name="value">Value on which containment is checked</param>
        /// <returns>True if the element is contained and false if it's not</returns>
        public bool IsContained(string value)
        {
            return buckets[hash.HashFunction(value, length)].IsContainedByValue(value);
        }

        /// <summary>
        /// Adds the element into hash table
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Push(string value)
        {
            buckets[hash.HashFunction(value, length)].Push(value, 1);
        }

        /// <summary>
        /// Deletes the element from hash table
        /// </summary>
        /// <param name="value">Value to delete</param>
        public void Delete(string value)
        {
            buckets[hash.HashFunction(value, length)].Delete(buckets[hash.HashFunction(value, length)].PositionByValue(value));
        }

        private int length;
        private List[] buckets;
        private IHash hash;
    }
}

// Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи.Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность
// Модифицировать хеш-таблицу из задачи 2 предыдущей работы так, чтобы хеш-функцию можно было менять в зависимости от выбора пользователя, 
// причём хеш-функцию должно быть можно передавать из использующего хеш-таблицу кода в виде объекта некоторого класса, 
// реализующего некоторый интерфейс. Юнит-тесты и коментарии в формате XML Documentation обязательны.