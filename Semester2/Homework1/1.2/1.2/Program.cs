using System;

namespace _1._2
{
    class Program
    {
        private static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of Fibonacci");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; ++i)
            {
                Console.WriteLine($"{Fibonacci(i)}");
            }
        }
    }
}
