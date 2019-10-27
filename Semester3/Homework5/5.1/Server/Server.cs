using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// TCP server
    /// </summary>
    public class Server
    {
        private TcpClient TcpClient;

        /// <summary>
        /// Client's constructor
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public Server(string hostname, int port)
        {
            TcpClient = new TcpClient(hostname, port);
        }

        /// <summary>
        /// Requests list of files in server's directory
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <param name="stream">Stream for writing</param>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        public async Task List(string path, StreamWriter stream)
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
        public async Task Get(string path, StreamWriter stream)
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

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = TcpClient.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    Console.WriteLine(message);
                    // отправляем обратно сообщение в верхнем регистре
                    message = message.Substring(message.IndexOf(':') + 1).Trim().ToUpper();
                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (TcpClient != null)
                    TcpClient.Close();
            }
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