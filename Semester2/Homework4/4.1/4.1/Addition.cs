using System;

namespace _4._1
{
    /// <summary>
    /// Addition's class
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Prints addition's expression
        /// </summary>
        public override void Print()
        {
            Console.Write("( + ");
            leftChild.Print();
            rigthChild.Print();
            Console.Write(") ");
        }

        /// <summary>
        /// Calculates the result of children's addition
        /// </summary>
        /// <returns>Addition's result</returns>
        public override int Calculate() => leftChild.Calculate() + rigthChild.Calculate();
    }
}
