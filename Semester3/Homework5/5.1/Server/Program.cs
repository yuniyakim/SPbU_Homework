using System;
using System.Threading.Tasks;

namespace FTP
{
    public class Program
    {
        /// <summary>
        /// Starts the server and shutdowns it when user presses some key
        /// </summary>
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
