using System;

namespace _1._3
{
    class Program
    {
        private static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int k = 0; k < array.Length - i - 1; ++k)
                {
                    if (array[k] > array[k + 1])
                    {
                        int temp = array[k];
                        array[k] = array[k + 1];
                        array[k + 1] = temp;
                    }
                }
            }
            return array;
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }
        private static void Main(string[] args)
        {
            int[] array = { 10, 6, 13, 4, 7, 8, 11, 1, 2, 7, 3};
            BubbleSort(array);
            PrintArray(array);
        }
    }
}
