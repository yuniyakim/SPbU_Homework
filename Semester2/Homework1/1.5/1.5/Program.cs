using System;

namespace _1._5
{
    class Program
    {
        private static int[,] BubbleSort(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < columns; ++i)
            {
                for (int k = 0; k < columns - i - 1; ++k)
                {
                    if (array[0, k]  > array[0, k + 1])
                    {
                        for (int j = 0; j < rows; ++j)
                        {
                            int temp = array[j, k];
                            array[j, k] = array[j, k + 1];
                            array[j, k + 1] = temp;
                        }
                    }
                }
            }
            return array;
        }
        private static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        private static void Main(string[] args)
        {
            int[,] array = { { 10, 6, 13, 4, 7 }, { 6, 5, 8, 11, 3}, { 2, 8, 12, 9, 4 } };
            PrintArray(array);
            BubbleSort(array);
            PrintArray(array);
        }
    }
}
