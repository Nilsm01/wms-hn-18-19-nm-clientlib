using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class KickedFromServer
    {
        public static event EventHandler.ServerEventHandler KickedFromServerEvent;
        public static void OnAppear(Args.EventArgs.ServerEventArgs args)
        {
            if (KickedFromServerEvent != null)
            {
                KickedFromServerEvent(args);
            }
        }
    }
}
