using System;

namespace _3._1
{
    class Program
    {
        static void Main()
        {
            int input = 0;
            do
            {
                Console.WriteLine("Enter 1 for stack on list");
                Console.WriteLine("Enter 2 for stack on array");
                input = int.Parse(Console.ReadLine());
            }
            while (input  != 1 && input != 2);
            var stackList = new StackList();
            var stackArray = new StackArray();
            Console.WriteLine("Enter postfix expression");
            var str = Console.ReadLine();
            int result = 0;
            if (input == 1)
            {
                var calculator = new Calculator(stackList);
                result = calculator.Calculate(stackList, str);
            }
            else
            {
                var calculator = new Calculator(stackArray);
                result = calculator.Calculate(stackArray, str);
            }
            Console.WriteLine($"Result: {result}");
        }
    }
}

// Реализовать стековый калькулятор(класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). 
// Стек реализовать двумя способами(например, массивом или списком) в двух разных классах на основе одного интерфейса.
// Стековый калькулятор должен знать только про интерфейс стека.
