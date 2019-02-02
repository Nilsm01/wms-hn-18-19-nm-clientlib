using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ClientLib.Resources.Services
{
    class FileLoader
    {
        public static Settings LoadSettings()
        {
            Settings settings;
            using (StreamReader STR = new StreamReader(Environment.CurrentDirectory + "\\Settings\\settings.json"))
            {
                settings = JsonConvert.DeserializeObject<Settings>(STR.ReadToEnd());
            }

            return settings;
        }
    }
}
