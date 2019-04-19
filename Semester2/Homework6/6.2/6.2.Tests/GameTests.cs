using System;
using System.IO;
using NUnit.Framework;

namespace _6._2
{
    public class GameTests
    {
        private Map map;
        private Game game;

        [SetUp]
        public void Initialize()
        {
            map = new Map();
            map.ReadAndFill(Directory.GetCurrentDirectory() + "../../../../6.2.Test.txt");
            game = new Game(map);
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
    }
}
