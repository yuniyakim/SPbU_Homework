using NUnit.Framework;
using System;
using System.Text;
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
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual((@"../../../Test\EmptyFolder", true), list[0]);
            Assert.AreEqual((@"../../../Test\NotEmptyFolder", true), list[1]);
            Assert.AreEqual((@"../../../Test\code.cpp", false), list[2]);
            Assert.AreEqual((@"../../../Test\picture.png", false), list[3]);
            Assert.AreEqual((@"../../../Test\text.txt", false), list[4]);
            server.Shutdown();
        }

        [Test]
        public void ListEmptyFolderTest()
        {
            Task.Run(async () => await server.Start());
            var list = client.List("../../../Test/EmptyFolder").Result;
            Assert.AreEqual(0, list.Count);
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
        public void ServerNotStartedListTest()
        {
            Assert.IsNull(client.List("../../../Test").Result);
        }

        [Test]
        public void ServerNotStartedGetTest()
        {
            Assert.IsNull(client.Get("../../../Test/text.txt").Result);
        }
    }
}