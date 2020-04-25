using NUnit.Framework;
using System.IO;

namespace _8._1.Tests
{
    [TestFixture]
    public class Tests
    {
        private string path = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "../../../../../Tests";
        private Runner runner;

        private void CheckInfo()
        {

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
        }

        [Test]
        public void SimpleFailedTestsTest()
        {
            var info = runner.Run(path + "/SimpleFailedTests");
            Assert.AreEqual(2, info.Length);
        }

        [Test]
        public void ExceptionTestsTest()
        {
            var info = runner.Run(path + "/ExceptionTests");
            Assert.AreEqual(2, info.Length);
        }

        [Test]
        public void ParametersTestsTest()
        {
            var info = runner.Run(path + "/ParametersTests");
            Assert.AreEqual(5, info.Length);
        }

        [Test]
        public void IgnoreTestsTest()
        {
            var info = runner.Run(path + "/IgnoreTests");
            Assert.AreEqual(2, info.Length);
        }
    }
}