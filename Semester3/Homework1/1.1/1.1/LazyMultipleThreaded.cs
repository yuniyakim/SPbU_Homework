using System;
using System.Collections.Generic;
using System.Text;

namespace _1._1
{
    /// <summary>
    /// Multiple threaded lazy
    /// </summary>
    public class LazyMultipleThreaded<T> : ILazy<T>
    {
        public T Value { get; set; }

        /// <summary>
        /// Returns value
        /// </summary>
        /// <returns>Value</returns>
        public T Get() => Value;
    }
}
