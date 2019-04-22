﻿using System;

namespace _6._2
{
    /// <summary>
    /// Events' class
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> UpHandler;
        public event EventHandler<EventArgs> DownHandler;
        public event EventHandler<EventArgs> RightHandler;
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
                            LeftHandler(this, new EventArgs());
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            RightHandler(this, new EventArgs());
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            UpHandler(this, new EventArgs());
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            DownHandler(this, new EventArgs());
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