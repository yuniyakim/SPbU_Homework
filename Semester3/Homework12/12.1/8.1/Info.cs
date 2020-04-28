using System;

namespace _8._1
{
    /// <summary>
    /// Test's information
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Info's constructor
        /// </summary>
        /// <param name="name">Test's name</param>
        /// <param name="result">Test's result</param>
        /// <param name="ignoreReason">Test's ignore reason</param>
        /// <param name="time">Test's time</param>
        public Info(string name, string result, long time, string ignoreReason = null)
        {
            Name = name;
            Result = result;
            IgnoreReason = ignoreReason;
            Time = time;
        }

        public string Name { get; }
        public string Result { get; }
        public string IgnoreReason { get; }
        public long Time { get; }
    }
}
