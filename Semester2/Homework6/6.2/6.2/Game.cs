using System;

namespace _6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        private Player player;
        public Map Field { get; private set; }

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="map">Game's map</param>
        public Game(Map map)
        {
            this.Field = map;
        }

        /// <summary>
        /// Sets initial coordinates of a player
        /// </summary>
        /// <param name="initialX">Initial x coordinate</param>
        /// <param name="initialY">Initial y coordinate</param>
        public void SetInitialCoordinates(int initialX, int initialY)
        {
            if (initialX < 0 || initialY < 0 || initialY > Field.Height || initialX > Field.Width || Field.Field[initialX, initialY] == '#')
            {
                throw new InvalidInitialCoordinatesException("Ivalid coordinates");
            }
            player = new Player();
            player.SetX(initialX, Field);
            player.SetY(initialY, Field);
            Field.Field[initialY, initialX] = '@';
        }

        /// <summary>
        /// Player's class
        /// </summary>
        private class Player
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public void SetX(int x, Map field)
            {
                if (x < 0 || x > field.Width)
                {
                    throw new InvalidInitialCoordinatesException("Ivalid coordinates");
                }
                X = x;
            }

            public void SetY(int y, Map field)
            {
                if (y < 0 || y > field.Width)
                {
                    throw new InvalidInitialCoordinatesException("Ivalid coordinates");
                }
                Y = y;
            }
        }

        public void Up(object sender, EventArgs args)
        {
            if (Field.Field[player.Y + 1, player.X] == '#')
            {
                throw new InvalidMoveException();
            }
            Field.Field[player.Y, player.X] = '.';
            player.SetY(player.Y + 1, Field);
            Field.Field[player.Y, player.X] = '@';
            Console.SetCursorPosition(player.X, player.Y);
        }

        public void Down(object sender, EventArgs args)
        {

        }

        public void Right(object sender, EventArgs args)
        {

        }

        public void Left(object sender, EventArgs args)
        {

        }
    }
}
