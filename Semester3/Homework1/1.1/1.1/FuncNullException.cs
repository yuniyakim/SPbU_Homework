using System;

namespace _1._1
{
    /// <summary>
    /// Exception for invalid position of element in the list
    /// </summary>
    public class FuncNullException : Exception
    {
        public FuncNullException() { }
        public FuncNullException(string message) : base(message) { }
        public FuncNullException(string message, Exception inner)
        : base(message, inner) { }
        protected FuncNullException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
