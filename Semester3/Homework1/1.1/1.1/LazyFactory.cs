using System;
using System.Collections.Generic;
using System.Text;

namespace _1._1
{
    /// <summary>
    /// Lazy Factory
    /// </summary>
    public class LazyFactory<T>
    {
        private static T value;

        /// <summary>
        /// Creates single threaded lazy
        /// </summary>
        /// <param name="supplier">Incoming function</param>
        /// <returns>Created lazy</returns>
        public static Lazy<T> CreateLazySingleThreaded<T>(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new FuncNullException();
            }

        }

        /// <summary>
        /// Creates multiple threaded lazy
        /// </summary>
        /// <param name="supplier">Incoming function</param>
        /// <returns>Created lazy</returns>
        public static Lazy<T> CreateLazyMultipleThreaded<T>(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new FuncNullException();
            }

    }


}
