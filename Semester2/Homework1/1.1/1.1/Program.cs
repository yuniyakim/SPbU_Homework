using System;

namespace _1._1
{
    class Program
    {

        static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Result: {Factorial(4)}");
        }
    }
}
