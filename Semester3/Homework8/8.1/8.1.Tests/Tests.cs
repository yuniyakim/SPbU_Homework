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
            Assert.AreEqual(3, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstTest", "Passed", null);
            CheckInfo(info[1], "SecondTest", "Passed", null);
            CheckInfo(info[2], "ThirdTest", "Passed", null);
        }

        [Test]
        public void SimpleFailedTestsTest()
        {
            var info = runner.Run(path + "/SimpleFailedTests");
            Assert.AreEqual(2, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstTest", "Failed", "The test has thrown the System.Exception.");
            CheckInfo(info[1], "SecondTest", "Failed", "The test has thrown the System.Exception.");
        }

        [Test]
        public void ExceptionTestsTest()
        {
            var info = runner.Run(path + "/ExceptionTests");
            Assert.AreEqual(2, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "DivideByZeroExceptionTest", "Passed", null);
            CheckInfo(info[1], "IndexOutOfRangeExceptionTest", "Passed", null);
        }

        [Test]
        public void ParametersTestsTest()
        {
            var info = runner.Run(path + "/ParametersTests");
            Assert.AreEqual(5, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "OneIntParameterTest", "Passed", null);
            CheckInfo(info[1], "OneStringParameterTest", "Passed", null);
            CheckInfo(info[2], "TwoDifferentParametersTest", "Passed", null);
            CheckInfo(info[3], "TwoIntParametersTest", "Passed", null);
            CheckInfo(info[4], "TwoStringParametersTest", "Passed", null);
        }

        [Test]
        public void IgnoreTestsTest()
        {
            var info = runner.Run(path + "/IgnoreTests");
            Assert.AreEqual(2, info.Length);
            Array.Sort(info, Compare);
            CheckInfo(info[0], "FirstIgnoreTest", "Ignored", "First ignore test");
            CheckInfo(info[0], "SecondIgnoreTest", "Ignored", "Second ignore test");
        }
    }
}