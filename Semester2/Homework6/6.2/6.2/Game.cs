using System;

namespace _6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        private Player player;
        private Map map;

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="map">Game's map</param>
        public Game(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Sets initial coordinates of a player
        /// </summary>
        /// <param name="initialX">Initial x coordinate</param>
        /// <param name="initialY">Initial y coordinate</param>
        public void SetInitialCoordinates(int initialX, int initialY)
        {
            if (initialX < 0 || initialY < 0 || initialY < map.Height || initialX < map.Width || map.Field[initialX, initialY] == '#')
            {
                throw new InvalidInitialCoordinatesException("Ivalid coordinates");
            }
            player.X = initialX;
            player.Y = initialY;
        }

        /// <summary>
        /// Player's class
        /// </summary>
        private class Player
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public void Up(object sender, EventArgs args)
        {

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
