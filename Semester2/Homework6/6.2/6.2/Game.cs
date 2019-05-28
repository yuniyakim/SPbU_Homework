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
        public ISetCursor cursor { get; set; } = new Cursor();

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="map">Game's map</param>
        /// /// <param name="cursor">Set cursor</param>
        public Game(Map map)
        {
            this.Field = map;
        }

        /// <summary>
        /// Cursor's class
        /// </summary>
        private class Cursor : ISetCursor
        {
            /// <summary>
            /// Sets cursor according to player's position
            /// </summary>
            public void SetCursor(int x, int y) => Console.SetCursorPosition(x, y);
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
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('@');
            cursor.SetCursor(Character.X, Character.Y);
        }

        /// <summary>
        /// Goes up
        /// </summary>
        public void Up(object sender, EventArgs args)
        {
            if (Character.Y - 1 < 0 || Field.Field[Character.Y - 1, Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('.');
            Character.Move("up");
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('@');
            cursor.SetCursor(Character.X, Character.Y);
        }

        /// <summary>
        /// Goes down
        /// </summary>
        public void Down(object sender, EventArgs args)
        {
            if (Character.Y + 1 >= Field.Height || Field.Field[Character.Y + 1, Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('.');
            Character.Move("down");
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('@');
            cursor.SetCursor(Character.X, Character.Y);
        }

        /// <summary>
        /// Goes right
        /// </summary>
        public void Right(object sender, EventArgs args)
        {
            if (Character.X + 1 >= Field.Width || Field.Field[Character.Y, Character.X + 1] == '#')
            {
                throw new InvalidMoveException();
            }
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('.');
            Character.Move("right");
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('@');
            cursor.SetCursor(Character.X, Character.Y);
        }

        /// <summary>
        /// Goes left
        /// </summary>
        public void Left(object sender, EventArgs args)
        {
            if (Character.X - 1 < 0 || Field.Field[Character.Y, Character.X - 1] == '#')
            {
                throw new InvalidMoveException();
            }
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('.');
            Character.Move("left");
            cursor.SetCursor(Character.X, Character.Y);
            Console.Write('@');
            cursor.SetCursor(Character.X, Character.Y);
        }
    }
}