using System;

namespace _3._1
{
    public class StackList : IStack
    {
        private int length;
        private Node stackHead;

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                this.Value = value;
                Next = null;
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
            newNode.Next = stackHead;
            stackHead = newNode;
            ++length;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var pop = stackHead.Value;
            stackHead = stackHead.Next;
            --length;
            return pop;
        }

        public bool IsEmpty() => length == 0;

        public int Length() => length;

        public void Clear()
        {
            stackHead = null;
            length = 0;
        }
    }
}

// Реализовать стековый калькулятор(класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). 
// Стек реализовать двумя способами(например, массивом или списком) в двух разных классах на основе одного интерфейса.
// Стековый калькулятор должен знать только про интерфейс стека.
