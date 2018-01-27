using System.IO;

namespace PictureDownloader
{
    class Config
    {
        private static string _url = "";
        private static string _cookie = "";
        private static int _start = 1;
        private static int _end = 1;
        private static int _length = 0;
        private static string _output = "";
        private static bool _direct = false;
        private static int _threads = 4;
        private static bool locked = false;

        public static string getURL()
        {
            return _url;
        }

        public static bool setURL(string url)
        {
            if (locked) return false;
            if (url.IndexOf(':') == -1) _url = "http://" + url;
            else _url = url;
            return true;
        }

        public static string getCookie()
        {
            return _cookie;
        }

        public static bool setCookie(string cookie)
        {
            if (locked) return false;
            _cookie = cookie;
            return true;
        }

        public static int getStart()
        {
            return _start;
        }

        public static bool setStart(int start)
        {
            if (locked) return false;
            if (start > _end) return false;
            if (start < 1) return false;
            _start = start;
            return true;
        }

        public static int getEnd()
        {
            return _end;
        }

        public static bool setEnd(int end)
        {
            if (locked) return false;
            if (end < _start) return false;
            _end = end;
            return true;
        }

        public static int getLength()
        {
            return _length;
        }

        public static bool setLength(int length)
        {
            if (locked) return false;
            if (length < 0) return false;
            _length = length;
            return true;
        }

        public static string getOutput()
        {
            return _output;
        }

        public static bool setOutput(string output)
        {
            if (locked) return false;
            if (!Directory.Exists(output)) return false;
            _output = output.Replace('/', '\\');
            if (_output[_output.Length - 1] != '\\') _output += '\\';
            return true;
        }

        public static bool getDirect()
        {
            return _direct;
        }

        public static bool setDirect(bool direct)
        {
            if (locked) return false;
            _direct = direct;
            return true;
        }

        public static int getThreads()
        {
            return _threads;
        }

        public static bool setThreads(int threads)
        {
            if (locked) return false;
            if (threads < 1) return false;
            _threads = threads;
            return true;
        }

        public static void lockConfig()
        {
            locked = true;
        }
    
        public static void unlockConfig()
        {
            locked = false;
        }
    }
}
