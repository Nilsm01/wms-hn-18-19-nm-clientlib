using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection
{
    class ConnectionHandler
    {
        public static void EstablishConnection()
        {
            try
            {
                while (!Login.Credentials.Check())
                {                       
                    if (Resources.ServerResources.client != null)
                    {
                        if (Resources.ServerResources.client.Connected)
                        {
                            Resources.ServerResources.stream.Close();
                            Resources.ServerResources.client.Close();
                        }
                    }
                    Resources.ServerResources.client = new System.Net.Sockets.TcpClient();
                    Resources.ServerResources.client.Connect(Resources.ServerResources.IPAddress, Resources.ServerResources.Port);
                    Resources.ServerResources.stream = new System.Net.Sockets.NetworkStream(Resources.ServerResources.client.Client);
                    if (Resources.ServerResources.AutoLogin)
                    {
                        Resources.ServerResources.Username = Resources.ServerResources.settings.lastUsername;
                        Resources.ServerResources.Password = Resources.ServerResources.settings.password;
                    }
                    else
                    {
                        Resources.ServerResources.LoginForm.ShowDialog();
                    }
                }
                Resources.ServerResources.LoginForm.Close();

                if (!Resources.ServerResources.AutoLogin)
                {
                    //Login-Daten werden gespeichert
                    Resources.ServerResources.settings.lastUsername = Crypto.Encrypt.String(Resources.ServerResources.Username);
                    Resources.ServerResources.settings.password = Crypto.Encrypt.String(Resources.ServerResources.Password);
                    Resources.Services.FileCreater.UpdateSettingsFile(Resources.ServerResources.settings);
                }
                
            }
            catch(System.Net.Sockets.SocketException)
            {
                Events.ErrorEvents.ConnectionError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Der Server ist zur Zeit nicht erreichbar." });
            }
            catch(System.IO.IOException)
            {
                Events.ErrorEvents.NetworkStreamError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehler beim beziehen des Network Streams aus dem Verbundenen Stream!" });
            }
            catch(Exception)
            {
                throw new Exception();
            }
            //Einkommende Daten vom Server werden empfangen
            TrafficHandler.HandleServerTraffic();
        }
    }
}
