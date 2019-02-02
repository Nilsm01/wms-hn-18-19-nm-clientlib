using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class ConnectedToServer
    {
        public static event EventHandler.ClientEventHandler ConnectedToServerEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if(ConnectedToServerEvent != null)
            {
                ConnectedToServerEvent(args);
            }
        }
    }
}
