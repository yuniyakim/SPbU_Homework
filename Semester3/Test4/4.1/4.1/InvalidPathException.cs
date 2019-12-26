using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1
{
    /// <summary>
    /// Exception for invalid path
    /// </summary>
    public class InvalidPathException : Exception
    {
        public InvalidPathException() { }
        public InvalidPathException(string message) : base(message) { }
        public InvalidPathException(string message, Exception inner)
        : base(message, inner) { }
        protected InvalidPathException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}