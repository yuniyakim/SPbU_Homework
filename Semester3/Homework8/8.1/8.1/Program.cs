using System;

namespace _8._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter path to directory:");
            var path = Console.ReadLine();
            var info = new Runner().Run("path");
        }
    }
}
