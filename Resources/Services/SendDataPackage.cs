using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientLib.Resources.Services
{
    public class DataPackage
    {
        public static void SendDataPackage(Connection.DataPackage.Template.DataPackage dataPackage)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Connection.DataPackage.Template.DataPackage));
                if (ServerResources.stream.CanWrite)
                {
                    xmlSerializer.Serialize(ServerResources.stream, dataPackage);
                }
                else
                {
                    Events.ErrorEvents.NetworkStreamError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Es können keine Datenpakete an den Server gesendet werden!" });
                }
            }
            catch
            {
                Events.ErrorEvents.ConnectionError.OnAppear(new Events.Args.EventArgs.ErrorEventArgs() { ErrorMessage = "Fehler beim Datenaustausch mit dem Server!" });
            }
        }

        public static void SendCallback()
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = "callback_server", Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DataExchange, Params = "NULL"});
            Console.WriteLine("callback sent");
        }

        public static void SendSongListRequest()
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = "send_songs", Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DataExchange, Params = "NULL" });
        }

        public static void SendSongRequest(string fileName)
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = fileName, Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DownloadRequest, Params = "NULL" });
        } 

        public static void SendSearchQuery(string search)
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = "song_query:request", Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DataExchange, Params = search });
        }
        public static void SendHomeScreenRequest()
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = "send_home_screen", Params = "NULL", Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DataExchange });
        }

        public static void SendSongClickMessage(string FileName)
        {
            SendDataPackage(new Connection.DataPackage.Template.DataPackage() { Data = "song_clicked", Name = Connection.DataPackage.PackageManager.GetPackageName(), Packet = Connection.DataPackage.Template.PacketKind.DataExchange, Params = FileName });
        }

        //public static 
    }
}
