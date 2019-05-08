using System;
using System.Collections.Generic;
using System.Text;

namespace _8._1
{
    /// <summary>
    /// Exception for invalid position of element in the list
    /// </summary>
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException() { }
        public InvalidPositionException(string message) : base(message) { }
        public InvalidPositionException(string message, Exception inner)
        : base(message, inner) { }
        protected InvalidPositionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
