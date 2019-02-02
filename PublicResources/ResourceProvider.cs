using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.PublicResources
{
    public class ResourceProvider
    {
        public static bool isClientConnectedToServer()
        {
            return Resources.ServerResources.ConnectedToServer;
        }

        public static string[] getHomeScreen_Item1()
        {
            return Resources.ServerResources.HomeScreenItem1;
        }

        public static string[] getHomeScreen_Item2()
        {
            return Resources.ServerResources.HomeScreenItem2;
        }

        public static string[] getHomeScreen_Item3()
        {
            return Resources.ServerResources.HomeScreenItem3;
        }

        public static string[] getHomeScreen_Item4()
        {
            return Resources.ServerResources.HomeScreenItem4;
        }

        public static UserProfile.Template.UserProfile getUserProfile()
        {
            return Resources.ServerResources.Profile;
        }

        public static Resources.Settings getSettings()
        {
            return Resources.ServerResources.settings;
        }

        public static bool AutoLoginEnabled()
        {
            return Resources.ServerResources.AutoLogin;
        }
    }
}
