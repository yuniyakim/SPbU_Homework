using System;

namespace _2._2
{
    class HashTable
    {
        public HashTable(int length)
        {
            this.length = length;
            buckets = new List[length];
            for (int i = 0; i < length; ++i)
            {
                buckets[i] = new List();
            }
        }

        public bool IsContained(string value)
        {
            return buckets[Math.Abs(value.GetHashCode() % length)].IsContainedByValue(value);
        }

        public void Push(string value)
        {
            buckets[Math.Abs(value.GetHashCode() % length)].Push(value, 1);
        }

        public void Delete(string value)
        {
            buckets[Math.Abs(value.GetHashCode() % length)].Delete(buckets[Math.Abs(value.GetHashCode() % length)].PositionByValue(value));
        }

        private int length;
        private List[] buckets;
    }
}

// Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи.Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность
