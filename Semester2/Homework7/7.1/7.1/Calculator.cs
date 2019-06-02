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
        private string firstNumber = "";
        private bool minusBeforeFirst = false;
        private string secondNumber = "";
        private bool minusBeforeSecond = false;
        private string operation = "";

        public string InputString { get; set; } = "";

        public string Input() => (secondNumber == "" && operation == "") ? (minusBeforeFirst ? "-" + firstNumber : firstNumber) 
            : (minusBeforeSecond ? "-" + secondNumber : secondNumber);

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
                secondNumber = (secondNumber.Count() == 1 && secondNumber == "0") ? number : secondNumber + number;
            }
            else
            {
                firstNumber = (firstNumber.Count() == 1 && firstNumber == "0") ? number : firstNumber + number;
            }
        }

        public void Operation(string operation)
        {
            this.operation = operation;
            if (secondNumber == "")
            {
                InputString = (minusBeforeFirst ? InputString + " " + "-" + firstNumber + " " + operation : InputString + " " + firstNumber + " " + operation);
            }
            else
            {
                InputString = (minusBeforeSecond ? InputString + " " + "-" + secondNumber + " " + operation : InputString + " " + secondNumber + " " + operation);
                Calculate();
            }
        }

        public void Clear()
        {
            firstNumber = "";
            secondNumber = "";
            minusBeforeFirst = false;
            minusBeforeSecond = false;
            operation = "";
            InputString = "0";
        }

        public void ClearEntry()
        {
            if (operation != "" && firstNumber != "")
            {
                secondNumber = "";
                minusBeforeSecond = false;
            }
            else
            {
                firstNumber = "";
                minusBeforeFirst = false;
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
            if (operation != "" && firstNumber != "" && secondNumber != "" && !secondNumber.Contains("."))
            {
                secondNumber += ".";
            }
            else if (firstNumber != "" && !firstNumber.Contains("."))
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
            InputString = "";
        }
    }
}
