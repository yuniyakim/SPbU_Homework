using System;

namespace _3._1
{
    /// <summary>
    /// Task interface
    /// </summary>
    public interface IMyTask<TResult>
    {
        /// <summary>
        /// Defines whether or not task is completed
        /// </summary>
        /// <returns>True if task is completed, false otherwise</returns>
        bool IsCompleted();
        /// <summary>
        /// Returns result of task's completion
        /// </summary>
        /// <returns>Task's result</returns>
        TResult Result();
        /// <summary>
        /// Returns a new task which is going to me completed
        /// </summary>
        /// <param name="func">Incoming function</param>
        /// <returns>New task</returns>
        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
