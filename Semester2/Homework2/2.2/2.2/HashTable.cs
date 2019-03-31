using System;

namespace _2._2
{
    public class HashTable
    {
        private int length;
        private List[] buckets;
        public int numberOfElements = 0;

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

        public void Add(string value)
        {
            if (!buckets[Key(value)].IsContainedByValue(value))
            {
                buckets[Key(value)].Add(value, buckets[Key(value)].length + 1);
                ++numberOfElements;
            }
            if (numberOfElements == 2 * buckets.Length)
            {
                length *= 2;
                var newBuckets = new List[length];
                for (int i = 0; i < length; ++i)
                {
                    newBuckets[i] = new List();
                }
                for (int i = 0; i < buckets.Length; ++i)
                {
                    if (!buckets[i].IsEmpty)
                    {
                        var current = buckets[i].head;
                        for (int j = 0; j < buckets[i].length; ++j)
                        {
                            newBuckets[Key(current.value)].Add(current.value, newBuckets[Key(current.value)].length + 1);
                            if (current.next != null)
                            {
                                current = current.next;
                            }
                        }
                    }
                }
                buckets = newBuckets;
            }
        }

        public void Delete(string value)
        {
            if (buckets[Key(value)].IsContainedByValue(value))
            {
                buckets[Key(value)].Delete(buckets[Key(value)].PositionByValue(value));
                --numberOfElements;
            }
        }
    }
}