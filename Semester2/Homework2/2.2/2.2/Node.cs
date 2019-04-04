using System;

namespace _2._2
{
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
        public Node(string value)
        {
            this.Value = value;
            Next = null;
        }
    }
}
