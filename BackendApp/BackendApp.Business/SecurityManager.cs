using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace BackendApp.Business
{
    public class SecurityManager
    {
        private Aes _Aes;
        public SecurityManager()
        {
            string iv = ConfigurationManager.AppSettings["ivkey"];
            string encKey = ConfigurationManager.AppSettings["encKey"];

            _Aes = Aes.Create();
            _Aes.IV = Encoding.ASCII.GetBytes(iv);
            _Aes.Key = Encoding.ASCII.GetBytes(encKey);
        }

        public byte[] Encrypt(string text)
        {
            try
            {
                byte[] retVal;

                ICryptoTransform encryptor = _Aes.CreateEncryptor(_Aes.Key, _Aes.IV);
                using (MemoryStream msEnc = new MemoryStream())
                {
                    using (CryptoStream csEnc = new CryptoStream(msEnc, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEnc = new StreamWriter(csEnc))
                        {
                            swEnc.Write(text);
                        }
                        retVal = msEnc.ToArray();
                    }
                }
                return retVal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Decrypt(byte[] cipherText)
        {
            try
            {
                string retVal;
                ICryptoTransform decryptor = _Aes.CreateDecryptor(_Aes.Key, _Aes.IV);
                using (MemoryStream msDec = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDec = new CryptoStream(msDec, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDec = new StreamReader(csDec))
                        {
                            retVal = srDec.ReadToEnd();
                        }
                    }
                }
                return retVal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
