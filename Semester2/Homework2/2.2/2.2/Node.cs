using System;

namespace _2._2
{
    public class Node
    {
        public string value { get; set; }
        public Node next { get; set; }
        public Node(string value)
        {
            this.value = value;
            next = null;
        }
    }
}
