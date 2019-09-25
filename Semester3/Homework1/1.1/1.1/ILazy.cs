using System;

namespace _1._1
{
    /// <summary>
    /// Lazy interface
    /// </summary>
    public interface ILazy<T>
    {
        /// <summary>
        /// Gets the result of calculation
        /// </summary>
        T Get();
    }
}
