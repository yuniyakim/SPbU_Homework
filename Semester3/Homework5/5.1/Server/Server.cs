using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// TCP server
    /// </summary>
    public class Server
    {
        private int port;
        private TcpListener listener;
        private CancellationTokenSource cts = new CancellationTokenSource();

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
            await stream.WriteLineAsync(directories.Length + files.Length + " ");
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
            if (!Directory.Exists(path))
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

        public async Task Start()
        {
            listener.Start();

            while (!cts.Token.IsCancellationRequested)
            {
                await Process(listener.AcceptTcpClient());
            }

            listener.Stop();
        }

        private async Task Process(TcpClient client)
        {
            try
            {
                using (var stream = client.GetStream())
                {
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream);

                    var request = await reader.ReadLineAsync();
                    var path = await reader.ReadLineAsync();

                    switch (request)
                    {
                        case "1":
                            {
                                await List(path, writer); // ?????
                                break;
                            }
                        case "2":
                            {
                                await Get(path, writer); // ?????
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Close();
            }
        }

        public void Shutdown()
        {
            cts.Cancel();
        }
    }
}
/*List, формат запроса:

<1: Int> <path: String>
path — путь к директории относительно того места, где запущен сервер
Например, "1 ./Test/Files".

Формат ответа:

<size: Int> (<name: String> <isDir: Boolean>)*,
size — количество файлов и папок в директории
name — название файла или папки
isDir — флаг, принимающий значение True для директорий
Например, "2 ./Test/files/file1.txt false ./Test/files/directory true"

Если директории не существует, сервер посылает ответ с size = -1

Get, формат запроса:

<2: Int> <path: String>
path — путь к файлу
Формат ответа:

<size: Long> <content: Bytes>,
size — размер файла,
content — его содержимое
Если файла не существует, сервер посылает ответ с size = -1*/

    

            //var rootDirectory = Directory.GetCurrentDirectory();// + "/../../../";
            //Console.WriteLine(rootDirectory);
            //rootDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(rootDirectory)));
            //Console.WriteLine(rootDirectory);