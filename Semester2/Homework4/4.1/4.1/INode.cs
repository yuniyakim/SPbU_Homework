using System;

namespace _4._1
{
    /// <summary>
    /// Interface of a node in a tree
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Prints node's value
        /// </summary>
        void Print();

        /// <summary>
        /// Calculates the result
        /// </summary>
        /// <returns>The result of calculation</returns>
        int Calculate();
    }
}
