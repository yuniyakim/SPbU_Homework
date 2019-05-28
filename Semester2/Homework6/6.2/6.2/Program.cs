using System;
using System.IO;

namespace _6._2
{
    public class Program
    {
        private class Cursor : ISetCursor
        {
            /// <summary>
            /// Sets cursor according to player's position
            /// </summary>
            public void SetCursor(int x, int y) => Console.SetCursorPosition(x, y);
        }

        static void Main()
        {
            var path = Directory.GetCurrentDirectory() + "../../../../6.2.txt";
            var eventLoop = new EventLoop();
            var map = new Map();
            map.ReadAndFill(path);
            var game = new Game(map, new Cursor());
            map.Print();
            Console.WriteLine("Press ctrl + C to exit");
            Console.WriteLine("Enter starting coordinates of your player");
            Console.Write("x = ");
            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                throw new InvalidInputException();
            }
            Console.Write("y = ");
            if (!int.TryParse(Console.ReadLine(), out int y))
            {
                throw new InvalidInputException();
            }
            game.SetInitialCoordinates(x - 1, y - 1);
            eventLoop.UpHandler += game.Up;
            eventLoop.DownHandler += game.Down;
            eventLoop.RightHandler += game.Right;
            eventLoop.LeftHandler += game.Left;
            eventLoop.Move();
        }
    }
}

// На базе класса, генерирующего события по нажатию на клавиши управления курсором (EventLoop с пары), 
// реализовать консольное приложение, позволяющее управлять персонажем, перемещающимся по карте. 
// Карта состоит из свободного пространства и стен, и должна грузиться из файла. 
// Приложение должно отображать карту и персонажа (символом @) в окне консоли, и позволять персонажу перемещаться по карте, 
// реагируя на клавиши управления курсором. Будут полезны свойства Console.CursorLeft и Console.CursorTop.
