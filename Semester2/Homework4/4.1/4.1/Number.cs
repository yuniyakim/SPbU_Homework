using System;

namespace _4._1
{
    /// <summary>
    /// Number's class
    /// </summary>
    public class Number : INode
    {
        /// <summary>
        /// Number's constructor
        /// </summary>
        /// <param name="number">Number's value</param>
        public Number(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Prints the number
        /// </summary>
        public void Print()
        {
            Console.Write($"{number} ");
        }

        /// <summary>
        /// Gets number's value
        /// </summary>
        /// <returns>Number's value</returns>
        public int Calculate() => number;

        public int number { get; set; }
    }
}
