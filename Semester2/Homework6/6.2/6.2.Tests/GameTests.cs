using System;
using System.IO;
using NUnit.Framework;

namespace _6._2
{
    public class GameTests
    {
        private Map map;
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
            map = new Map();
            map.ReadAndFill(Directory.GetCurrentDirectory() + "../../../../6.2.Test.txt");
            game = new Game (map, new Cursor());
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
            game.Up(this, new EventArgs());
            Assert.AreEqual(2, game.Character.Y);
            Assert.AreEqual(4, game.Character.X);
        }

        [Test]
        public void UpToTakenCellTest()
        {
            game.SetInitialCoordinates(6, 4);
            Assert.Throws<InvalidMoveException>(() => game.Up(this, new EventArgs()));
        }

        [Test]
        public void UpOutOfMapTest()
        {
            game.SetInitialCoordinates(6, 2);
            game.Up(this, new EventArgs());
            game.Up(this, new EventArgs());
            Assert.Throws<InvalidMoveException>(() => game.Up(this, new EventArgs()));
        }

        [Test]
        public void DownTest()
        {
            game.SetInitialCoordinates(8, 3);
            game.Down(this, new EventArgs());
            Assert.AreEqual(4, game.Character.Y);
            Assert.AreEqual(8, game.Character.X);
        }

        [Test]
        public void DownToTakenCellTest()
        {
            game.SetInitialCoordinates(7, 1);
            Assert.Throws<InvalidMoveException>(() => game.Down(this, new EventArgs()));
        }

        [Test]
        public void DownOutOfMapTest()
        {
            game.SetInitialCoordinates(2, 5);
            game.Down(this, new EventArgs());
            Assert.Throws<InvalidMoveException>(() => game.Down(this, new EventArgs()));
        }

        [Test]
        public void RightTest()
        {
            game.SetInitialCoordinates(2, 4);
            game.Right(this, new EventArgs());
            game.Right(this, new EventArgs());
            Assert.AreEqual(4, game.Character.Y);
            Assert.AreEqual(4, game.Character.X);
        }

        [Test]
        public void RightToTakenCellTest()
        {
            game.SetInitialCoordinates(7, 5);
            Assert.Throws<InvalidMoveException>(() => game.Right(this, new EventArgs()));
        }

        [Test]
        public void RightOutOfMapTest()
        {
            game.SetInitialCoordinates(6, 4);
            game.Right(this, new EventArgs());
            game.Right(this, new EventArgs());
            game.Right(this, new EventArgs());
            Assert.Throws<InvalidMoveException>(() => game.Right(this, new EventArgs()));
        }

        [Test]
        public void LeftTest()
        {
            game.SetInitialCoordinates(6, 2);
            game.Left(this, new EventArgs());
            game.Left(this, new EventArgs());
            game.Left(this, new EventArgs());
            Assert.AreEqual(2, game.Character.Y);
            Assert.AreEqual(3, game.Character.X);
        }

        [Test]
        public void LeftToTakenCellTest()
        {
            game.SetInitialCoordinates(2, 5);
            Assert.Throws<InvalidMoveException>(() => game.Left(this, new EventArgs()));
        }

        [Test]
        public void LeftOutOfMapTest()
        {
            game.SetInitialCoordinates(1, 1);
            game.Left(this, new EventArgs());
            Assert.Throws<InvalidMoveException>(() => game.Left(this, new EventArgs()));
        }
    }
}
