using System;

namespace _7._1
{
    /// <summary>
    /// Calculator
    /// </summary>
    public class Calculator
    {
        public string WholeInput { get; private set; } = "";
        public string Input { get; private set; } = "0";
        private bool isEqualityPressed = false;
        private bool isOperationPressed = false;
        private string[] expression = new string[3];

        /// <summary>
        /// Calculates the result of expression
        /// </summary>
        private void Calculate()
        {
            if (!double.TryParse(WholeInput, out double input))
            {
                if (expression[0] == null)
                {
                    expression = WholeInput.Split(' ');
                }
                else
                {
                    var newWholeInput = WholeInput.Substring(WholeInput.LastIndexOfAny(new char[] { '+', '-', '*', '/' }));
                    newWholeInput.Split(' ').CopyTo(expression, 1);
                }
                var result = 0.0;
                var first = Convert.ToDouble(expression[0]);
                var second = Convert.ToDouble(expression[2]);
                switch (expression[1])
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
                Input = result.ToString();
                expression[0] = result.ToString();
                expression[1] = null;
                expression[2] = null;
            }
        }

        /// <summary>
        /// Processes the pressed number
        /// </summary>
        /// <param name="number">Pressed number</param>
        public void Number(string number)
        {
            if ((Input.Length == 1 && Input[0] == '0') || isEqualityPressed || isOperationPressed)
            {
                Input = number;
                isEqualityPressed = false;
                isOperationPressed = false;
            }
            else
            {
                Input = Input + number;
            }
        }

        /// <summary>
        /// Processes the pressed operation
        /// </summary>
        /// <param name="operation">Pressed operation</param>
        public void Operation(string operation)
        {
            if (!WholeInput.Contains("+") && !WholeInput.Contains("-") && !WholeInput.Contains("*") && !WholeInput.Contains("/"))
            {
                WholeInput = Input + " " + operation;
                isEqualityPressed = false;
            }
            else if (isOperationPressed && (WholeInput[WholeInput.Length - 1] == '+' || WholeInput[WholeInput.Length - 1] == '-' 
                || WholeInput[WholeInput.Length - 1] == '*' || WholeInput[WholeInput.Length - 1] == '/'))
            {
                WholeInput = WholeInput.Remove(WholeInput.Length - 1).Insert(WholeInput.Length - 1, operation);
            }
            else
            {
                WholeInput = WholeInput + " " + Input;
                Calculate();
                WholeInput = WholeInput + " " + operation;
            }
            isOperationPressed = true;
        }

        /// <summary>
        /// Clears everything
        /// </summary>
        public void Clear()
        {
            WholeInput = "";
            Input = "0";
            expression[0] = null;
            expression[1] = null;
            expression[2] = null;
        }

        /// <summary>
        /// Clears entry
        /// </summary>
        public void ClearEntry()
        {
            Input = "0";
        }

        /// <summary>
        /// Deletes the last character of entry
        /// </summary>
        public void Backspace()
        {
            if (Input.Length == 1)
            {
                Input = "0";
            }
            else
            {
                Input = Input.Remove(Input.Length - 1);
            }
        }

        /// <summary>
        /// Adds a dot to entry
        /// </summary>
        public void Dot()
        {
            if (Input[Input.Length - 1] != '.' && !Input.Contains("."))
            {
                Input += ".";
                isEqualityPressed = false;
                isOperationPressed = false;
            }
        }

        /// <summary>
        /// Changes entry's sign
        /// </summary>
        public void PlusMinus()
        {
            if (Input != "0")
            {
                if (Input[0] != '-')
                {
                    Input = "-" + Input;
                }
                else
                {
                    Input = Input.Substring(1);
                }
            }
        }

        /// <summary>
        /// Calculates the result and clears needed fields
        /// </summary>
        public void Equality()
        {
            WholeInput = WholeInput + ' ' + Input;
            Calculate();
            WholeInput = "";
            isEqualityPressed = true;
            expression[0] = null;
        }
    }
}
