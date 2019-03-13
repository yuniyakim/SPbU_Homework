using System;

namespace _3._1
{
    public class Calculator
    {
        public Calculator(IStack stack)
        {
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
                    switch (str[i])
                    {
                        case '+':
                            {
                                stack.Push(value1 + value2);
                                break;
                            }
                        case '-':
                            {
                                stack.Push(value2 - value1);
                                break;
                            }
                        case '*':
                            {
                                stack.Push(value1 * value2);
                                break;
                            }
                        case '/':
                            {
                                if (value1 == 0)
                                {
                                    throw new InvalidOperationException("Division by zero");
                                }
                                stack.Push(value2 / value1);
                                break;
                            }
                    }
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
