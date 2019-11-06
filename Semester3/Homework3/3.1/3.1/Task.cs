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
        private AutoResetEvent waitForResult = new AutoResetEvent(false);
        private ThreadPool threadPool;
        private AggregateException exception;
        private static Object lockObject = new Object();

        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Task's constructor
        /// </summary>
        /// <param name="func">Incoming function</param>
        public Task(Func<TResult> func, ThreadPool threadPool)
        {
            this.func = func;
            this.threadPool = threadPool;
        }

        /// <summary>
        /// Returns result of task's completion
        /// </summary>
        /// <returns>Task's result</returns>
        public TResult Result
        {
            get
            {
                waitForResult.WaitOne();
                if (exception != null)
                {
                    throw exception;
                }
                return result;
            }
        }

        /// <summary>
        /// Returns a new task which is going to be completed
        /// </summary>
        /// <param name="func">Incoming function</param>
        /// <returns>New task</returns>
        public ITask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {
            var task = new Task<TNewResult>(() => func(result), threadPool);
            lock (lockObject)
            {
                if (!IsCompleted)
                {

                }
            }
        }

        public void Execute()
        {
            
        }
    }
}
