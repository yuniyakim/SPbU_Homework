using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            const int port = 8888;
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Listening on port {port}...");
            while (true)
            {
                var socket = await listener.AcceptSocketAsync();
                Task.Run(async () => {
                    var stream = new NetworkStream(socket);
                    var reader = new StreamReader(stream);
                    var data = await reader.ReadLineAsync();
                    Console.WriteLine($"Received: {data}");
                    Console.WriteLine($"Sending \"Hi!\"");
                    var writer = new StreamWriter(stream);
                    await writer.WriteAsync("Hi!");
                    await writer.FlushAsync();
                    socket.Close();
                });
            }
        }
    }
}
