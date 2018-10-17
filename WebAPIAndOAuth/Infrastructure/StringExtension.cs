using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAndOAuth.Infrastructure
{
    public static class StringExtension
    {
        /// <summary>
        /// 检测字符串中是否有size个连续字符
        /// </summary>
        /// <param name="str">待检测的字符串</param>
        /// <param name="size">连续字符个数</param>
        /// <param name="isInverse">是否双向检测</param>
        /// <returns></returns>
        public static bool MaxContinualCharValidate(this string str, int size, bool isInverse = false)
        {
            int continualChars = 0;
            for (int idx = 1; idx < str.Length; idx++)
            {
                if (str[idx - 1] + 1 == str[idx])
                {
                    continualChars++;
                    if (!(continualChars < size - 1))
                    {
                        return false;
                    }
                }
                else
                {
                    continualChars = 0;
                }
            }

            if (isInverse)
            {
                // 翻转字符串在检测是否有指定个数及以上的连续字符
                char[] charArr = str.ToCharArray();
                Array.Reverse(charArr);
                return MaxContinualCharValidate(new string(charArr), size);
            }

            return true;
        }
    }
}