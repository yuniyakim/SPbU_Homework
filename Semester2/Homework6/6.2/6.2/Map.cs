using System;
using System.IO;

namespace _6._2
{
    /// <summary>
    /// Map's class
    /// </summary>
    public class Map
    {
        public int Height { get; private set; } = 0;
        public int Width { get; private set; } = 0;
        public char[,] Field { get; private set; } = { };

        /// <summary>
        /// Reads a map from a file and fills it with data
        /// </summary>
        /// <param name="path">Path to the file</param>
        public void ReadAndFill(string path)
        {
            var str = "";

            try
            {
                using (var sr = new StreamReader(path))
                {
                    str = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var symbol in str)
            {
                ++Width;
                if (symbol == '\n')
                {
                    break;
                }
            }
            Width -= 2;
            Height = (str.Length + 2) / (Width + 2);

            var current = 0;
            Field = new char[Height, Width];
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (str[current] != '#' && str[current] != '.')
                    {
                        throw new InvalidInputSymbolException();
                    }
                    Field[i, j] = str[current];
                    ++current;
                }
                current += 2;
            }
        }

        /// <summary>
        /// Prints a map
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    Console.Write(Field[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
