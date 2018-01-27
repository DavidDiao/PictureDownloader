using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureDownloader
{
    class ProgressManager
    {
        public static void startProgress()
        {
            Config.lockConfig();
        }
    }
}
