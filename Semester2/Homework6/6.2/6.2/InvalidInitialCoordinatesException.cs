using System;

namespace _6._2
{
    /// <summary>
    /// Exception for invalid initial coordinates
    /// </summary>
    public class InvalidInitialCoordinatesException : Exception
    {
        public InvalidInitialCoordinatesException() { }
        public InvalidInitialCoordinatesException(string message) : base(message) { }
        public InvalidInitialCoordinatesException(string message, Exception inner) : base(message, inner) { }
        protected InvalidInitialCoordinatesException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
