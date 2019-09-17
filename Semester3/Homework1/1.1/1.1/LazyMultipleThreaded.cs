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
        private T value;
        private bool isValueCreated;
        private Func<T> func;

        public LazyMultipleThreaded(Func<T> func)
        {
            this.func = func;
        }

        /// <summary>
        /// Returns value
        /// </summary>
        /// <returns>Value</returns>
        public T Get()
        {
            if (!isValueCreated)
            {
                value = func();
                isValueCreated = true;
            }
            return value;
        }
    }
}
