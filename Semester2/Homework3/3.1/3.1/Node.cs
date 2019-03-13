using System;

namespace _3._1
{
    class Node
    {
        public Node(int value)
        {
            this.value = value;
            next = null;
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        private int value;
        private Node next;
    }
}