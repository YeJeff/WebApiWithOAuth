using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace WebAPIAndOAuth.Infrastructure
{
    /// <summary>
    /// 使用此WebApi的应用程序类型
    /// </summary>
    public enum ApplicationTypes
    {
        /// <summary>
        /// jQuery等发起XHR请求
        /// </summary>
        JavaScript = 0,

        /// <summary>
        /// 桌面客户端、移动APP、Web后端代码调用
        /// </summary>
        NativeConfidential = 1
    }

    public class Utility
    {
        /// <summary>
        /// SHA256加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetHashBySHA256(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}