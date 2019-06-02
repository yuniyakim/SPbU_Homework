using System;

namespace _3._2
{
    /// <summary>
    /// First hash function
    /// </summary>
    public class HashFunction1 : IHash
    {
        /// <summary>
        /// Hash function calculated by summarizing codes of each symbol in the string
        /// </summary>
        /// <param name="value">String which hash code is calculated</param>
        /// <param name="length">Length of hash table</param>
        /// <returns>The value of hash function</returns>
        public int HashFunction(string value, int length)
        {
            int hash = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                hash += Math.Abs(value[i]);
            }
            return hash % length;
        }
    }
}
