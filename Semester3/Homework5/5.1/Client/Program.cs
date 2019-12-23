using System;
using System.Text;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            const int port = 8888;
            var client = new Client(port);

            while (true)
            {
                var request = Console.ReadLine();
                if (request == "1")
                {
                    var path = Console.ReadLine();
                    var list = client.List(path).Result;
                    if (list != null)
                    {
                        Console.WriteLine(list.Count);
                        for (var i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i].Item1);
                            Console.WriteLine(list[i].Item2);
                        }
                    }
                }
                else if (request == "2")
                {
                    var path = Console.ReadLine();
                    var get = client.Get(path).Result;
                    if (get != null)
                    {
                        Console.WriteLine(Encoding.Default.GetString(get));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
