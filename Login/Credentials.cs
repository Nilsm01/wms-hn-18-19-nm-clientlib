using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLib.Login
{
    class Credentials
    {
        public static bool Check()
        {
            try
            {
                if (Resources.ServerResources.Username != string.Empty && Resources.ServerResources.Password != string.Empty)
                {
                    Resources.ServerResources.ConnectionKey = Crypto.Manager.getCryptoKey();
                    using (BinaryWriter writer = new BinaryWriter(Resources.ServerResources.stream, Encoding.UTF8, true))
                    {
                        writer.Write("LogIn");
                    }

                    using (BinaryWriter LoginWriter = new BinaryWriter(Resources.ServerResources.stream, Encoding.UTF8, true))
                    {
                        LoginWriter.Write(Encoding.Default.GetString(Resources.ServerResources.ConnectionKey));
                        LoginWriter.Write(Crypto.Encrypt.String(Resources.ServerResources.ConnectionKey ,Resources.ServerResources.Username));
                        LoginWriter.Write(Crypto.Encrypt.String(Resources.ServerResources.ConnectionKey, Resources.ServerResources.Password));
                    }

                    using (BinaryReader LoginReader = new BinaryReader(Resources.ServerResources.stream, Encoding.UTF8, true))
                    {
                        string Result = LoginReader.ReadString();
                        Console.WriteLine("reply received!");
                        if (Result == "login_successful")
                        {
                            return true;
                        }
                        else if (Result == "login_failed")
                        {
                            MessageBox.Show("Benutzername oder Passwort falsch!" + Resources.ServerResources.Password + Resources.ServerResources.Username, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Events.ServerEvents.LoginFailed.OnAppear(new Events.Args.EventArgs.ServerEventArgs());
                            if (Resources.ServerResources.AutoLogin)
                                Resources.ServerResources.AutoLogin = false;
                            return false;
                        }
                        else if (Result == "server_maintenance")
                        {
                            Form maintenanceScreen = new Resources.Services.MaintenanceScreen();
                            Resources.ServerResources.LoginForm.Hide();
                            maintenanceScreen.ShowDialog();
                            return false;
                        }
                        else
                        {
                            Events.ErrorEvents.ConnectionError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehler beim auswerten der Login-Reply vom Server" });
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
