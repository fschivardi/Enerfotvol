using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public class Encriptado
    {
        public string Encriptar(string valor, string salt)
        {
            byte[] pwdBytes = Encoding.UTF8.GetBytes(valor);
            // byte[] salt = BitConverter.GetBytes(userId);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] saltedPassword = new byte[pwdBytes.Length + salt.Length];

            Buffer.BlockCopy(pwdBytes, 0, saltedPassword, 0, pwdBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, saltedPassword, pwdBytes.Length, salt.Length);

            SHA1 sha = SHA1.Create();
            var test = sha.ComputeHash(saltedPassword);
            string encrpass = "";
            var loopTo = test.Length - 1;
            for (int i = 0; i <= loopTo; i++)
                encrpass += test[i].ToString("x").PadLeft(2, '0');

            return encrpass;
        }

        public string Encriptar(string valor)
        {
            string encrpass;
            MD5CryptoServiceProvider md5;
            byte[] bytValue;
            byte[] bytHash;
            int i;
            encrpass = "";
            md5 = new MD5CryptoServiceProvider();
            bytValue = System.Text.Encoding.UTF8.GetBytes(valor);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            var loopTo = bytHash.Length - 1;
            for (i = 0; i <= loopTo; i++)
                encrpass += bytHash[i].ToString("x").PadLeft(2, '0');
            return encrpass;
        }

        public string GenerarSalt()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[24];
            rngCsp.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            return salt;
        }

    }
}
