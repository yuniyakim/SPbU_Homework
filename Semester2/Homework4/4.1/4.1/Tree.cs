using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1
{
    /// <summary>
    /// Tree on the nodes
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Node of the tree
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="value">Value to add into the node</param>
            /// <param name="leftChild">Left child of this node</param>
            /// <param name="rigthChild">Rigth child of this node</param>
            public Node(char value, Node leftChild, Node rigthChild)
            {
                this.value = value;
                this.leftChild = leftChild;
                this.rightChild = rigthChild;
            }

            private char value { get; set; }
            private Node leftChild { get; set; }
            private Node rightChild { get; set; }
        }

        public Tree()
        {
            head = null;
        }

        private Node head;
    }
}
