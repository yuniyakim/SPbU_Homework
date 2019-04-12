using System;

namespace _4._2
{
    /// <summary>
    /// Exception for adding existing element
    /// </summary>
    public class AddExistingException : Exception
    {
        public AddExistingException() { }
        public AddExistingException(string message) : base(message) { }
        public AddExistingException(string message, Exception inner) : base(message, inner) { }
        protected AddExistingException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
