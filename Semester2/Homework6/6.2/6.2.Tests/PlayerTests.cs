using System;
using NUnit.Framework;

namespace _6._2
{
    public class PlayerTests
    {
        private Player player;

        [SetUp]
        public void Initialize()
        {
            player = new Player(2, 7);
        }

        [Test]
        public void UpTest()
        {
            player.Up();
            Assert.AreEqual(6, player.Y);
            Assert.AreEqual(2, player.X);
        }

        [Test]
        public void DownTest()
        {
            player.Down();
            player.Down();
            Assert.AreEqual(9, player.Y);
            Assert.AreEqual(2, player.X);
        }

        [Test]
        public void RightTest()
        {
            for (int i = 0; i < 4; ++i)
            {
                player.Right();
            }
            Assert.AreEqual(7, player.Y);
            Assert.AreEqual(6, player.X);
        }

        [Test]
        public void LeftTest()
        {
            player.Left();
            player.Left();
            Assert.AreEqual(7, player.Y);
            Assert.AreEqual(0, player.X);
        }
    }
}
