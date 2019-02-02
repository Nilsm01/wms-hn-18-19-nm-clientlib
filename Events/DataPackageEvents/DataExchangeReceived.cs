using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.DataPackageEvents
{
    public class DataExchangeReceived
    {
        public static event EventHandler.DataPackageEventHandler DataExchangeReceivedEvent;
        public static void OnAppear(Args.EventArgs.DataPackageEventArgs args)
        {
            if(DataExchangeReceivedEvent != null)
            {
                DataExchangeReceivedEvent(args);
            }
        }
    }
}
