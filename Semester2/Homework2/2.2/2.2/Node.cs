using System;

namespace _2._2
{
    class Node
    {
        public Node(string value, int position)
        {
            this.value = value;
            this.position = position;
            next = null;
        }

        public string Value
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

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
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

        private string value;
        private int position;
        private Node next;
    }
}
