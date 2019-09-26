using System;
using System.Threading;

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
        private static Object lockObject = new Object();

        /// <summary>
        /// Multiple threaded lazy's constructor
        /// </summary>
        /// <param name="func">Incoming function</param>
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
            if (func == null && !isValueCreated)
            {
                throw new FuncNullException();
            }

            if (!isValueCreated)
            {
                lock (lockObject)
                {
                    if (!Volatile.Read(ref isValueCreated))
                    {
                        value = func();
                        Volatile.Write(ref isValueCreated, true);
                        func = null;
                    }
                }
            }
            return value;
        }
    }
}
