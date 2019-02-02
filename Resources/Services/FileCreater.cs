using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ClientLib.Resources.Services
{
    class FileCreater
    {
        public static void CreateSettingsFile()
        {
            Settings settings = new Settings("127.0.0.1", 12500, "NULL", false, "NULL", false);
            UpdateSettingsFile(settings);
        }

        public static void UpdateSettingsFile(Settings settings)
        {
            settings.lastUsername = Crypto.Encrypt.String(settings.lastUsername);
            settings.password = Crypto.Encrypt.String(settings.password);
            using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\Settings\\settings.json"))
            {
                STW.Write(JsonConvert.SerializeObject(settings));
            }
        }

        public static void CreateLogFile()
        {
            //File.Create(Environment.CurrentDirectory + "\\Log\\log.json");
            using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\Log\\log.json")) { }
        }
    }
}
