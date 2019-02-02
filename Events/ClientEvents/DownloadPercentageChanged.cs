using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class DownloadPercentageChanged
    {
        public static event EventHandler.ClientEventHandler DownloadPercentageChangedEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (DownloadPercentageChangedEvent != null)
            {
                DownloadPercentageChangedEvent(args);
            }
        }
    }
}
