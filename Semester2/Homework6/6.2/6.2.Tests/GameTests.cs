using System;
using System.IO;
using NUnit.Framework;

namespace _6._2
{
    public class GameTests
    {
        private Game game;

        private class Cursor : ISetCursor
        {
            public void SetCursor(int x, int y)
            {
            }
        }

        [SetUp]
        public void Initialize()
        {
            var map = new Map();
            map.ReadAndFill(Directory.GetCurrentDirectory() + "../../../../6.2.Test.txt");
            game = new Game(map, new Cursor());
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

        [Test]
        public void UpTest()
        {
            game.SetInitialCoordinates(4, 3);
            game.Up(this, EventArgs.Empty);
            Assert.AreEqual(2, game.Character.Y);
            Assert.AreEqual(4, game.Character.X);
        }

        [Test]
        public void UpToTakenCellTest()
        {
            game.SetInitialCoordinates(6, 4);
            game.Up(this, EventArgs.Empty);
            Assert.AreEqual(4, game.Character.Y);
        }

        [Test]
        public void UpOutOfMapTest()
        {
            game.SetInitialCoordinates(6, 2);
            game.Up(this, EventArgs.Empty);
            game.Up(this, EventArgs.Empty);
            game.Up(this, EventArgs.Empty);
            Assert.AreEqual(0, game.Character.Y);
        }

        [Test]
        public void DownTest()
        {
            game.SetInitialCoordinates(8, 3);
            game.Down(this, EventArgs.Empty);
            Assert.AreEqual(4, game.Character.Y);
            Assert.AreEqual(8, game.Character.X);
        }

        [Test]
        public void DownToTakenCellTest()
        {
            game.SetInitialCoordinates(7, 1);
            game.Down(this, EventArgs.Empty);
            Assert.AreEqual(1, game.Character.Y);
        }

        [Test]
        public void DownOutOfMapTest()
        {
            game.SetInitialCoordinates(2, 5);
            game.Down(this, EventArgs.Empty);
            game.Down(this, EventArgs.Empty);
            Assert.AreEqual(6, game.Character.Y);
        }

        [Test]
        public void RightTest()
        {
            game.SetInitialCoordinates(2, 4);
            game.Right(this, EventArgs.Empty);
            game.Right(this, EventArgs.Empty);
            Assert.AreEqual(4, game.Character.Y);
            Assert.AreEqual(4, game.Character.X);
        }

        [Test]
        public void RightToTakenCellTest()
        {
            game.SetInitialCoordinates(7, 5);
            game.Right(this, EventArgs.Empty);
            Assert.AreEqual(7, game.Character.X);
        }

        [Test]
        public void RightOutOfMapTest()
        {
            game.SetInitialCoordinates(6, 4);
            game.Right(this, EventArgs.Empty);
            game.Right(this, EventArgs.Empty);
            game.Right(this, EventArgs.Empty);
            game.Right(this, EventArgs.Empty);
            Assert.AreEqual(9, game.Character.X);
        }

        [Test]
        public void LeftTest()
        {
            game.SetInitialCoordinates(6, 2);
            game.Left(this, EventArgs.Empty);
            game.Left(this, EventArgs.Empty);
            game.Left(this, EventArgs.Empty);
            Assert.AreEqual(2, game.Character.Y);
            Assert.AreEqual(3, game.Character.X);
        }

        [Test]
        public void LeftToTakenCellTest()
        {
            game.SetInitialCoordinates(2, 5);
            game.Left(this, EventArgs.Empty);
            Assert.AreEqual(2, game.Character.X);
        }

        [Test]
        public void LeftOutOfMapTest()
        {
            game.SetInitialCoordinates(1, 1);
            game.Left(this, EventArgs.Empty);
            game.Left(this, EventArgs.Empty);
            Assert.AreEqual(0, game.Character.X);
        }
    }
}
