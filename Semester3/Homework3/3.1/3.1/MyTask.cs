using System;

namespace _3._1
{
    public class Task<TResult> : IMyTask<TResult>
    {
        public bool IsCompleted { get; private set; }

        public TResult Result { }

        public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
        {

        }
    }
}
