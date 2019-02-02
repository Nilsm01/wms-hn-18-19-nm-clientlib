using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.PublicResources
{
    class ResourceInput
    {
        public static void SetAutoLogin(bool autoLogin)
        {
            Resources.ServerResources.AutoLogin = autoLogin;
        }
    }
}
