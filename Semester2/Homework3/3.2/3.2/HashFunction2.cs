using System;

namespace _3._2
{
    /// <summary>
    /// Second hash function
    /// </summary>
    public class HashFunction2 : IHash 
    {
        /// <summary>
        /// Hash function calculated by summarizing hash multiplied by const and code of each symbol in the string
        /// </summary>
        /// <param name="value">String which hash code is calculated</param>
        /// <param name="length">Length of hash table</param>
        /// <returns>The value of hash function</returns>
        public int HashFunction(string value, int length)
        {
            const double seed = 1.6237;
            double hash = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                hash = (hash * seed) + value[i];
            }
            return (int)(hash % length);
        }
    }
}
