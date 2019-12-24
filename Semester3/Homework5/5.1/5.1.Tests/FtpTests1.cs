using NUnit.Framework;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTP
{
    public class FtpTests
    {
        private const int port = 8888;
        private Client client;
        private Server server;

        [SetUp]
        public void Setup()
        {
            client = new Client(port);
            server = new Server(port);
        }

        [Test]
        public void DirectoryDoesntExistTest()
        {
            Task.Run(async () => await server.Start());
            Assert.IsNull(client.List("path").Result);
            server.Shutdown();
        }

        [Test]
        public void FileDoesntExistTest()
        {
            Task.Run(async () => await server.Start());
            Assert.IsNull(client.Get("path").Result);
            server.Shutdown();
        }

        [Test]
        public void ListTest()
        {
            Task.Run(async () => await server.Start());
            var list = client.List("../../../Test").Result;
            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list[0].Item1 == @"../../../Test\Folder" || list[0].Item1 == "../../../Test/Folder");
            Assert.IsTrue(list[0].Item2);
            Assert.IsTrue(list[1].Item1 ==  @"../../../Test\code.cpp" || list[1].Item1 == "../../../Test/code.cpp");
            Assert.IsFalse(list[1].Item2);
            Assert.IsTrue(list[2].Item1 == @"../../../Test\picture.png"|| list[2].Item1 == "../../../Test/picture.png");
            Assert.IsFalse(list[2].Item2);
            Assert.IsTrue(list[3].Item1 == @"../../../Test\text.txt" || list[3].Item1 == "../../../Test/text.txt");
            Assert.IsFalse(list[3].Item2);
            server.Shutdown();
        }

        [Test]
        public void GetTest()
        {
            Task.Run(async () => await server.Start());
            Thread.Sleep(1000);
            var get = client.Get("../../../Test/text.txt").Result;
            Assert.AreEqual("Text file\r\nHello, world!\r\nI love programming :)", Encoding.Default.GetString(get));
            server.Shutdown();
        }

        [Test]
        public void ServerNotStartedTest()
        {
            var localClient = new Client(8880);
            Assert.IsNull(localClient.List("../../../Test").Result);
            Assert.IsNull(localClient.Get("../../../Test/text/txt").Result);
        }
    }
}