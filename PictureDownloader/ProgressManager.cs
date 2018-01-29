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
                    Interfaces.log($"开始处理 {url} (#{processing})");
                    byte[] data = getData(url);
                    int off = url.IndexOf(':') + 1;
                    string _protocol = url.Substring(0, off);
                    off = url.IndexOf('/', off + 2);
                    string _domain = url.Substring(0, off);
                    off = url.IndexOf('?');
                    if (off == -1) off = url.LastIndexOf('/');
                    else off = url.LastIndexOf('/', off);
                    string _path = url.Substring(0, off + 1);
                    // f3 表示是否在一对 <script></script>内
                    bool f3 = false;
                    // f1 为 0 时表示不在一对 <img> 内
                    //    >= 1 时表示在 <img> 内
                    //    为 2 时表示发现了 src=
                    // f2 为 0 时表示不在一对引号内
                    //    为 1 时表示在 "" 内
                    //    为 2 时表示在 '' 内
                    // f4 表示在一个tag中的位置
                    //  <tag attrib1 = "value" attrib2 attrib3 = value>
                    // =0000122222223445555551122222223222222234455555== (tag = img)
                    // =0000------------------------------------------== (tag != img)
                    // '-' = -1
                    // '=' = -2
                    sbyte f1 = 0, f2 = 0, f4 = -2;
                    int mark = -1;
                    for (int i = 0; i < data.Length; ++i)
                    {
                        if (f2 != 0)
                        {
                            if (data[i] == '\\') ++i;
                            else if (f2 == ((data[i] == '\"') ? 1 : (data[i] == '\'') ? 2 : -1))
                            {
                                f2 = 0;
                                if (f4 == 5)
                                {
                                    if (f1 == 2)
                                    {
                                        save(_protocol, _domain, _path, Encoding.Default.GetString(data, mark, i - mark));
                                        f1 = 1;
                                    }
                                    f4 = 1;
                                }
                            }
                        }
                        else if (data[i] == '<')
                        {
                            if (f4 == -2) {
                                mark = i + 1;
                                f4 = 0;
                            }
                        }
                        else if (data[i] == '>')
                        {
                            if (f4 == 0)
                            {
                                string name = Encoding.Default.GetString(data, mark, i - mark);
                                if (f3)
                                {
                                    if (name.Equals("/script")) f3 = false;
                                }
                                else
                                {
                                    if (name.Equals("script")) f3 = true;
                                }
                            }
                            f1 = 0;
                            f4 = -2;
                        }
                        else if (data[i] == ' ')
                        {
                            if (f4 == 0)
                            {
                                f4 = -1;
                                string name = Encoding.Default.GetString(data, mark, i - mark);
                                if (f3)
                                {
                                    if (name.Equals("/script")) f3 = false;
                                    else f4 = -2;
                                }
                                else
                                {
                                    if (name.Equals("script")) f3 = true;
                                    else if (name.Equals("img")) f1 = f4 = 1;
                                }
                            }
                            else if (f4 == 2)
                            {
                                if (Encoding.Default.GetString(data, mark, i - mark).Equals("src")) f1 = 2;
                                f4 = 3;
                            }
                            else if (f4 == 5)
                            {
                                if (f1 == 2)
                                {
                                    save(_protocol, _domain, _path, Encoding.Default.GetString(data, mark, i - mark));
                                    f1 = 1;
                                }
                                f4 = 1;
                            }
                        }
                        else if (data[i] == '=')
                        {
                            if ((f4 == 2) && Encoding.Default.GetString(data, mark, i - mark).Equals("src")) f1 = 2;
                            if (f1 != 0) f4 = 4;
                        }
                        else if ((data[i] == '\'') || (data[i] == '\"'))
                        {
                            if (f4 != -2)
                            {
                                f2 = (data[i] == '\"') ? (sbyte)1 : (sbyte)2;
                                if ((f4 == 1) || (f4 == 4))
                                {
                                    ++f4;
                                    mark = i + 1;
                                }
                                else if (f4 == 3)
                                {
                                    f4 = 2;
                                    mark = i + 1;
                                }
                            }
                        }
                        else if (f4 != -2) // 假装这边都是字母，反正正常情况也不会有别的了
                        {
                            if ((f4 == 1) || (f4 == 3))
                            {
                                mark = i;
                                f4 = 2;
                            }
                            else if (f4 == 4)
                            {
                                mark = i;
                                f4 = 5;
                            }
                        }
                    }
                    Interfaces.log("处理完成 #" + processing);
                }
                finWork();
            }
        }

        private static void save(string _protocol, string _domain, string _path, string partUrl)
        {
            if (partUrl.IndexOf(':') != -1) save(partUrl);
            else if (partUrl.StartsWith("//")) save(_protocol + partUrl);
            else if (partUrl[0] == '/') save(_domain + partUrl);
            else save(_path + partUrl);
        }

        private static void save(string url)
        {
            string fn, ext, showurl = url;
            if (url.StartsWith("data:"))
            {
                fn = "data";
                if (url.IndexOf("image/png") != -1) ext = ".png";
                else if (url.IndexOf("image/jpg") != -1) ext = ".jpg";
                else if (url.IndexOf("image/jpeg") != -1) ext = ".jpeg";
                else if (url.IndexOf("image/gif") != -1) ext = ".gif";
                else if (url.IndexOf("image/bmp") != -1) ext = ".bmp";
                else if (url.IndexOf("image/svg+xml") != -1) ext = ".svg";
                else if (url.IndexOf("image/webp") != -1) ext = ".webp";
                else if (url.IndexOf("image/x-icon") != -1) ext = ".ico";
                else ext = "";
                showurl = url.Substring(0, url.IndexOf(',') + 5) + "…" + url.Substring(url.Length - 28, 28);
            }
            else
            {
                int o2 = url.IndexOf('?');
                int o1 = (o2 == -1 ? url.LastIndexOf('/') : url.LastIndexOf('/', o2)) + 1;
                int p = url.IndexOf('.', o1);
                if (p == -1)
                {
                    fn = url.Substring(o1);
                    ext = "";
                }
                else
                {
                    fn = url.Substring(o1, p - o1);
                    ext = o2 == -1 ? url.Substring(p) : url.Substring(p, o2 - p);
                }
            }
            Interfaces.log("下载并保存 " + showurl);
            try
            {
                Interfaces.log("已将 " + showurl + " 保存至 " + Interfaces.writeToFile(fn, ext, getData(url)));
            }
            catch(WebException e)
            {
                Interfaces.log("下载并保存 " + showurl + " 失败：" + e.Message);
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
