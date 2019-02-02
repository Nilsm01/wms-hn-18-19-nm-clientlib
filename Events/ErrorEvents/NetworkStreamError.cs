using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ErrorEvents
{
    public class NetworkStreamError
    {
        public static event EventHandler.ErrorEventHandler NetworkStreamErrorEvent;
        public static void OnAppear(Args.EventArgs.ErrorEventArgs args)
        {
            if (NetworkStreamErrorEvent != null)
            {
                NetworkStreamErrorEvent(args);
            }
        }
    }
}
