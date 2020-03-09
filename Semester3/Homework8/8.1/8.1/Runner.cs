using System;
using Attributes;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _8._1
{
    /// <summary>
    /// Class for running tests
    /// </summary>
    public class Runner
    {
        private ConcurrentQueue<Info> queue = new ConcurrentQueue<Info>();
        private Object lockObject = new Object();

        public void Run(string path)
        {
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories)
                .Where(x => x.Substring(x.LastIndexOf('\\') + 1) != "Attributes.dll");
            foreach(var file in files)
            {
                var types = Assembly.LoadFrom(file).GetTypes();

            }
        }
    }
}
