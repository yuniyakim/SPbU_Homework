using System;

namespace _4._1
{
    /// <summary>
    /// Tree on the nodes
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// The head of a tree
        /// </summary>
        private INode head = null;

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
        /// Fills the tree and calculates the result
        /// </summary>
        /// <param name="str">Arithmetic expression</param>
        /// <returns>The result of arihmetic expression</returns>
        public int FillAndCalculate(string str)
        {
            FilledTree(str);
            return Calculate();
        }

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
                    return new Subtraction();
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
        public void FilledTree(string str)
        {
            head = FillTree(new String(str));
        }

        /// <summary>
        /// Arithmetic expression string's class
        /// </summary>
        private class String
        {
            /// <summary>
            /// String itself
            /// </summary>
            internal string str;

            /// <summary>
            /// Current iteration's number
            /// </summary>
            internal int iteration = 0;

            /// <summary>
            /// String's constructor
            /// </summary>
            /// <param name="str">Given string</param>
            internal String(string str)
            {
                this.str = str;
            }

            /// <summary>
            /// Current symbol
            /// </summary>
            /// <returns>Current symbol</returns>
            internal char Current()
            {
                return str[iteration];
            }

            /// <summary>
            /// Next symbol
            /// </summary>
            /// <returns>Next symbol</returns>
            internal char Next()
            {
                return str[iteration + 1];
            }

            /// <summary>
            /// String's length
            /// </summary>
            /// <returns>String's length</returns>
            internal int Length()
            {
                return str.Length;
            }

            /// <summary>
            /// Ignores closing brackets
            /// </summary>
            /// <param name="str">Given string</param>
            /// <returns>The number of next symbol that's not a closing bracket</returns>
            internal void IgnoreBrackets()
            {
                while (iteration < Length() && Current() == ')')
                {
                    ++iteration;
                }
                ///return str.iteration;
            }

            /// <summary>
            /// Ignores spaces
            /// </summary>
            /// <param name="str">Given string</param>
            /// <returns>The number of next symbol that's not a space</returns>
            internal void IgnoreSpaces()
            {
                while (Current() == ' ')
                {
                    ++iteration;
                }
                ///return str.iteration;
            }
        }

        /// <summary>
        /// Fills the tree under this node
        /// </summary>
        /// <param name="str">Arithmetic expression</param>
        /// <returns>Filled tree</returns>
        private INode FillTree(String str)
        {
            if (str.Current() == '(')
            {
                ++str.iteration;
                str.IgnoreSpaces();
                var node = DefineOperation(str.Current());
                ++str.iteration;
                str.IgnoreSpaces();
                node.LeftChild = FillTree(str);
                str.IgnoreSpaces();
                node.RightChild = FillTree(str);
                return node;
            }
            if (Char.IsDigit(str.Current()) && Char.IsDigit(str.Next()))
            {
                var number = (int)Char.GetNumericValue(str.Current());
                ++str.iteration;
                while (Char.IsDigit(str.Current()))
                {
                    number = number * 10 + (int)Char.GetNumericValue(str.Current());
                    ++str.iteration;
                }
                str.IgnoreSpaces();
                var node = new Number(number);
                if (str.Current() == ')')
                {
                    str.IgnoreBrackets();
                }
                return node;
            }
            else if (Char.IsDigit(str.Current()) && str.Next() == ')')
            {
                var node = new Number((int)Char.GetNumericValue(str.Current()));
                ++str.iteration;
                str.IgnoreBrackets();
                return node;
            }
            else if (Char.IsDigit(str.Current()))
            {
                var node = new Number((int)Char.GetNumericValue(str.Current()));
                ++str.iteration;
                str.IgnoreSpaces();
                return node;
            }
            else
            {
                throw new InvalidInputException("Invalid input");
            }
        }
    }
}
