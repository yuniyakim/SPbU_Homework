using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FTP
{
    /// <summary>
    /// TCP server
    /// </summary>
    public class Server
    {
        private int port;
        private TcpListener listener;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private int amountOfTasks = 0;
        private static Object lockObject = new Object();
        private AutoResetEvent stopListener = new AutoResetEvent(false);

        /// <summary>
        /// Server's constructor
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public Server(int port, string hostname = "127.0.0.1")
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Parse(hostname), port);
        }

        /// <summary>
        /// Requests list of files in server's directory
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <param name="stream">Stream for writing</param>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        private async Task List(string path, StreamWriter stream)
        {
            if (!Directory.Exists(path))
            {
                await stream.WriteLineAsync("-1");
                return;
            }

            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            await stream.WriteLineAsync($"{directories.Length + files.Length}");
            foreach (var directory in directories)
            {
                await stream.WriteLineAsync(directory);
                await stream.WriteLineAsync("true");
            }
            foreach (var file in files)
            {
                await stream.WriteLineAsync(file);
                await stream.WriteLineAsync("false");
            }
        }

        /// <summary>
        /// Requests file downloading from the server
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="stream">Stream for writing</param>
        /// <returns><size: Long> <content: Bytes></returns>
        private async Task Get(string path, StreamWriter stream)
        {
            if (!File.Exists(path))
            {
                await stream.WriteLineAsync("-1");
                return;
            }

            await stream.WriteLineAsync($"{new FileInfo(path).Length}");
            using (var fileStream = File.OpenRead(path))
            {
                await fileStream.CopyToAsync(stream.BaseStream);
            }
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        public async Task Start()
        {
            listener.Start();

            while (!cts.Token.IsCancellationRequested)
            {
                await Process(listener.AcceptTcpClient());
            }

            listener.Stop();
        }

        /// <summary>
        /// Executes process
        /// </summary>
        /// <param name="client">Incoming TCP client</param>
        /// <returns></returns>
        private async Task Process(TcpClient client)
        {
            try
            {
                lock (lockObject)
                {
                    ++amountOfTasks;
                }

                using (var stream = client.GetStream())
                {
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream) { AutoFlush = true };

                    var request = await reader.ReadLineAsync();
                    var path = await reader.ReadLineAsync();

                    switch (request)
                    {
                        case "1":
                            {
                                await List(path, writer);
                                break;
                            }
                        case "2":
                            {
                                await Get(path, writer);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }
                    }
                    client.Close();
                }

                lock (lockObject)
                {
                    --amountOfTasks;
                }
                stopListener.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Close();

                lock (lockObject)
                {
                    --amountOfTasks;
                }
                stopListener.Set();
            }
        }

        /// <summary>
        /// Shutdowns server
        /// </summary>
        public void Shutdown()
        {
            cts.Cancel();

            while (true)
            {
                lock (lockObject)
                {
                    if (amountOfTasks == 0)
                    {
                        break;
                    }
                }
                stopListener.WaitOne();
            }
        }
    }
}
