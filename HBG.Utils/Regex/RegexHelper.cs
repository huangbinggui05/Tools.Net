using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HBG.Utils
{
    public static class RegexHelper
    {
        /// <summary>
        /// 手机号验证
        /// </summary>
        /// <param name="mobileNo"></param>
        /// <returns></returns>
        public static bool IsMobileNo(string mobileNo)
        {
            Regex re = new Regex("\\d{11}");
            return re.IsMatch(mobileNo);
        }
    }
}
