using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLib.Resources
{
    class ServerResources
    {
        public static TcpClient client { get; set; }
        public static NetworkStream stream { get; set; }
        public static string IPAddress { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Form LoginForm { get; set; }
        public static Settings settings { get; set; }
        public static bool ConnectedToServer { get; set; }
        public static string LastUsername { get; set; }
        public static string[] HomeScreenItem1 { get; set; }
        public static string[] HomeScreenItem2 { get; set; }
        public static string[] HomeScreenItem3 { get; set; }
        public static string[] HomeScreenItem4 { get; set; }
        public static UserProfile.Template.UserProfile Profile { get; set; }
        public static byte[] ConnectionKey { get; set; }
        public static bool AutoLogin { get; set; }

        public static void InitializeConnectionResources()
        {
            // TODO Exceptions catchen
            settings = Services.FileLoader.LoadSettings();
            IPAddress = settings.ip_address;
            Port = settings.port;
            AutoLogin = settings.autoLogin;
            if (settings.lastUsername != "NULL" && settings.password != "NULL")
            {
                LastUsername = Crypto.Decrypt.String(settings.lastUsername);
                Password = Crypto.Decrypt.String(settings.password);
                settings.lastUsername = LastUsername;
                settings.password = Password;
            }
            else
            {
                LastUsername = settings.lastUsername;
                Password = settings.password;
            }
            Services.DataPackageLog.LogDataPackages = settings.logDataPackages;
        }
    }
}
