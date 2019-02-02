using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class FileDownloaded
    {
        public static event EventHandler.ClientEventHandler FileDownloadedEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (FileDownloadedEvent != null)
            {
                FileDownloadedEvent(args);
            }
        }
    }
}
