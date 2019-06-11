using System;

namespace _6._2
{
    /// <summary>
    /// Set cursor's interface
    /// </summary>
    public interface ISetCursor
    {
        /// <summary>
        /// Sets cursor according to player's position
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        void SetCursor(int x, int y);
    }
}
