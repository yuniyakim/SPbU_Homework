using System;

namespace _2._3
{
    public class Calculator
    {
        public Calculator(IStack stack)
        {
        }

        private int OparationResult(char operation, int value1, int value2)
        {
            switch (operation)
            {
                case '+':
                    {
                        return value1 + value2;
                    }
                case '-':
                    {
                        return value2 - value1;
                    }
                case '*':
                    {
                        return value1 * value2;
                    }
                case '/':
                    {
                        if (value1 == 0)
                        {
                            throw new InvalidOperationException("Division by zero");
                        }
                        return value2 / value1;
                    }
                default:
                    {
                        throw new InvalidOperationException("Invalid Operation");
                    }
            }
        }

        public int Calculate(IStack stack, string str)
        {
            var number = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == ' ')
                {
                    continue;
                }
                else if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    var value1 = stack.Pop();
                    var value2 = stack.Pop();
                    stack.Push(OparationResult(str[i], value1, value2));
                }
                else if (i < str.Length - 1 && Char.IsNumber(str[i]) && Char.IsNumber(str[i + 1]))
                {
                    number = number * 10 + (int)Char.GetNumericValue(str[i]);
                }
                else if (i > 0 && Char.IsNumber(str[i - 1]) && Char.IsNumber(str[i]))
                {
                    number = number * 10 + (int)Char.GetNumericValue(str[i]);
                    stack.Push(number);
                    number = 0;
                }
                else
                {
                    stack.Push((int)Char.GetNumericValue(str[i]));
                }
            }
            return stack.Pop();
        }
    }
}
