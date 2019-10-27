using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// TCP client
    /// </summary>
    public class Client
    {
        private TcpClient TcpClient;

        /// <summary>
        /// Client's constructor
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public Client(string hostname, int port)
        {
            TcpClient = new TcpClient(hostname, port);
        }

        /// <summary>
        /// Requests list of files in server's directory
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        public async Task List(string path)
        {

        }

        /// <summary>
        /// Requests file downloading from the server
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns><size: Long> <content: Bytes></returns>
        public async Task Get(string path)
        {

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
