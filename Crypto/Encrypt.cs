using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClientLib.Crypto
{
    class Encrypt
    {
        public static string String(string Input)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(Resources.key, Resources.iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(Input);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string String(byte[] key, string Input)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, Resources.iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(Input);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static byte[] Byte(byte[] Input)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(Resources.key, Resources.iv);
            byte[] outputBuffer = transform.TransformFinalBlock(Input, 0, Input.Length);
            return outputBuffer;
        }

        public static byte[] Byte(byte[] Input, byte[] key)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, Resources.iv);
            byte[] outputBuffer = transform.TransformFinalBlock(Input, 0, Input.Length);
            return outputBuffer;
        }
    }
}
