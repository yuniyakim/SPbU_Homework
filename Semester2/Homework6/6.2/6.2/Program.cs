using System;

namespace _6._2
{
    public class Program
    {
        static void Main()
        {
            var eventLoop = new EventLoop();
            var game = new Game();
            eventLoop.UpHandler += game.Up;
            eventLoop.DownHandler += game.Down;
            eventLoop.RightHandler += game.Right;
            eventLoop.LeftHandler += game.Left;
            eventLoop.Move();
            var map = new GameMap();
            map.ReadAndFill();
        }
    }
}

// На базе класса, генерирующего события по нажатию на клавиши управления курсором (EventLoop с пары), 
// реализовать консольное приложение, позволяющее управлять персонажем, перемещающимся по карте. 
// Карта состоит из свободного пространства и стен, и должна грузиться из файла. 
// Приложение должно отображать карту и персонажа (символом @) в окне консоли, и позволять персонажу перемещаться по карте, 
// реагируя на клавиши управления курсором. Будут полезны свойства Console.CursorLeft и Console.CursorTop.
