using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ServerEvents
{
    public class FileNotFound
    {
        public static event EventHandler.ServerEventHandler FileNotFoundEvent;
        public static void OnAppear(Args.EventArgs.ServerEventArgs args)
        {
            if (FileNotFoundEvent != null)
            {
                FileNotFoundEvent(args);
            }
        }
    }
}
