using System;

namespace _2._2
{
    public class HashTable
    {
        private int length;
        private List[] buckets;
        private int numberOfElements = 0;

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

        private void Resize()
        {
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
                        var current = buckets[i].Head;
                        for (int j = 0; j < buckets[i].Length; ++j)
                        {
                            newBuckets[Key(current.Value)].Add(current.Value, newBuckets[Key(current.Value)].Length + 1);
                            if (current.Next != null)
                            {
                                current = current.Next;
                            }
                        }
                    }
                }
                buckets = newBuckets;
            }
        }

        public bool IsContained(string value) => buckets[Key(value)].IsContainedByValue(value);

        public void Add(string value)
        {
            if (!buckets[Key(value)].IsContainedByValue(value))
            {
                buckets[Key(value)].Add(value, buckets[Key(value)].Length + 1);
                ++numberOfElements;
            }
        }

        public void Delete(string value)
        {
            if (buckets[Key(value)].IsContainedByValue(value))
            {
                buckets[Key(value)].Delete(buckets[Key(value)].PositionByValue(value));
                --numberOfElements;
            }
            Resize();
        }
    }
}