using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Program
    {
        const int port = 8888;
        static TcpListener listener;
        static void Main()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Waiting for connections...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    var clientObject = new Server(client);

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}

// var path = Directory.GetCurrentDirectory() + "../../../../4.1.txt";