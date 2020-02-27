using System;

namespace _8._1
{
    /// <summary>
    /// Attribute for tests
    /// </summary>
    public class Test : Attribute
    {
        /// <summary>
        /// Expected exception
        /// </summary>
        public Type Expected { get; set; }

        /// <summary>
        /// Ignore reason
        /// </summary>
        public string Ignore { get; set; }
    }
}
