﻿using System;

namespace _1._1
{
    /// <summary>
    /// Single threaded lazy
    /// </summary>
    public class LazySingleThreaded<T> : ILazy<T>
    {
        private T value;
        private bool isValueCreated;
        private Func<T> func;

        /// <summary>
        /// Single threaded lazy's constructor
        /// </summary>
        /// <param name="func">Incoming function</param>
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
            if (func == null && !isValueCreated)
            {
                throw new FuncNullException();
            }

            if (!isValueCreated)
            {
                value = func();
                isValueCreated = true;
                func = null;
            }
            return value;
        }
    }
}