using System;

namespace _1._1
{
    /// <summary>
    /// Exception for dequeuing an element from empty queue
    /// </summary>
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException() { }
        public EmptyQueueException(string message) : base(message) { }
        public EmptyQueueException(string message, Exception inner) : base(message, inner) { }
        protected EmptyQueueException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
