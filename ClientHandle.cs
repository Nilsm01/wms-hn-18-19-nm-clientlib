using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLib
{
    public class ClientHandle
    {
        public static void ConnectToServer()
        {
            //Verzeichnisse und Dateien die zur Laufzeit benötigt werden, werden überprüft
            FileManager.DirectoryAvailabilityChecker.CheckDirectories();
            FileManager.FileAvailabilityChecker.CheckFiles();

            //Resourcen werden initialisiert
            Resources.ServerResources.InitializeConnectionResources();

            //Login wird vorbereitet
            Resources.ServerResources.LoginForm = new Login.Login();

            //User Profil wird initialisiert
            UserProfile.Manager.Initialize();

            //Verbindung wird mit angegebenen Login-Daten aufgebaut
            Thread th = new Thread(new ThreadStart(Connection.ConnectionHandler.EstablishConnection));
            th.IsBackground = true;
            th.Start();
            

        }
    }
}
