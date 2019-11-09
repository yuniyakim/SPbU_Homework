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
        /// <param name="threadPool">Thread pool to which task belongs</param>
        /// <returns>Created task</returns>
        public static Task<T> CreateTask(Func<T> func, ThreadPool threadPool)
        {
            if (func == null || threadPool == null)
            {
                throw new ArgumentNullException();
            }

            return new Task<T>(func, threadPool);
        }
    }
}
