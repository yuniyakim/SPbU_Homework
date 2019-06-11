using System;

namespace _4._1
{
    /// <summary>
    /// Arithmetic operation's class
    /// </summary>
    public abstract class Operation : INode
    {
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }

        /// <summary>
        /// Prints the operation
        /// </summary>
        public abstract void Print();

        /// <summary>
        ///  Calculates the result of arithmetic action with this node's children
        /// </summary>
        /// <returns>The result of calculation</returns>
        public abstract int Calculate();
    }
}
