using System;
using System.IO;
using NUnit.Framework;

namespace _6._2
{
    public class GameTests
    {
        private Map map;
        private Game game;
        private EventLoop eventLoop;

        [SetUp]
        public void Initialize()
        {
            map = new Map();
            map.ReadAndFill(Directory.GetCurrentDirectory() + "../../../../6.2.Test.txt");
            game = new Game(map);
            eventLoop = new EventLoop();
        }

        [Test]
        public void InvalidInitialXTest()
        {
            Assert.Throws<InvalidInitialCoordinatesException>(() => game.SetInitialCoordinates(-1, 5));
        }

        [Test]
        public void InvalidInitialYTest()
        {
            Assert.Throws<InvalidInitialCoordinatesException>(() => game.SetInitialCoordinates(4, 10));
        }

        [Test]
        public void TakenCellTest()
        {
            Assert.Throws<InvalidInitialCoordinatesException>(() => game.SetInitialCoordinates(4, 5));
        }

        /*[Test]
        public void UpTest()
        {
            game.SetInitialCoordinates(4, 3);
            eventLoop.UpHandler += game.Up;
            
            Assert.AreEqual(2, game.Y);
            Assert.AreEqual(4, game.X);
        }*/
    }
}
