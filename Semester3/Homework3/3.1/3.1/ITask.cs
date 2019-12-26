using System;

namespace _3._1
{
    /// <summary>
    /// Task interface
    /// </summary>
    /// <typeparam name="TResult">Task result type</typeparam>
    public interface ITask<TResult>
    {
        /// <summary>
        /// Defines whether or not task is completed
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Returns result of task's completion
        /// </summary>
        TResult Result { get; }

        /// <summary>
        /// Returns a new task which is going to me completed
        /// </summary>
        /// <typeparam name="TNewResult">Task new result type</typeparam>
        /// <param name="func">Incoming function</param>
        /// <returns>New task</returns>
        ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
