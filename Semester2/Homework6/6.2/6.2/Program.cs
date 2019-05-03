using System;
using System.IO;

namespace _6._2
{
    public class Program
    {
        static void Main()
        {
            var path = Directory.GetCurrentDirectory() + "../../../../6.2.txt";
            var eventLoop = new EventLoop();
            var map = new Map();
            map.ReadAndFill(path);
            var game = new Game(map);
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
            var move = new Move(game);
            eventLoop.UpHandler += move.Up;
            eventLoop.DownHandler += move.Down;
            eventLoop.RightHandler += move.Right;
            eventLoop.LeftHandler += move.Left;
            eventLoop.Move();
        }
    }
}

// На базе класса, генерирующего события по нажатию на клавиши управления курсором (EventLoop с пары), 
// реализовать консольное приложение, позволяющее управлять персонажем, перемещающимся по карте. 
// Карта состоит из свободного пространства и стен, и должна грузиться из файла. 
// Приложение должно отображать карту и персонажа (символом @) в окне консоли, и позволять персонажу перемещаться по карте, 
// реагируя на клавиши управления курсором. Будут полезны свойства Console.CursorLeft и Console.CursorTop.
