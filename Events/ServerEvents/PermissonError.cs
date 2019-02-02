using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class PermissonError
    {
        public static event EventHandler.ServerEventHandler PermissionErrorEvent;
        public static void OnAppear(Args.EventArgs.ServerEventArgs args)
        {
            if(PermissionErrorEvent != null)
            {
                PermissionErrorEvent(args);
            }
        }
    }
}
