using System;

namespace _6._2
{
    /// <summary>
    /// Game's interface
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Sets initial coordinates
        /// </summary>
        /// <param name="initialX">Initial x coordinate</param>
        /// <param name="initialY">Initial y coordinate</param>
        void SetInitialCoordinates(int initialX, int initialY);
        /// <summary>
        /// Goes up
        /// </summary>
        void Up(object sender, EventArgs args);
        /// <summary>
        /// Goes down
        /// </summary>
        void Down(object sender, EventArgs args);
        /// <summary>
        /// Goes right
        /// </summary>
        void Right(object sender, EventArgs args);
        /// <summary>
        /// Goes left
        /// </summary>
        void Left(object sender, EventArgs args);
    }
}
