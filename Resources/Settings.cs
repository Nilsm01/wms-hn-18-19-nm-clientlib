using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Resources
{
    public class Settings
    {
        public string ip_address;
        public int port;
        public string lastUsername;
        public string password;
        public bool logDataPackages;
        public bool autoLogin;

        public Settings(string IP, int Port, string LastUsername, bool LogDataPackages, string Password, bool AutoLogin)
        {
            ip_address = IP;
            port = Port;
            autoLogin = AutoLogin;
            lastUsername = LastUsername;
            logDataPackages = LogDataPackages;
            password = Password;
        }
    }
}
