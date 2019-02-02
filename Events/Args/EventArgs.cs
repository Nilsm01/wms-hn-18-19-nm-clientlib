using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events.Args
{
    public class EventArgs
    {
        public class ErrorEventArgs : EventArgs
        {
            public string ErrorMessage { get; set; }
        }

        public class ServerEventArgs : EventArgs
        {
            public string Param { get; set; }
        }

        public class ClientEventArgs : EventArgs
        {
            public string[] List;
        }

        public class DataPackageEventArgs : EventArgs
        {
            public Connection.DataPackage.Template.DataPackage dataPackage { get; set; }
        }
    }
}
