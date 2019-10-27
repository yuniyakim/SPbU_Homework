using System;
using System.Collections.Generic;
using System.IO;
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
        private int port;
        private TcpClient TcpClient;

        /// <summary>
        /// Client's constructor
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        public Client(string hostname, int port)
        {
            this.port = port;
            TcpClient = new TcpClient(hostname, port);
        }

        /// <summary>
        /// Requests list of files in server's directory
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <returns><size: Int> (<name: String> <isDir: Boolean>)</returns>
        public async Task<List<(string, bool)>> List(string path)
        {
            try
            {
                var client = new TcpClient("localHost", port);

                using (var stream = client.GetStream())
                {
                    var writer = new StreamWriter(stream);
                    await writer.WriteLineAsync("1 ");
                    await writer.WriteAsync(path);
                    var reader = new StreamReader(stream);
                    var amount = Convert.ToInt32(await reader.ReadLineAsync());

                    if (amount == -1)
                    {
                        Console.WriteLine("Directory doesn't exist");
                        return null;
                    }

                    var list = new List<(string, bool)>();
                    for (var i = 0; i < amount; ++i)
                    {
                        list.Add((await reader.ReadLineAsync(), Convert.ToBoolean(await reader.ReadLineAsync())));
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Requests file downloading from the server
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns><size: Long> <content: Bytes></returns>
        public async Task<byte[]> Get(string path)
        {
            try
            {
                var client = new TcpClient("localHost", port);

                using (var stream = client.GetStream())
                {
                    var writer = new StreamWriter(stream);// { AutoFlush = true };
                    await writer.WriteLineAsync("2 ");
                    await writer.WriteAsync(path);
                    var reader = new StreamReader(stream);
                    var size = Convert.ToInt32(await reader.ReadLineAsync());

                    if (size == -1)
                    {
                        Console.WriteLine("Directory doesn't exist");
                        return null;
                    }

                    var content = new byte[size];
                    await reader.BaseStream.ReadAsync(content, size.ToString().Length, size);
                    return content;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
