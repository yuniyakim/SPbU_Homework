using System;
using System.Collections.Generic;
using System.Text;

namespace _3._1
{
    /// <summary>
    /// Exception for thread pool's shutdown
    /// </summary>
    public class ThreadPoolShutdownException : Exception
    {
        public ThreadPoolShutdownException() { }
        public ThreadPoolShutdownException(string message) : base(message) { }
        public ThreadPoolShutdownException(string message, Exception inner)
        : base(message, inner) { }
        protected ThreadPoolShutdownException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
