using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection
{
    class TrafficHandler
    {
        public static void HandleServerTraffic()
        {
            //Client ist jetzt zum Server verbunden
            Resources.ServerResources.ConnectedToServer = true;

            //Das ConnectedToServer Event wurde ausgelöst d.h. die Verbindung zum Server wurde aufgebaut
            Events.ClientEvents.ConnectedToServer.OnAppear(new Events.Args.EventArgs.ClientEventArgs());

            Resources.Services.DataPackage.SendHomeScreenRequest();

            //Buffer für einkommende Datenpakete
            DataPackage.Template.DataPackage dataPackage;

            byte[] buffer = new byte[4096];
            while (Resources.ServerResources.client.Connected)
            {
                try
                {
                    //Daten werden gelesen, die Größe eines Datenpakets darf 4Kb nicht überschreiten
                    Resources.ServerResources.stream.Read(buffer, 0, buffer.Length);
                    //Daten werden in einen XML-string konvertiert
                    string Data = ASCIIEncoding.ASCII.GetString(buffer);
                    //XML-string wird in ein DataPackage Objekt konvertiert
                    dataPackage = Resources.XML.DeserializeFromXml<DataPackage.Template.DataPackage>(Data);   
                    //Datenpaket auswerten
                    DataPackage.Evaluation.EvaluateDataPackage(dataPackage);
                    //Buffer wird zurückgesetzt
                    Array.Clear(buffer, 0, buffer.Length);
                }
                catch(System.IO.IOException)
                {
                    Events.ErrorEvents.NetworkStreamError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehler beim lesen von Datenpaketen!" });
                }
                catch (ArgumentException)
                {
                    Events.ErrorEvents.EvaluationError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehlerhafte Daten vom Server empfangen!" });
                }
            }
        }
    }
}
