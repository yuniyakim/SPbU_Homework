using System;

namespace _6._2
{
    /// <summary>
    /// Game's class
    /// </summary>
    public class Game
    {
        private Player player;
        private GameMap map;

        /// <summary>
        /// Game's constructor
        /// </summary>
        /// <param name="map">Game's map</param>
        public Game(GameMap map)
        {
            this.map = map;
        }

        /// <summary>
        /// Sets starting coordinates of a player
        /// </summary>
        /// <param name="initialX">Initial x coordinate</param>
        /// <param name="initialY">Initial y coordinate</param>
        public void SetInitialCoordinates(int initialX, int initialY)
        {
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
