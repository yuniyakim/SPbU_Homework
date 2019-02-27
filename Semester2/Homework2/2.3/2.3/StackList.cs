using System;

namespace _2._3
{
    class StackList : IStack
    {
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
                throw new Exception("Stack is empty");
            }
            var pop = stackHead.Value;
            stackHead = stackHead.Next;
            --length;
            return pop;
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        private int length;
        private Node stackHead;
    }
}

// Реализовать стековый калькулятор(класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). 
// Стек реализовать двумя способами(например, массивом или списком) в двух разных классах на основе одного интерфейса.
// Стековый калькулятор должен знать только про интерфейс стека.
