﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class LoginFailed
    {
        public static event EventHandler.ServerEventHandler LoginFailedEvent;
        public static void OnAppear(Args.EventArgs.ServerEventArgs args)
        {
            if (LoginFailedEvent != null)
            {
                LoginFailedEvent(args);
            }
        }
    }
}
