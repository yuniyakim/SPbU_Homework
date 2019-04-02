using System;

namespace _2._3
{
    class StackList : IStack
    {
        private int length;
        private Node stackHead;

        private class Node
        {
            public int value { get; set; }
            public Node next { get; set; }

            public Node(int value)
            {
                this.value = value;
                next = null;
            }
        }
        public StackList()
        {
            stackHead = null;
            length = 0;
        }

        public void Push(int value)
        {
            var newNode = new Node(value);
            newNode.next = stackHead;
            stackHead = newNode;
            ++length;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var pop = stackHead.value;
            stackHead = stackHead.next;
            --length;
            return pop;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }
    }
}