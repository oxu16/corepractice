using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace corepractice.Utilities
{
    public class ProcessPassword
    {
        public string GetSaltedPasswordHashing(string password, int size)
        {
            string salt = CreateSalt(10);
            string hashedPassword = GenerateSha256Hash(password, salt);
            return hashedPassword;
        }

        public string CreateSalt(int size)
        {
            var buff = new byte[size];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff); 
        }

        public string GenerateSha256Hash(string input, string salt)
        {
            var sha256string = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var hash = sha256string.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }

        // Convers a byte array to a HEX string
        public string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hexString = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString.Append(bytes[i].ToString("X2"));
            }
            return hexString.ToString();
        }
    }
}
