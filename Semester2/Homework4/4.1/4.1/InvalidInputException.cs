using System;

namespace _4._1
{
    /// <summary>
    /// Exception for invalid input
    /// </summary>
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message) { }
    }
}
