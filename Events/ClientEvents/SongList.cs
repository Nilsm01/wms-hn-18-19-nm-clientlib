using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class SongList
    {
        public static event EventHandler.ClientEventHandler SongListEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (SongListEvent != null)
            {
                SongListEvent(args);
            }
        }
    }
}
