using System;

namespace _6._2
{
    /// <summary>
    /// Exception for invalid symbol in input file
    /// </summary>
    public class InvalidInputSymbolException : Exception
    {
        public InvalidInputSymbolException() { }
        public InvalidInputSymbolException(string message) : base(message) { }
        public InvalidInputSymbolException(string message, Exception inner) : base(message, inner) { }
        protected InvalidInputSymbolException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
