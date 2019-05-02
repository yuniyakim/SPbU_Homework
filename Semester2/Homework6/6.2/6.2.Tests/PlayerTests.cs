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
            player.Move("up");
            Assert.AreEqual(6, player.Y);
            Assert.AreEqual(2, player.X);
        }

        [Test]
        public void DownTest()
        {
            player.Move("down");
            player.Move("down");
            Assert.AreEqual(9, player.Y);
            Assert.AreEqual(2, player.X);
        }

        [Test]
        public void RightTest()
        {
            for (int i = 0; i < 4; ++i)
            {
                player.Move("right");
            }
            Assert.AreEqual(7, player.Y);
            Assert.AreEqual(6, player.X);
        }

        [Test]
        public void LeftTest()
        {
            player.Move("left");
            player.Move("left");
            Assert.AreEqual(7, player.Y);
            Assert.AreEqual(0, player.X);
        }
    }
}
