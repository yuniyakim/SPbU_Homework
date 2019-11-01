using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1
{
    public class Server
    {
        private TcpListener tcpListener;
        private Client client;
        private int port;
        static Thread listenThread;

        protected internal void AddConnection(Client clientObject)
        {
            client= clientObject;
        }
        protected internal void RemoveConnection()
        {
            client = null;
        }

        protected internal async Task Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Console.WriteLine("Server launched. Waiting for connections.");

                while (true)
                {
                    var tcpClient = tcpListener.AcceptTcpClient();

                    client = new Client(port, tcpClient, this);
                    await client.Process();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal async Task SendMessage(string message, TcpClient tcpClient)
        {
            try
            {
                using (var stream = (tcpClient as TcpClient).GetStream())
                {
                    var streamWriter = new StreamWriter(stream);
                    await streamWriter.WriteLineAsync(message);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                (tcpClient as TcpClient).Close();
            }
        }

        protected internal void Disconnect()
        {
            tcpListener.Stop();
            client.Close();
            Environment.Exit(0);
        }

        public async Task ServerProcess()
        {
            try
            {
                await Listen();
            }
            catch (Exception ex)
            {
                Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
