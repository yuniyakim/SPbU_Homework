using System;

namespace _1._1
{
    /// <summary>
    /// Lazy Factory
    /// </summary>
    public class LazyFactory<T>
    {
        /// <summary>
        /// Creates single threaded lazy
        /// </summary>
        /// <param name="supplier">Incoming function</param>
        /// <returns>Created lazy</returns>
        public static LazySingleThreaded<T> CreateLazySingleThreaded<T>(Func<T> func)
        {
            if (func == null)
            {
                throw new FuncNullException();
            }

            return new LazySingleThreaded<T>(func);
        }

        /// <summary>
        /// Creates multiple threaded lazy
        /// </summary>
        /// <param name="supplier">Incoming function</param>
        /// <returns>Created lazy</returns>
        public static LazyMultipleThreaded<T> CreateLazyMultipleThreaded<T>(Func<T> func)
        {
            if (func == null)
            {
                throw new FuncNullException();
            }

            return new LazyMultipleThreaded<T>(func);
        }


}
