using System;

namespace _8._1
{
    /// <summary>
    /// Printer for info
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// Prints the results of tests
        /// </summary>
        /// <param name="info"/>Info about tests</param>
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

                Console.WriteLine($" | Time: {testInfo.Time}");
            }
        }
    }
}
