using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class ServerMaintenance
    {
        public static event EventHandler.ServerEventHandler ServerMaintenanceEvent;
        public static void OnAppear(Args.EventArgs.ServerEventArgs args)
        {
            if (ServerMaintenanceEvent != null)
            {
                ServerMaintenanceEvent(args);
            }
        }
    }
}
