using System;

namespace _3._2
{
    /// <summary>
    /// Interface of hash function
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Calculation of hash function
        /// </summary>
        /// <param name="value">String which hash code is calculated</param>
        /// <param name="length">Length of hash table</param>
        /// <returns>The value of hash function</returns>
        int HashFunction(string value, int length);
    }
}
