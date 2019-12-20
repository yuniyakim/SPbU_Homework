using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    public class Checksum
    {
        /// <summary>
        /// Calculates checksum recursively with single thread
        /// </summary>
        /// <param name="path">Incoming path</param>
        /// <returns>Checksum for incoming path</returns>
        public byte[] ChecksumSingleThreaded(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new InvalidPathException();
            }
            using (var md5 = MD5.Create())
            {
                if (Directory.Exists(path))
                {
                    var filesArray = Directory.GetFiles(path, "*").OrderBy(x => x).ToArray();
                    var str = Path.GetFileName(Path.GetDirectoryName(path));

                    foreach (var file in filesArray)
                    {
                        str += Encoding.ASCII.GetString(ChecksumSingleThreaded(file));
                    }

                    return md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                }
                else
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return md5.ComputeHash(stream);
                    }
                }
            }
        }

        /// <summary>
        /// Calculates checksum with multiple threads
        /// </summary>
        /// <param name="path">Incoming path</param>
        /// <returns>Checksum</returns>
        public async Task<byte[]> ChecksumMultipleThreaded(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new InvalidPathException();
            }
            using (var md5 = MD5.Create())
            {
                if (Directory.Exists(path))
                {
                    var filesArray = Directory.GetFiles(path, "*").OrderBy(x => x).ToArray();
                    var str = Path.GetFileName(Path.GetDirectoryName(path));

                    foreach (var file in filesArray)
                    {
                        str += await ChecksumMultipleThreaded(file);
                    }

                    return md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                }
                else
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return md5.ComputeHash(stream);
                    }
                }
            }
        }

        /// <summary>
        /// Compares working time of ChecksumSingleThreaded and ChecksumMultipleThreaded
        /// </summary>
        /// <param name="path">Incoming path</param>
        /// <returns>1 if ChecksumSingleThreaded is faster, -1 if ChecksumMultipleThreaded is faster, 0 otherwise</returns>
        public int Compare(string path)
        {
            var stopWatchSingle = new Stopwatch();
            stopWatchSingle.Start();
            ChecksumSingleThreaded(path);
            stopWatchSingle.Stop();

            var stopWatchMultiple = new Stopwatch();
            stopWatchMultiple.Start();
            var task = ChecksumMultipleThreaded(path);
            Task.WaitAll(task);
            stopWatchMultiple.Stop();

            return (stopWatchSingle.Elapsed > stopWatchMultiple.Elapsed ? 1 : (stopWatchSingle.Elapsed < stopWatchMultiple.Elapsed ? -1 : 0));
        }
    }
}
