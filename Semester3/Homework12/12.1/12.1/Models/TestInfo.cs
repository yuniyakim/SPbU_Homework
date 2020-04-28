using System.ComponentModel.DataAnnotations;

namespace _12._1.Models
{
    /// <summary>
    /// Test's info
    /// </summary>
    public class TestInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Result { get; private set; }
        public string IgnoreReason { get; private set; }
        public long Time { get; private set; }

        /// <summary>
        /// Test's info's constructor
        /// </summary>
        /// <param name="name">Test's name</param>
        /// <param name="result">Test's result</param>
        /// <param name="time">Test's time</param>
        /// <param name="ignoreReason">Test's ignore reason</param>
        public TestInfo(string name, string result, long time, string ignoreReason = null)
        {
            Name = name;
            Result = result;
            IgnoreReason = ignoreReason;
            Time = time;
        }
    }
}
