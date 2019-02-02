using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.UserProfile
{
    public class Administrator
    {
        public static void SaveUserProfile()
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(Resources.ServerResources.Profile);
            using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\Settings\\userprofile.json"))
            {
                STW.WriteLine(data);
            }
        }

        public static void AddItemsToList(string item)
        {
            if (Resources.ServerResources.Profile.ListenedSongs.Contains(item)) {
                //int index = Resources.ServerResources.Profile.ListenedSongs.FindIndex(a => a == item);
                Resources.ServerResources.Profile.ListenedSongs.Remove(item);
                Resources.ServerResources.Profile.ListenedSongs.Add(item);
            }
            else
            {
                Resources.ServerResources.Profile.ListenedSongs.Add(item);
            }
            Events.ClientEvents.LasPlayedListUpdated.OnAppear(new Events.Args.EventArgs.ClientEventArgs());
        }
    }
}
