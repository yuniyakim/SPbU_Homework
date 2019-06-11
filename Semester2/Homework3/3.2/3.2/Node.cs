using System;

namespace _3._2
{
    /// <summary>
    /// Node of the list
    /// </summary>
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }

        /// <summary>
        /// Node's constructor
        /// </summary>
        /// <param name="value">Node's value</param>
        public Node(string value)
        {
            this.Value = value;
            Next = null;
        }
    }
}
