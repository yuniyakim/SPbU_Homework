using System;

namespace _3._1
{
    /// <summary>
    /// Task factory
    /// </summary>
    public class TaskFactory<T>
    {
        /// <summary>
        /// Creates task
        /// </summary>
        /// <param name="func">Incoming function</param>
        /// <returns>Created task</returns>
        public static Task<T> CreateTask(Func<T> func)
        {
            if (func == null)
            {
                throw new FuncNullException();
            }

            return new Task<T>(func);
        }
    }
}
