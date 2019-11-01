using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace _1._1
{    public class Client
    {
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient tcpClient;
        private const string host = "127.0.0.1";
        private static NetworkStream stream;

        private int port;
        private Server server;

        public Client(int port, TcpClient tcpClient, Server server)
        {
            this.port = port;
            this.tcpClient = tcpClient;
            this.server = server;
            server.AddConnection(this);
        }

        public async Task Process()
        {
            try
            {
                Stream = tcpClient.GetStream();
                var message = await GetMessage();
                userName = message;
                await server.SendMessage("Connection established.", tcpClient);
                Console.WriteLine(message);

                while (true)
                {
                    try
                    {
                        message = await GetMessage();
                        Console.WriteLine($"{userName}: {message}");
                        await server.SendMessage(message, tcpClient);
                    }
                    catch
                    {
                        Console.WriteLine($"{userName}: left chat");
                        await server.SendMessage(message, tcpClient);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection();
                Close();
            }
        }

        protected internal async Task<string> GetMessage()
        {
            try
            {
                using (Stream)
                {
                    var reader = new StreamReader(Stream);
                    var message = await reader.ReadLineAsync();
                    return message;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                (tcpClient as TcpClient).Close();
                return null;
            }
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (tcpClient != null)
                tcpClient.Close();
        }

        protected internal async Task SendMessage()
        {
            Console.WriteLine("Enter your message: ");

            while (true)
            {
                var  message = Console.ReadLine();

                try
                {
                    using (Stream)
                    {
                        var streamWriter = new StreamWriter(Stream);
                        await streamWriter.WriteLineAsync(message);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    (tcpClient as TcpClient).Close();
                }
            }
        }

        protected internal async Task ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    string message;
                    using (Stream)
                    {
                        var streamReader = new StreamReader(Stream);
                        message = await streamReader.ReadLineAsync();
                    }
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Connection lost");
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        protected internal void Disconnect()
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
            Environment.Exit(0);
        }

        protected internal async Task ClientProcess()
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, port);
                var writer = new StreamWriter(tcpClient.GetStream());
                string message = userName;
                await writer.WriteLineAsync(message);
                await ReceiveMessage();
                Console.WriteLine($"Hello, {userName}");
                await SendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
