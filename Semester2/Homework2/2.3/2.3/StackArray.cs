using System;

namespace _2._3
{
    class StackArray : IStack
    {
        private int size = 10;
        private int length;
        private int[] stackArray;

        public StackArray()
        {
            length = 0;
            stackArray = new int[size];
        }

        public void Push(int value)
        {
            if (length == size)
            {
                int[] newStack = new int[size * 2];
                size *= 2;
                stackArray.CopyTo(newStack, 0);
                stackArray = newStack;
            }
            stackArray[length] = value;
            ++length;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var pop = stackArray[length - 1];
            stackArray[length - 1] = 0;
            --length;
            return pop;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }
    }
}