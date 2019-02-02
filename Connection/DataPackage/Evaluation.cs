using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection.DataPackage
{
    class Evaluation
    {
        public static void EvaluateDataPackage(Template.DataPackage dataPackage)
        {
            if(dataPackage.Packet == Template.PacketKind.DataExchange)
            {
                Evaluate.DataExchange.GetInformation(dataPackage);
                Events.DataPackageEvents.DataExchangeReceived.OnAppear(new Events.Args.EventArgs.DataPackageEventArgs() { dataPackage = dataPackage });
            }
            else if(dataPackage.Packet == Template.PacketKind.DownloadRequest)
            {
                Evaluate.DownloadRequest.GetInformation(dataPackage);
            }
            else if(dataPackage.Packet == Template.PacketKind.UploadRequest)
            {

            }
            else if(dataPackage.Packet == Template.PacketKind.Message)
            {

            }
            else if(dataPackage.Packet == Template.PacketKind.BugReport)
            {

            }
        }
    }
}
