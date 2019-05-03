using System;

namespace _6._2
{
    public class Move : IMove
    {
        private Game game;

        /// <summary>
        /// Move's constructor
        /// </summary>
        /// <param name="game"></param>
        public Move(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// Going up
        /// </summary>
        public void Up(object sender, EventArgs args)
        {
            if (game.Field.Field[game.Character.Y - 1, game.Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('.');
            game.Character.Move("up");
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going down
        /// </summary>
        public void Down(object sender, EventArgs args)
        {
            if (game.Field.Field[game.Character.Y + 1, game.Character.X] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('.');
            game.Character.Move("down");
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going right
        /// </summary>
        public void Right(object sender, EventArgs args)
        {
            if (game.Field.Field[game.Character.Y, game.Character.X + 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('.');
            game.Character.Move("right");
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('@');
        }

        /// <summary>
        /// Going left
        /// </summary>
        public void Left(object sender, EventArgs args)
        {
            if (game.Field.Field[game.Character.Y, game.Character.X - 1] == '#')
            {
                throw new InvalidMoveException();
            }
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('.');
            game.Character.Move("left");
            Console.SetCursorPosition(game.Character.X, game.Character.Y);
            Console.Write('@');
        }
    }
}
