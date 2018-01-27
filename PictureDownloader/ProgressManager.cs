using System;
using System.Net;
using System.Text;
using System.Threading;

namespace PictureDownloader
{
    class ProgressManager
    {
        private static int current, end, off, threads, fin;
        private static object lock1 = new object(), lock2 = new object();
        private static Random random = new Random();

        private static int getWork()
        {
            int rtn;
            lock(lock1)
            {
                if (current >= end) return -1;
                rtn = current;
                ++current;
            }
            return rtn + off;
        }

        private static void finWork()
        {
            lock(lock2)
            {
                Interfaces.updateProgress(++fin, end);
            }
            if (fin == end) Config.unlockConfig();
        }

        public static void startProgress()
        {
            Config.lockConfig();
            off = Config.getStart();
            end = Config.getEnd() - off + 1;
            fin = current = 0;
            Interfaces.updateProgress(0, end);
            threads = Config.getThreads();
            for (int i = 0; i < threads; ++i)
            {
                Thread t = new Thread(new ThreadStart(process));
                t.Name = "PictureDownloader Processer #" + i;
                t.Start();
            }
        }

        static void process()
        {
            int processing;
            while((processing = getWork()) != -1)
            {
                string url = Config.getURL().Replace("*", processing.ToString("D" + Config.getLength()));
                if (Config.getDirect()) save(url);
                else
                {
                }
                finWork();
            }
        }

        private static void save(string url)
        {
            string fn, ext;
            if (url.StartsWith("data:"))
            {
                fn = "data";
                if (url.IndexOf("image/png") != -1) ext = ".png";
                else if (url.IndexOf("image/jpeg") != -1) ext = ".jpg";
                else if (url.IndexOf("image/gif") != -1) ext = ".gif";
                else if (url.IndexOf("image/bmp") != -1) ext = ".bmp";
                else if (url.IndexOf("image/svg+xml") != -1) ext = ".svg";
                else if (url.IndexOf("image/webp") != -1) ext = ".webp";
                else if (url.IndexOf("image/x-icon") != -1) ext = ".ico";
                else ext = "";
            }
            else
            {
                int o2 = url.IndexOf('?');
                int o1 = (o2 == -1 ? url.LastIndexOf('/') : url.LastIndexOf('/', o2)) + 1;
                int p = url.IndexOf('.', o1);
                fn = url.Substring(o1, p - o1);
                ext = o2 == -1 ? url.Substring(p) : url.Substring(p, o2 - p);
            }
            Interfaces.log("下载并保存 " + url);
            try
            {
                Interfaces.log("已将 " + url + " 保存至 " + Interfaces.writeToFile(fn, ext, getData(url)));
            }
            catch(WebException e)
            {
                Interfaces.log("下载并保存 " + url + " 失败：" + e.Message);
            }
        }

        private static byte[] getData(string url)
        {
            string protocol = url.Substring(0, url.IndexOf(':'));
            if (protocol.Equals("data"))
            {
                bool isBase64 = url.IndexOf(";base64", 5) != -1;
                int start = url.IndexOf(',', 5) + 1;
                string content = url.Substring(start, url.Length - start);
                if (isBase64) return Convert.FromBase64String(content);
                start = url.IndexOf(";charset=", 5);
                if (start == -1) return Encoding.Default.GetBytes(content);
                int end1 = url.IndexOf(';', start + 9), end2 = url.IndexOf(',', start + 9);
                Encoding encoding = Encoding.GetEncoding(url.Substring(start + 9, (end1 == -1 ? end2 : Math.Min(end1, end2)) - start - 9));
                return encoding.GetBytes(content);
            }
            return Interfaces.getHttpRequest(url);
        }
    }
}
