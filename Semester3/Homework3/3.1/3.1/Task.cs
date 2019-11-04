using System;
using System.Threading;

namespace _3._1
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task<TResult> : ITask<TResult>
    {
        private TResult result;
        private Func<TResult> func;
        private ManualResetEvent isResultCalculated;
        private ThreadPool<TResult> threadPool;

        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Task's constructor
        /// </summary>
        /// <param name="func">Incoming function</param>
        public Task(Func<TResult> func)
        {
            this.func = func;
        }

        /// <summary>
        /// Returns result of task's completion
        /// </summary>
        /// <returns>Task's result</returns>
        public TResult Result
        {
            get
            {
                isResultCalculated.WaitOne();
                return result;
            }
        }

        /// <summary>
        /// Returns a new task which is going to me completed
        /// </summary>
        /// <param name="func">Incoming function</param>
        /// <returns>New task</returns>
        public ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {

        }

        public void Execute()
        {

        }
    }
}
