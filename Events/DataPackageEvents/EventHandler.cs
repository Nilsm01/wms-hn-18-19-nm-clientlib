using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.DataPackageEvents
{
    public class EventHandler
    {
        public delegate void DataPackageEventHandler(Args.EventArgs.DataPackageEventArgs DataPackageEventArgs);
    }
}
