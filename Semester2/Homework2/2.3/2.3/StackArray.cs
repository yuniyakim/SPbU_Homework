using System;

namespace _2._3
{
    class StackArray : IStack
    {
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
                throw new Exception("Stack is empty");
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

        private int size = 10;
        private int length;
        private int[] stackArray;
    }
}

// Реализовать стековый калькулятор(класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). 
// Стек реализовать двумя способами(например, массивом или списком) в двух разных классах на основе одного интерфейса.
// Стековый калькулятор должен знать только про интерфейс стека.
