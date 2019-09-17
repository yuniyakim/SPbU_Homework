using System;
using System.Collections.Generic;
using System.Text;

namespace _1._1
{
    /// <summary>
    /// Single threaded lazy
    /// </summary>
    public class LazySingleThreaded<T> : ILazy<T>
    {
        public T Value { get; set; }
        private Func<T> func;

        /// <summary>
        /// Single threaded lazy's constructor
        /// </summary>
        /// <param name="func"></param>
        public LazySingleThreaded(Func<T> func)
        {
            this.func = func;
        }

        /// <summary>
        /// Gets value and calculates it before if it's function's first call
        /// </summary>
        /// <returns>Value</returns>
        public T Get()
        {
            if (Value == null)
            {
                Value = func();
            }
            return Value;
        }
    }
}