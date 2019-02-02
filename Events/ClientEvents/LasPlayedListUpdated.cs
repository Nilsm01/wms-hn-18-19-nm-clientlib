using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class LasPlayedListUpdated
    {
        public static event EventHandler.ClientEventHandler LastPlayedListUpdatedEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (LastPlayedListUpdatedEvent != null)
            {
                LastPlayedListUpdatedEvent(args);
            }
        }
    }
}
