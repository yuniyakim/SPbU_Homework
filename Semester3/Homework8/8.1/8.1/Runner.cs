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

        /// <summary>
        /// Runs all the tests in given directory
        /// </summary>
        /// <param name="path">Given directory</param>
        public void Run(string path)
        {
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories)
                .Where(x => x.Substring(x.LastIndexOf('\\') + 1) != "Attributes.dll");
            foreach (var file in files)
            {
                var types = Assembly.LoadFrom(file).GetTypes();
                foreach (var type in types)
                {

                }
            }
        }

        /// <summary>
        /// Creates and filles lists with needed attributes
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Lists CreateAndFillLists(Type type)
        {
            var lists = new Lists();
            foreach (var method in type.GetMethods())
            {
                foreach (var attribute in Attribute.GetCustomAttributes(method))
                {
                    if (attribute.GetType() == typeof(BeforeClass))
                    {
                        lists.BeforeClass.Add(method);
                    }
                    if (attribute.GetType() == typeof(Before))
                    {
                        lists.Before.Add(method);
                    }
                    if (attribute.GetType() == typeof(Test))
                    {
                        lists.Tests.Add(method);
                    }
                    if (attribute.GetType() == typeof(After))
                    {
                        lists.After.Add(method);
                    }
                    if (attribute.GetType() == typeof(AfterClass))
                    {
                        lists.AfterClass.Add(method);
                    }
                }
            }
            return lists;
        }
    }
}
