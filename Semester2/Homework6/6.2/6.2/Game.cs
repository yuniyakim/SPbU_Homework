using System;

namespace _6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        public Map Field { get; private set; }
        public Player Character { get; private set; }

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
            Character = new Player(initialX, initialY);
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going up
        /// </summary>
        public void Up(object sender, EventArgs args)
        {
            if (Field.Field[Character.Y - 1, Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('.');
            Character.Up();
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going down
        /// </summary>
        public void Down(object sender, EventArgs args)
        {
            if (Field.Field[Character.Y + 1, Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('.');
            Character.Down();
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going right
        /// </summary>
        public void Right(object sender, EventArgs args)
        {
            if (Field.Field[Character.Y, Character.X + 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('.');
            Character.Right();
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going left
        /// </summary>
        public void Left(object sender, EventArgs args)
        {
            if (Field.Field[Character.Y, Character.X - 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('.');
            Character.Left();
            Console.SetCursorPosition(Character.X, Character.Y);
            Console.Write('@');
        }
    }
}
