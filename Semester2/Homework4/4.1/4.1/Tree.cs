using System;

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

        /// <summary>
        /// Arithmetic expression string's class
        /// </summary>
        private class String
        {
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
            /// String itself
            /// </summary>
            internal string str;
            /// <summary>
            /// Current iteration's number
            /// </summary>
            internal int iteration = 0;
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
                str.iteration = IgnoreSpaces(str);
                var node = DefineOperation(str.Current());
                ++str.iteration;
                str.iteration = IgnoreSpaces(str);
                node.leftChild = FillTree(str);
                str.iteration = IgnoreSpaces(str);
                node.rigthChild = FillTree(str);
                return node;
            }
            else if (Char.IsDigit(str.Current()) && Char.IsDigit(str.Next()))
            {
                var number = (int)Char.GetNumericValue(str.Current());
                ++str.iteration;
                while (Char.IsDigit(str.Current()))
                {
                    number = number * 10 + (int)Char.GetNumericValue(str.Current());
                    ++str.iteration;
                }
                str.iteration = IgnoreSpaces(str);
                var node = new Number(number);
                if (str.Current() == ')')
                {
                    str.iteration = IgnoreBrackets(str);
                }
                return node;
            }
            else if (Char.IsDigit(str.Current()) && str.Next() == ')')
            {
                var node = new Number((int)Char.GetNumericValue(str.Current()));
                ++str.iteration;
                str.iteration = IgnoreBrackets(str);
                return node;
            }
            else if (Char.IsDigit(str.Current()))
            {
                var node = new Number((int)Char.GetNumericValue(str.Current()));
                ++str.iteration;
                str.iteration = IgnoreSpaces(str);
                return node;
            }
            else throw new InvalidInputException("Invalid input");
        }

        /// <summary>
        /// Ignores closing brackets
        /// </summary>
        /// <param name="str">Given string</param>
        /// <returns>The number of next symbol that's not a closing bracket</returns>
        private int IgnoreBrackets(String str)
        {
            while (str.iteration < str.Length() && str.Current() == ')')
            {
                ++str.iteration;
            }
            return str.iteration;
        }

        /// <summary>
        /// Ignores spaces
        /// </summary>
        /// <param name="str">Given string</param>
        /// <returns>The number of next symbol that's not a space</returns>
        private int IgnoreSpaces(String str)
        {
            while (str.Current() == ' ')
            {
                ++str.iteration;
            }
            return str.iteration;
        }

        /// <summary>
        /// The head of a tree
        /// </summary>
        private INode head = null;
    }
}
