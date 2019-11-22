using System;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        private const int port = 8888;
        public static void Main()
        {
            const int port = 8888;
            var server = new Server(port);
            // ?????
            Console.ReadKey();
            server.Shutdown();
        }
    }
}
