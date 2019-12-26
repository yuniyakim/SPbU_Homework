using System;
using NUnit.Framework;

namespace _2._1
{
    public class Tests
    {
        private Board board = new Board();

        [Test]
        public void HasAnyoneWonFirstRowTest()
        {
            board.GetCell(1).Mark = "X";
            board.GetCell(2).Mark = "X";
            board.GetCell(3).Mark = "X";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonSecondRowTest()
        {
            board.GetCell(4).Mark = "X";
            board.GetCell(5).Mark = "X";
            board.GetCell(6).Mark = "X";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonThirdRowTest()
        {
            board.GetCell(7).Mark = "O";
            board.GetCell(8).Mark = "O";
            board.GetCell(9).Mark = "O";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonFirstColumnTest()
        {
            board.GetCell(1).Mark = "X";
            board.GetCell(4).Mark = "X";
            board.GetCell(7).Mark = "X";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonSecondColumnTest()
        {
            board.GetCell(2).Mark = "O";
            board.GetCell(5).Mark = "O";
            board.GetCell(8).Mark = "O";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonThirdColumnTest()
        {
            board.GetCell(3).Mark = "X";
            board.GetCell(6).Mark = "X";
            board.GetCell(9).Mark = "X";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonFirstDiagonalTest()
        {
            board.GetCell(1).Mark = "O";
            board.GetCell(5).Mark = "O";
            board.GetCell(9).Mark = "O";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonSecondDiagonalTest()
        {
            board.GetCell(3).Mark = "X";
            board.GetCell(5).Mark = "X";
            board.GetCell(7).Mark = "X";
            Assert.IsTrue(board.HasAnyoneWon());
        }

        [Test]
        public void HasAnyoneWonTest()
        {
            board.GetCell(3).Mark = "X";
            board.GetCell(2).Mark = "X";
            board.GetCell(7).Mark = "X";
            Assert.IsFalse(board.HasAnyoneWon());
        }
    }
}