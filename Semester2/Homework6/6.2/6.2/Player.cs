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
        /// Going in some direction
        /// </summary>
        /// <param name="direction">Direction of movement</param>
        public void Move(string direction)
        {
            switch (direction.ToLower())
            {
                case "up":
                    {
                        --Y;
                        break;
                    }
                case "down":
                    {
                        ++Y;
                        break;
                    }

                case "right":
                    {
                        ++X;
                        break;
                    }

                case "left":
                    {
                        --X;
                        break;
                    }
            }
        }
    }
}
