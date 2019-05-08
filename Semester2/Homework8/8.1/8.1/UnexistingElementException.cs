using System;

namespace _8._1
{
    /// <summary>
    /// Exception for unexisting element
    /// </summary>
    public class UnexistingElementException : Exception
    {
        public UnexistingElementException() { }
        public UnexistingElementException(string message) : base(message) { }
        public UnexistingElementException(string message, Exception inner)
        : base(message, inner) { }
        protected UnexistingElementException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
