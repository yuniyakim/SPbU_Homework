using System;

namespace _4._1
{
    /// <summary>
    /// Division's class
    /// </summary>
    class Division : Operation
    {
        /// <summary>
        /// Prints division's expression
        /// </summary>
        public override void Print()
        {
            Console.Write("( / ");
            leftChild.Print();
            rigthChild.Print();
            Console.Write(") ");
        }

        /// <summary>
        /// Calculates the result of children's division
        /// </summary>
        /// <returns>Division's result</returns>
        public override int Calculate() => leftChild.Calculate() / rigthChild.Calculate();
    }
}
