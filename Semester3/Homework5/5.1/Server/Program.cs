using System;
using System.Threading.Tasks;

namespace FTP
{
    public class Program
    {
        public static void Main()
        {
            const int port = 8888;
            var server = new Server(port);
            Task.Run(async () => await server.Start());
            Console.ReadKey();
            server.Shutdown();
        }
    }
}
