using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.UserProfile
{
    class Manager
    {
        public static void Initialize()
        {
            Resources.ServerResources.Profile = new Template.UserProfile();
            Resources.ServerResources.Profile.ListenedSongs = new List<string>();
            LoadUserProfile();
        }

        private static void LoadUserProfile()
        {
            if(File.Exists(Environment.CurrentDirectory + "\\Settings\\userprofile.json"))
            {
                using (StreamReader STR = new StreamReader(Environment.CurrentDirectory + "\\Settings\\userprofile.json"))
                {
                    Resources.ServerResources.Profile = JsonConvert.DeserializeObject<Template.UserProfile>(STR.ReadLine());
                }
            }
            else
            {
                Template.UserProfile userProfile = new Template.UserProfile();
                string data = JsonConvert.SerializeObject(userProfile);
                using (StreamWriter STW = new StreamWriter(Environment.CurrentDirectory + "\\Settings\\userprofile.json"))
                {
                    STW.WriteLine(data);
                }
            }
        }
    }
}
