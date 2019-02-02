using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class EventHandler
    {
        public delegate void ServerEventHandler(Args.EventArgs.ServerEventArgs ServerEventArgs);
    }
}
