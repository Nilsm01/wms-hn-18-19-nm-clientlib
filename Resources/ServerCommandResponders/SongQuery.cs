using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Resources.ServerCommandResponders
{
    class SongQuery
    {
        public static void Evaluate(string result)
        {
            Events.ClientEvents.SongQuery.OnAppear(new Events.Args.EventArgs.ClientEventArgs() { List = result.Split(':') });
        }
    }
}
