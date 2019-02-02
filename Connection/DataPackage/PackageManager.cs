using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection.DataPackage
{
    class PackageManager
    {
        private static int PackageCounter;
        public static string GetPackageName()
        {
            PackageCounter++;
            return "PCK:" + PackageCounter;
        }

        public static Template.DataPackage DecryprtDataPackage(Template.DataPackage dataPackage)
        {
            Template.DataPackage decryptedDataPackage = new Template.DataPackage()
            {
                Data = Crypto.Decrypt.String(dataPackage.Data, Resources.ServerResources.ConnectionKey),
                Params = Crypto.Decrypt.String(dataPackage.Params, Resources.ServerResources.ConnectionKey),
                Name = GetPackageName(),
                Packet = dataPackage.Packet
            };
            return decryptedDataPackage;
        }
    }
}
