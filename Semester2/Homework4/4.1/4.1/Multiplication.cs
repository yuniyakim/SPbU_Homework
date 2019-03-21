using System;

namespace _4._1
{
    /// <summary>
    /// Multiplication's class
    /// </summary>
    public class Multiplication : Operation
    {
        /// <summary>
        /// Prints multiplication's expression
        /// </summary>
        public override void Print()
        {
            Console.Write("( * ");
            leftChild.Print();
            rigthChild.Print();
            Console.Write(") ");
        }

        /// <summary>
        /// Calculates the result of children's multiplication
        /// </summary>
        /// <returns>Multiplication's result</returns>
        public override int Calculate() => leftChild.Calculate() * rigthChild.Calculate();
    }
}
