using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Crypto
{
    class Manager
    {
        public static void GenerateNewCryptoKey()
        {
            Random r = new Random();
            byte[] key = new byte[8] { Convert.ToByte(r.Next(0,9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)) };
            Resources.key = key;
        }

        public static byte[] getCryptoKey()
        {
            Random r = new Random();
            byte[] key = new byte[8] { Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)), Convert.ToByte(r.Next(0, 9)) };
            return key;
        }
    }
}
