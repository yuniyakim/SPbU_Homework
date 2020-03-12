using System;
using Attributes;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;

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
                    var lists = CreateAndFillLists(type);

                    var ignoreReason = RunNonTestMethods(lists.BeforeClass);
                    if (ignoreReason != "")
                    {
                        foreach (var test in lists.Tests)
                        {
                            queue.Enqueue(new Info(test.Name, "Failed", 0, ignoreReason));
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Runs non-test methods
        /// </summary>
        /// <param name="list">Methods' list</param>
        /// <param name="instance">Instance of type</param>
        /// <returns>Empty string, exception description if exception was thrown</returns>
        private string RunNonTestMethods(List<MethodInfo> list, object instance = null)
        {
            foreach (var method in list)
            {
                if (!method.IsStatic && instance == null)
                {
                    return $"Method {method.Name} must be static";
                }
                try
                {
                    lock (lockObject)
                    {
                        method.Invoke(instance, null);
                    }
                }
                catch (Exception e)
                {
                    return $"{e.Message}";
                }
            }
            return "";
        }

        /// <summary>
        /// Runs all Before methods, test and all After methods
        /// </summary>
        /// <param name="methodInfo">Given method</param>
        /// <param name="type">Method's type</param>
        /// <param name="lists">Methods' list</param>
        /// <param name="infoQueue">Queue with info</param>
        private void RunTesMethods(MethodInfo methodInfo, Type type, Lists lists, ConcurrentQueue<Info> infoQueue)
        {
            var instance = Activator.CreateInstance(type);

            var ignoreReasonBefore = RunNonTestMethods(lists.Before);
            if (ignoreReasonBefore != "")
            {
                infoQueue.Enqueue(new Info(methodInfo.Name, "Failed", 0, ignoreReasonBefore));
                return;
            }



            var ignoreReasonAfter = RunNonTestMethods(lists.After);
            if (ignoreReasonAfter != "")
            {
                infoQueue.Enqueue(new Info(methodInfo.Name, "Failed", 0, ignoreReasonAfter));
                return;
            }
        }

        /// <summary>
        /// Runs test method
        /// </summary>
        /// <param name="method">Given method</param>
        /// <param name="type">Method's type</param>
        /// <param name="instance">Instance of type</param>
        /// <returns>Test's info</returns>
        private Info RunTest(MethodInfo method, Type type, object instance)
        {
            var properties = (Test)Attribute.GetCustomAttribute(method, typeof(Test));
            if (properties.Ignore == null)
            {
                return new Info(method.Name, "Ignored", 0, properties.Ignore);
            }

            var watch = new Stopwatch();
            string ignoreReason = null;
            var result = "";
            try
            {
                lock (lockObject)
                {
                    watch.Start();
                    method.Invoke(instance, null);
                    watch.Stop();
                }
            }
            catch (Exception e)
            {
                watch.Stop();
                if (e.InnerException.GetType() != properties.Expected)
                {
                    ignoreReason = $"{e.Message}";
                    result = "Failed";
                }
                return new Info(method.Name, result, watch.ElapsedMilliseconds, ignoreReason);
            }

            if (properties.Expected != null)
            {
                return new Info(method.Name, "Failed", watch.ElapsedMilliseconds, $"Test hasn't thrown {properties.Expected.ToString()}");
            }
            return new Info(method.Name, "Succeeded", watch.ElapsedMilliseconds, ignoreReason);
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
