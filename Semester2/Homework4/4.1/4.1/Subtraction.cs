using System;

namespace _4._1
{
    /// <summary>
    /// Subtraction's class
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Prints subtraction's expression
        /// </summary>
        public override void Print()
        {
            Console.Write("( - ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(") ");
        }

        /// <summary>
        /// Calculates the result of children's subtraction
        /// </summary>
        /// <returns>Subtraction's result</returns>
        public override int Calculate() => LeftChild.Calculate() - RightChild.Calculate();
    }
}
