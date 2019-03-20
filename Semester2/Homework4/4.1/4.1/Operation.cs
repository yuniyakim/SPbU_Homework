using System;

namespace _4._1
{
    /// <summary>
    /// Arithmetic operation's class
    /// </summary>
    abstract class Operation : INode
    {
        /// <summary>
        /// Prints the operation
        /// </summary>
        public abstract void Print();

        /// <summary>
        ///  Calculates the result of arithmetic action with this node's children
        /// </summary>
        /// <returns>The result of calculation</returns>
        public abstract int Calculate();

        public INode leftChild { get; set; }
        public INode rigthChild { get; set; }
    }
}
