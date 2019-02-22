using System;

namespace _1._4
{
    class Program
    {
        private static int[,] CreateAndFullfillMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Random random = new Random();
                    matrix[i, j] = random.Next(1, 10);
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        private static void MatrixTraversal(int[,] matrix)
        {
            int step = 1;
            int size = matrix.GetLength(0);
            int x = size / 2;
            int y = x;
            int sign = 1;
            while (true)
            {
                for (int i = 0; i < step; ++i) // going down/up
                {
                    Console.Write($"{matrix[y, x]} ");
                    y -= sign;
                }
                if (step * step == matrix.Length)
                {
                    Console.Write("\n");
                    break;
                }
                for (int j = 0; j < step; ++j) // going right/left
                {
                    Console.Write($"{matrix[y, x]} ");
                    x += sign;
                }
                step += 1;
                sign = -sign;
            }
        }

        private static void Main(string[] args)
        {
            int size = 0;
            Console.WriteLine("Enter a size of matrix");
            var input = Console.ReadLine();
            size = int.Parse(input);
            while (size % 2 == 0 || size < 0)
            {
                Console.WriteLine("Invalid size");
                Console.WriteLine("Enter a size of matrix");
                input = Console.ReadLine();
                size = int.Parse(input);
            }
            int[,] matrix = CreateAndFullfillMatrix(size);
            PrintMatrix(matrix);
            MatrixTraversal(matrix);
        }
    }
}
