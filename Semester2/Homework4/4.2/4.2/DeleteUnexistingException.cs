using System;

namespace _4._2
{
    /// <summary>
    /// Exception for deletion unexisting element
    /// </summary>
    public class DeleteUnexistingException : Exception
    {
        public DeleteUnexistingException() { }
        public DeleteUnexistingException(string message) : base(message) { }
        public DeleteUnexistingException(string message, Exception inner)
        : base(message, inner) { }
        protected DeleteUnexistingException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
