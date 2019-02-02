using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.FileManager
{
    class FileAvailabilityChecker
    {
        public static void CheckFiles()
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\Settings\\settings.json"))
            {
                Resources.Services.FileCreater.CreateSettingsFile();
            }

            if(!File.Exists(Environment.CurrentDirectory + "\\Log\\log.json"))
            {
                Resources.Services.FileCreater.CreateLogFile();
            }
        }
    }
}
