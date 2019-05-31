using System;

namespace _6._2
{
    /// <summary>
    /// Events' class
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Event handler for going up
        /// </summary>
        public event EventHandler<EventArgs> UpHandler;
        /// <summary>
        /// Event handler for going down
        /// </summary>
        public event EventHandler<EventArgs> DownHandler;
        /// <summary>
        /// Event handler for going right
        /// </summary>
        public event EventHandler<EventArgs> RightHandler;
        /// <summary>
        /// Event handler for going left
        /// </summary>
        public event EventHandler<EventArgs> LeftHandler;

        /// <summary>
        /// Class for moving by pressing arrow buttons
        /// </summary>
        public void Move()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            LeftHandler?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            RightHandler?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            UpHandler?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            DownHandler?.Invoke(this, EventArgs.Empty);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong key was pressed");
                            break;
                        }
                }
            }
        }
    }
}
