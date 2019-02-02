using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Crypto
{
    class Decrypt
    {
        public static string String(string Input)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(Resources.key, Resources.iv);
            byte[] inputbuffer = Convert.FromBase64String(Input);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        public static string String(string Input, byte[] key)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, Resources.iv);
            byte[] inputbuffer = Convert.FromBase64String(Input);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        public static byte[] Byte(byte[] Input)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(Resources.key, Resources.iv);
            byte[] outputBuffer = transform.TransformFinalBlock(Input, 0, Input.Length);
            return outputBuffer;
        }

        public static byte[] Byte(byte[] Input, byte[] key)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, Resources.iv);
            byte[] outputBuffer = transform.TransformFinalBlock(Input, 0, Input.Length);
            return outputBuffer;
        }
    }
}
