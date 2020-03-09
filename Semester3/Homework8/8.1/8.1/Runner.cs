using System;
using Attributes;
using System.Collections.Concurrent;

namespace _8._1
{
    /// <summary>
    /// Class for running tests
    /// </summary>
    public class Runner
    {
        private ConcurrentQueue<Info> queue = new ConcurrentQueue<Info>();
        private Object lockObject = new Object();
    }
}
