using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public static void writeToFile(string filename, byte[] content)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            fs.Write(content, 0, content.Length);
            fs.Close();
        }

        public static void log(string log)
        {
            Form1.f.log(log);
        }
    }
}
