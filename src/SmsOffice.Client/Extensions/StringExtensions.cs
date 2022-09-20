using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmsOffice.Client.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrlEncoded(this string text)
        {
            return HttpUtility.UrlEncode(text);
        }

        public static string ToNormalizedPhoneNumber(this string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim('+');

            if (!phoneNumber.StartsWith("995"))
            {
                phoneNumber = $"995{phoneNumber}";
            }

            return phoneNumber;
        }
    }
}
