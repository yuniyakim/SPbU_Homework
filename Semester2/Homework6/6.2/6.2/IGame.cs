using System;

namespace _6._2
{
    public interface IGame
    {
        void SetInitialCoordinates(int initialX, int initialY);
        void Up(object sender, EventArgs args);
        void Down(object sender, EventArgs args);
        void Right(object sender, EventArgs args);
        void Left(object sender, EventArgs args);
    }
}
