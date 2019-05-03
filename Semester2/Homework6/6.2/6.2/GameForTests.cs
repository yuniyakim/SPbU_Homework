using System;

namespace _6._2
{
    /// <summary>
    /// Game for test's class
    /// </summary>
    public class GameForTest : IGame
    {
        public Map Field { get; private set; }
        public Player Character { get; private set; }

        /// <summary>
        /// Game for test's constructor
        /// </summary>
        /// <param name="map">Game's map</param>
        public GameForTest(Map map)
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
            Character.Move("up");
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
            Character.Move("down");
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
            Character.Move("right");
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
            Character.Move("left");
        }
    }
}
