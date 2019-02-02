using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.FileManager
{
    class DirectoryAvailabilityChecker
    {
        public static void CheckDirectories()
        {
            if(!Directory.Exists(Environment.CurrentDirectory + "\\Settings"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Settings");
            }

            if (!Directory.Exists(Environment.CurrentDirectory + "\\Files"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Files");
            }

            if(!Directory.Exists(Environment.CurrentDirectory + "\\Log"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Log");
            }
            if(!Directory.Exists(Environment.CurrentDirectory + "\\Data"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Data");
            }
        }
    }
}
