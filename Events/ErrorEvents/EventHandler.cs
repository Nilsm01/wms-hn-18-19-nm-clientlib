using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ErrorEvents
{
    public class EventHandler
    {
        public delegate void ErrorEventHandler(Args.EventArgs.ErrorEventArgs ErrorEventArgs);
    }
}
