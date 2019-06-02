using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    /// <summary>
    /// Calculator
    /// </summary>
    public class Calculator
    {
        /*private StackList stack = new StackList();

        /// <summary>
        /// Stack on list
        /// </summary>
        public class StackList
        {
            private Node stackHead;
            public int Length { get; private set; }

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

            /// <summary>
            /// Stack's constructor
            /// </summary>
            public StackList()
            {
                stackHead = null;
                Length = 0;
            }

            /// <summary>
            /// Pushes the specific value into the stack
            /// </summary>
            /// <param name="value">Specific value</param>
            public void Push(int value)
            {
                var newNode = new Node(value);
                newNode.Next = stackHead;
                stackHead = newNode;
                ++Length;
            }

            /// <summary>
            /// Pops the top element from the stack
            /// </summary>
            /// <returns>Top element</returns>
            public int Pop()
            {
                if (Length == 0)
                {
                    throw new InvalidOperationException("Stack is empty");
                }
                var pop = stackHead.Value;
                stackHead = stackHead.Next;
                --Length;
                return pop;
            }
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

        public int Calculate(string str)
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
            if (stack.Length == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Invalid string");
            }
        }*/

        private string firstNumber = "";
        private bool minusBeforeFirst = false;
        private string secondNumber = "";
        private bool minusBeforeSecond = false;
        private string operation = "";
        private string str = "0";

        public string Current() => secondNumber == "" ? firstNumber : secondNumber;

        private void Calculate()
        {
            var result = 0.0;
            var first = (firstNumber == "" ? 0 : Convert.ToDouble(firstNumber));
            if (minusBeforeFirst)
            {
                first = -first;
            }
            var second = (secondNumber == "" ? 0 : Convert.ToDouble(secondNumber));
            if (minusBeforeSecond)
            {
                second = -second;
            }
            switch (operation)
            {
                case "+":
                    {
                        result = first + second;
                        break;
                    }
                case "-":
                    {
                        result = first - second;
                        break;
                    }
                case "*":
                    {
                        result = first * second;
                        break;
                    }
                case "/":
                    {
                        if (second == 0)
                        {
                            throw new DivideByZeroException();
                        }

                        result = first / second;
                        break;
                    }
            }
            firstNumber = Convert.ToString(result);
            minusBeforeFirst = false;
            secondNumber = "";
            minusBeforeSecond = false;
            operation = "";
        }

        public void Number(string number)
        {
            if (operation != "" && firstNumber != "") // maybe debug
            {
                secondNumber += number;
            }
            else
            {
                firstNumber += number;
            }
        }

        public void Operation(string operation)
        {
            this.operation = operation;
            if (secondNumber == "")
            {
                str = (minusBeforeFirst ? str + " " + "-" + firstNumber + " " + operation : str + " " + firstNumber + " " + operation);
            }
            else
            {
                str = (minusBeforeSecond ? str + " " + "-" + secondNumber + " " + operation : str + " " + secondNumber + " " + operation);
                Calculate();
            }
        }

        public void Clear()
        {
            firstNumber = "";
            secondNumber = "";
            operation = "";
            str = "0";
        }

        public void ClearEntry()
        {
            if (operation != "" && firstNumber != "")
            {
                secondNumber = "";
            }
            else
            {
                firstNumber = "";
            }
        }

        public void Backspace()
        {
            if (operation != "" && firstNumber != "") // maybe debug
            {
                if (secondNumber != "")
                {
                    secondNumber = secondNumber.Remove(secondNumber.Length - 1);
                }
            }
            else
            {
                if (firstNumber != "")
                {
                    firstNumber = firstNumber.Remove(firstNumber.Length - 1);
                }
            }
        }

        public void Dot()
        {
            if (operation != "" && firstNumber != "")
            {
                secondNumber += ".";
            }
            else
            {
                firstNumber += ".";
            }
        }

        public void PlusMinus()
        {
            if (operation != "" && firstNumber != "")
            {
                minusBeforeSecond = !minusBeforeSecond;
            }
            else
            {
                minusBeforeFirst = !minusBeforeFirst;
            }
        }

        public void Equality()
        {
            Calculate();
        }
    }
}
