using System;
using System.IO;

namespace _6._2
{
    /// <summary>
    /// Map's class
    /// </summary>
    public class Map
    {
        private int height = 0;
        private int width = 0;
        private char[,] map = { };

        /// <summary>
        /// Reads a map from a file and fills it with data
        /// </summary>
        public void ReadAndFill()
        {
            var path = Directory.GetCurrentDirectory() + "../../../../6.2.txt";
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
                ++width;
                if (symbol == '\n')
                {
                    break;
                }
            }
            width -= 2;
            height = (str.Length + 2) / (width + 2);

            var current = 0;
            map = new char[height, width];
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (str[current] != '#' && str[current] != '.')
                    {
                        throw new InvalidInputSymbolException("Invalid symbol in input file");
                    }
                    map[i, j] = str[current];
                    ++current;
                }
                current += 2;
            }
        }
    }
}
