using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mix
{
    class Sha1Helper
    {
        public static string Sha1Encrypter(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);

                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
        public static string Sha1MangedEncryter(string content, Encoding ecode)
        {
            string result = string.Empty;
            try
            {
                SHA1Managed sha1 = new SHA1Managed();
                byte[] resultHash = sha1.ComputeHash(ecode.GetBytes(content));
                result = BitConverter.ToString(resultHash).Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }
    }
}
