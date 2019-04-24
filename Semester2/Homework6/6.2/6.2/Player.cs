using System;

namespace _6._2
{
    /// <summary>
    /// Player's class
    /// </summary>
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Player's constructor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Going up
        /// </summary>
        public void Up()
        {
            --Y;
        }

        /// <summary>
        /// Going down
        /// </summary>
        public void Down()
        {
            ++Y;
        }

        /// <summary>
        /// Going right
        /// </summary>
        public void Right()
        {
            ++X;
        }

        /// <summary>
        /// Goint left
        /// </summary>
        public void Left()
        {
            --X;
        }
    }
}
