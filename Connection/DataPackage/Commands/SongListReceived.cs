using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection.DataPackage.Commands
{
    class SongListReceived
    {
        public static void EvaluateList(DataPackage.Template.DataPackage dataPackage)
        {
            Events.ClientEvents.SongList.OnAppear(new Events.Args.EventArgs.ClientEventArgs() { List = dataPackage.Params.Split(':') });
        }
    }
}
