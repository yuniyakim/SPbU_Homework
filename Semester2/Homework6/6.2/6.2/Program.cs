using System;

namespace _6._2
{
    public class Program
    {
        static void Main()
        {
            var eventLoop = new EventLoop();
            var map = new GameMap();
            map.ReadAndFill();
            var game = new Game(map);
            Console.WriteLine("Enter starting coordinates of your player");
            Console.WriteLine("x = ");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine("y = ");
            var y = int.Parse(Console.ReadLine());
            if (x < 0 || y < 0 || map.Map[x, y] == '#')
            {
                throw new InvalidInitialCoordinatesException("Ivalid coordinates were entered");
            }
            game.SetInitialCoordinates(x, y);
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
