using System;

namespace _3._1
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
                var newStack = new int[size * 2];
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

        public bool IsEmpty() => length == 0;

        public int Length() => length;

        public void Clear()
        {
            for (int i = 0; i < length; ++i)
            {
                stackArray[i] = 0;
            }
            length = 0;
        }
    }
}

// Реализовать стековый калькулятор(класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). 
// Стек реализовать двумя способами(например, массивом или списком) в двух разных классах на основе одного интерфейса.
// Стековый калькулятор должен знать только про интерфейс стека.
