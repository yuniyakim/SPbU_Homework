using NUnit.Framework;
using System;
using System.Collections;
using System.IO;

namespace _8._1.Tests
{
    [TestFixture]
    public class Tests
    {
        private string path = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "../../../../../Tests";
        private Runner runner;

        private void CheckInfo(Info info, string name, string result, string ignoreReason)
        {
            Assert.AreEqual(name, info.Name);
            Assert.AreEqual(result, info.Result);
            Assert.AreEqual(ignoreReason, info.IgnoreReason);
        }

        public static int Compare(Info info1, Info info2)
        {
            return new CaseInsensitiveComparer().Compare(info1.Name, info2.Name);
        }

        [SetUp]
        public void SetUp()
        {
            runner = new Runner();
        }

        [Test]
        public void SimpleSucceededTestsTest()
        {
            var info = runner.Run(path + "/SimpleSucceededTests");
            Assert.AreEqual(6, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstTest", "Passed", null);
            CheckInfo(info[1], "FirstTest", "Passed", null);
            CheckInfo(info[2], "SecondTest", "Passed", null);
            CheckInfo(info[3], "SecondTest", "Passed", null);
            CheckInfo(info[4], "ThirdTest", "Passed", null);
            CheckInfo(info[5], "ThirdTest", "Passed", null);
        }

        [Test]
        public void SimpleFailedTestsTest()
        {
            var info = runner.Run(path + "/SimpleFailedTests");
            Assert.AreEqual(4, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstTest", "Failed", "Test has thrown System.Exception. Exception has been thrown by the target of an invocation.");
            CheckInfo(info[1], "FirstTest", "Failed", "Test has thrown System.Exception. Exception has been thrown by the target of an invocation.");
            CheckInfo(info[2], "SecondTest", "Failed", "Test has thrown System.Exception. Exception has been thrown by the target of an invocation.");
            CheckInfo(info[3], "SecondTest", "Failed", "Test has thrown System.Exception. Exception has been thrown by the target of an invocation.");
        }

        [Test]
        public void ExceptionTestsTest()
        {
            var info = runner.Run(path + "/ExceptionTests");
            Assert.AreEqual(6, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "DivideByZeroExceptionFailedTest", "Failed", "Test has thrown System.DivideByZeroException. Exception has been thrown by the target of an invocation.");
            CheckInfo(info[1], "DivideByZeroExceptionFailedTest", "Failed", "Test has thrown System.DivideByZeroException. Exception has been thrown by the target of an invocation.");
            CheckInfo(info[2], "DivideByZeroExceptionPassedTest", "Passed", null);
            CheckInfo(info[3], "DivideByZeroExceptionPassedTest", "Passed", null);
            CheckInfo(info[4], "IndexOutOfRangeExceptionTest", "Passed", null);
            CheckInfo(info[5], "IndexOutOfRangeExceptionTest", "Passed", null);
        }

        [Test]
        public void IgnoreTestsTest()
        {
            var info = runner.Run(path + "/IgnoreTests");
            Assert.AreEqual(4, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstIgnoreTest", "Ignored", "First ignore test");
            CheckInfo(info[1], "FirstIgnoreTest", "Ignored", "First ignore test");
            CheckInfo(info[2], "SecondIgnoreTest", "Ignored", "Second ignore test");
            CheckInfo(info[3], "SecondIgnoreTest", "Ignored", "Second ignore test");
        }
    }
}