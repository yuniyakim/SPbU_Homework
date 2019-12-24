using NUnit.Framework;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTP
{
    public class FTPTests
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
            Assert.AreEqual((@"../../../Test\Folder", true), list[0]);
            Assert.AreEqual((@"../../../Test\code.cpp", false), list[1]);
            Assert.AreEqual((@"../../../Test\picture.png", false), list[2]);
            Assert.AreEqual((@"../../../Test\text.txt", false), list[3]);
            server.Shutdown();
        }

        [Test]
        public void GetTest()
        {
            Task.Run(async () => await server.Start());
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