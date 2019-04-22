using System;

namespace _6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        public Map Field { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

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
            if (initialX < 0 || initialY < 0 || initialY > Field.Height || initialX > Field.Width || Field.Field[initialY, initialX] == '#')
            {
                throw new InvalidInitialCoordinatesException();
            }
            X = initialX;
            Y = initialY;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going up
        /// </summary>
        public void Up(object sender, EventArgs args)
        {
            if (Field.Field[Y - 1, X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(X, Y);
            Console.Write('.');
            --Y;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going down
        /// </summary>
        public void Down(object sender, EventArgs args)
        {
            if (Field.Field[Y + 1, X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(X, Y);
            Console.Write('.');
            ++Y;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going right
        /// </summary>
        public void Right(object sender, EventArgs args)
        {
            if (Field.Field[Y, X + 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(X, Y);
            Console.Write('.');
            ++X;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going left
        /// </summary>
        public void Left(object sender, EventArgs args)
        {
            if (Field.Field[Y, X - 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(X, Y);
            Console.Write('.');
            --X;
            Console.SetCursorPosition(X, Y);
            Console.Write('@');
        }
    }
}
