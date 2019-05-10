using System;
using System.IO;

namespace _2._1
{
    public class Program
    {
        static void Main()
        {
            var path = Directory.GetCurrentDirectory() + "../../../../2.1.txt";
            var str =  new string[50];
            var index = 0;
            var input = "";
            try
            {
                using (var sr = new StreamReader(path))
                {
                    while ((input = sr.ReadLine()) != null)
                    {
                        str[index] = input;
                        ++index;
                    }
                }
                var sortedSet = new SortedSet<string>();
                sortedSet.Fill(str);
                sortedSet.Sort();
                sortedSet.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
