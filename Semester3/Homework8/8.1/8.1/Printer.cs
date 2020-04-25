using System;

namespace _8._1
{
    public class Printer
    {
        /// <summary>
        /// Print the results of tests
        /// <param name="info"/>Info about tests</param>
        /// </summary>
        public static void PrintResults(Info[] info)
        {
            foreach (var testInfo in info)
            {
                Console.Write("Name: " + testInfo.Name);
                Console.Write(" | Result: " + testInfo.Result);

                if (testInfo.Result != "Passed")
                {
                    Console.Write($" | Ignore reason: {testInfo.IgnoreReason}");
                }

                Console.WriteLine($" | time: {testInfo.Time}");
            }
        }
    }
}
