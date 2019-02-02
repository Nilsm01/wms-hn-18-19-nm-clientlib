using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class SongQuery
    {
        public static event EventHandler.ClientEventHandler SongQueryEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (SongQueryEvent != null)
            {
                SongQueryEvent(args);
            }
        }
    }
}
