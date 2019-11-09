using System;
using NUnit.Framework;

namespace _3._1
{
    public class TaskTests
    {
        [Test]
        public void FuncNullTest()
        {
            var threadPool = new ThreadPool(1);
            Assert.Throws<ArgumentNullException>(() => TaskFactory<int>.CreateTask(null, threadPool));
        }

        [Test]
        public void ThreadPoolNullTest()
        {
            Func<int> func = () => 11 - 38;
            Assert.Throws<ArgumentNullException>(() => TaskFactory<int>.CreateTask(func, null));
        }

        [Test]
        public void CreateTaskTest()
        {
            Func<int> func = () => 11 - 38;
            var threadPool = new ThreadPool(1);
            Assert.IsNotNull(TaskFactory<int>.CreateTask(func, threadPool));
        }

        [Test]
        public void Test()
        {
            Func<int> func = () => 11 - 38;
            var threadPool = new ThreadPool(1);
            Assert.IsNotNull(TaskFactory<int>.CreateTask(func, threadPool));
        }
    }
}
