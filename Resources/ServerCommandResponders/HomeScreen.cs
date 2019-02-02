using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Resources.ServerCommandResponders
{
    class HomeScreen
    {
        public static void Evaluate(string Content)
        {
            string item1 = Content.Split('|')[0];
            ServerResources.HomeScreenItem1 = item1.Split(';');
            string item2 = Content.Split('|')[1];
            ServerResources.HomeScreenItem2 = item2.Split(';');
            string item3 = Content.Split('|')[2];
            ServerResources.HomeScreenItem3 = item3.Split(';');
            string item4 = Content.Split('|')[3];
            ServerResources.HomeScreenItem4 = item4.Split(';');

            Events.ClientEvents.HomeScreen.OnAppear(new Events.Args.EventArgs.ClientEventArgs());
        }
    }
}
