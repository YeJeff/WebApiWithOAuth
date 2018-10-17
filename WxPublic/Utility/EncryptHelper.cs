using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WxPublic.Utility
{
    public static class EncryptHelper
    {
        public static string Sha1Encrypt(this string originalString, Encoding encoding)
        {
            string result = string.Empty;
            try
            {
                using(SHA1 sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] bytes_in = encoding.GetBytes(originalString);
                    byte[] bytes_out = sha1.ComputeHash(bytes_in);
                    result = BitConverter.ToString(bytes_out);
                    result = result.Replace("-", "");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Sha1加密出错：{ex.Message}");
            }
            return result;
        }
    }
}