using System;
using System.IO;
using System.Net;

namespace PictureDownloader
{
    class Interfaces
    {
        public static byte[] getHttpRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            int len = (int)response.ContentLength, off = 0;
            byte[] buff;
            if (len == -1)
            {
                byte[] temp = new byte[1024];
                len = 1024;
                int t = 0;
                while (true)
                {
                    off += stream.Read(temp, off, len - off - 1);
                    temp[off++] = (byte)(t = stream.ReadByte());
                    if (t == -1) break;
                    if (off == len)
                    {
                        buff = new byte[len << 1];
                        Buffer.BlockCopy(temp, 0, buff, 0, len);
                        len <<= 1;
                        temp = buff;
                    }
                }
                buff = new byte[off - 1];
                Buffer.BlockCopy(temp, 0, buff, 0, off - 1);
            }
            else
            {
                buff = new byte[len];
                while (off < len)
                {
                    off += stream.Read(buff, off, len - off);
                }
            }
            response.Close();
            return buff;
        }

        public static void updateProgress(int current, int max)
        {
            Form1.f.updateProgress(current, max);
        }

        private static object fsl = new object();

        public static string writeToFile(string filename, string extension, byte[] content)
        {
            FileStream fs;
            filename = Config.getOutput() + filename;
            lock(fsl)
            {
                if (File.Exists(filename + extension))
                {
                    int i;
                    for (i = 1; File.Exists(filename + "(" + i + ")" + extension); ++i) ;
                    fs = new FileStream(filename = filename + "(" + i + ")" + extension, FileMode.Create);
                }
                else fs = new FileStream(filename = filename + extension, FileMode.Create);
            }
            fs.Write(content, 0, content.Length);
            fs.Close();
            return filename;
        }

        public static void log(string log)
        {
            Form1.f.log(log);
        }
    }
}
