using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.ClientEvents
{
    public class HomeScreen
    {
        public static event EventHandler.ClientEventHandler HomeScreenReceivedEvent;
        public static void OnAppear(Args.EventArgs.ClientEventArgs args)
        {
            if (HomeScreenReceivedEvent != null)
            {
                HomeScreenReceivedEvent(args);
            }
        }
    }
}
