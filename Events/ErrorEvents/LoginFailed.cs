using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ErrorEvents
{
    public class LoginFailed
    {
        public static event EventHandler.ErrorEventHandler LoginFailedEvent;
        public static void OnAppear(Args.EventArgs.ErrorEventArgs args)
        {
            if(LoginFailedEvent != null)
            {
                LoginFailedEvent(args);
            }
        }
    }
}
