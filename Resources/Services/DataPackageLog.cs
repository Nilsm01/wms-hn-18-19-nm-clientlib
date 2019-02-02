using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.Resources.Services
{
    public class DataPackageLog
    {
        private static bool logDataPackages;

        public static bool LogDataPackages
        {
            set
            {
                logDataPackages = value;
                LogInitialize();
                UpdateSettings(logDataPackages);
            }
            get
            {
                return logDataPackages;
            }
        }

        private static void LogInitialize()
        {
            if (LogDataPackages)
                Events.DataPackageEvents.DataExchangeReceived.DataExchangeReceivedEvent += EnableLogDataPackage;
        }

        private static void EnableLogDataPackage(Events.Args.EventArgs.DataPackageEventArgs args)
        {
            try
            {
                string data = JsonConvert.SerializeObject(args.dataPackage);
                FileManager.FileAvailabilityChecker.CheckFiles();
                StreamWriter STW = File.AppendText(Environment.CurrentDirectory + "\\Log\\log.json");
                STW.WriteLine(data);
                STW.Close();
            }
            catch
            {
                Events.ErrorEvents.IOError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehler beim speichern einer Log-Datei!" });
            }           
        }

        private static void UpdateSettings(bool LogStatus)
        {
            Settings settings = new Settings(ServerResources.IPAddress, ServerResources.Port, ServerResources.LastUsername, LogStatus, ServerResources.Password, ServerResources.AutoLogin);
            FileCreater.UpdateSettingsFile(settings);
        }
    }
}
