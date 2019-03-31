using System;

namespace _2._2
{
    public class HashTable
    {
        private int length;
        private List[] buckets;

        public HashTable(int length)
        {
            this.length = length;
            buckets = new List[length];
            for (int i = 0; i < length; ++i)
            {
                buckets[i] = new List();
            }
        }

        private int Key(string value) => Math.Abs(value.GetHashCode() % length);

        public bool IsContained(string value) => buckets[Key(value)].IsContainedByValue(value);

        public void Add(string value) => buckets[Key(value)].Add(value, 1);

        public void Delete(string value) => buckets[Key(value)].Delete(buckets[Key(value)].PositionByValue(value));
    }
}