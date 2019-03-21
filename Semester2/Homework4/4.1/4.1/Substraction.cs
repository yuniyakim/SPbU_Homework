using System;

namespace _4._1
{
    /// <summary>
    /// Substraction's class
    /// </summary>
    public class Substraction : Operation
    {
        /// <summary>
        /// Prints substraction's expression
        /// </summary>
        public override void Print()
        {
            Console.Write("( - ");
            leftChild.Print();
            rigthChild.Print();
            Console.Write(") ");
        }

        /// <summary>
        /// Calculates the result of children's substraction
        /// </summary>
        /// <returns>Substraction's result</returns>
        public override int Calculate() => leftChild.Calculate() - rigthChild.Calculate();
    }
}
