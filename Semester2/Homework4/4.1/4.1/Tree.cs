using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1
{
    /// <summary>
    /// Tree on the nodes
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Checks if the tree is empty
        /// </summary>
        /// <returns>True if the tree is empty and false if it's not</returns>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// Prints the tree
        /// </summary>
        public void Print() => head.Print();

        /// <summary>
        /// Calculates the result of the whole tree's calculation
        /// </summary>
        /// <returns>Calculation's result</returns>
        public int Calculate() => head.Calculate();

        /// <summary>
        /// Defines an operation
        /// </summary>
        /// <param name="operation">Given operation</param>
        /// <returns>New node of given operation</returns>
        private Operation DefineOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                    return new Addition();
                case '-':
                    return new Substraction();
                case '*':
                    return new Multiplication();
                case '/':
                    return new Division();
                default:
                    throw new InvalidInputException("Invalid input");
            }
        }

        /// <summary>
        /// Creates the filled tree
        /// </summary>
        /// <param name="expression">Arithmetic expression</param>
        public Tree(string str)
        {
            var expression = new String(str);
            head = FillTree(expression);
        }

        private class String
        {
            public String(string str)
            {
                this.str = str;
            }
            private string str { get; set; }
            private int iteration { get; set; } = 0;
        }

        /// <summary>
        /// Fills the tree under this node
        /// </summary>
        /// <param name="str">Arithmetic expression</param>
        /// <returns>Filled tree</returns>
        private INode FillTree(String str)
        {
            if (str[iteration] == '(')
            {
                iteration = IgnoreSpaces(str, iteration);
                var node = DefineOperation(str[iteration]);
                iteration = IgnoreSpaces(str, iteration);
                node.leftChild = FillTree(str, iteration);
                iteration = IgnoreSpaces(str, iteration);
                node.rigthChild = FillTree(str, iteration);
                return node;
            }
            else if (Char.IsDigit(str[iteration]) && Char.IsDigit(str[iteration + 1]))
            {
                var number = (int)Char.GetNumericValue(str[iteration]);
                while (Char.IsDigit(str[iteration + 1]))
                {
                    number = number * 10 + (int)Char.GetNumericValue(str[iteration + 1]);
                    ++iteration;
                }
                iteration = IgnoreSpaces(str, iteration);
                var node = new Number(number);
                if (str[iteration] == ')')
                {
                    iteration = IgnoreBrackets(str, iteration);
                }
                iteration = IgnoreSpaces(str, iteration);
                return node;
            }
            else if (Char.IsDigit(str[iteration]) && str[iteration + 1] == ')')
            {
                var node = new Number((int)Char.GetNumericValue(str[iteration]));
                iteration = IgnoreBrackets(str, iteration);
                return node;
            }
            else if (Char.IsDigit(str[iteration]))
            {
                var node = new Number((int)Char.GetNumericValue(str[iteration]));
                iteration = IgnoreSpaces(str, iteration);
                return node;
            }
            else throw new InvalidInputException("Invalid input");
        }

        private int IgnoreBrackets(string str, int iteration)
        {
            while (str[iteration] == ')')
            {
                ++iteration;
            }
            return iteration;
        }

        private int IgnoreSpaces(string str, int iteration)
        {
            ++iteration;
            while (str[iteration] == ' ')
            {
                ++iteration;
            }
            return iteration;
        }

        /// <summary>
        /// The head of a tree
        /// </summary>
        private INode head = null;
    }
}
