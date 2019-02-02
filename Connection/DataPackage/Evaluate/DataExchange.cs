using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection.DataPackage.Evaluate
{
    class DataExchange
    {
        public static void GetInformation(Template.DataPackage dataPackage)
        {
            if(dataPackage.Data == "client_callback")
            {
                Resources.Services.DataPackage.SendDataPackage(new Template.DataPackage() { Data = "callback_reply", Name = PackageManager.GetPackageName(), Packet = Template.PacketKind.DataExchange, Params = "NULL" });
            }
            else if(dataPackage.Data == "callback_reply")
            {
                Console.WriteLine("Callback Reply received");
            }
            else if(dataPackage.Data == "server_kick")
            {
                Events.ServerEvents.KickedFromServer.OnAppear(new Events.Args.EventArgs.ServerEventArgs() { Param = dataPackage.Params });
            }
            else if(dataPackage.Data == "song_incoming")
            {
                Download.ServerInterface.DownloadSong(dataPackage.Params.Split(':')[0], Convert.ToInt32(dataPackage.Params.Split(':')[1]));
            }
            else if(dataPackage.Data == "song_list")
            {
                Commands.SongListReceived.EvaluateList(dataPackage); 
            }
            else if(dataPackage.Data == "song_query:reply")
            {
                Resources.ServerCommandResponders.SongQuery.Evaluate(dataPackage.Params);
            }
            else if(dataPackage.Data == "home_screen:reply")
            {
                Resources.ServerCommandResponders.HomeScreen.Evaluate(dataPackage.Params);
            }
            else if(dataPackage.Data == "song_not_found")
            {
                Events.ServerEvents.FileNotFound.OnAppear(new Events.Args.EventArgs.ServerEventArgs());
            }
            else if(dataPackage.Data == "permission_error")
            {
                Events.ServerEvents.PermissonError.OnAppear(new Events.Args.EventArgs.ServerEventArgs() { Param = dataPackage.Params });
            }
        }
    }
}
