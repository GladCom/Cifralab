using System.Numerics;

namespace Students.APIServer.Extension
{
    public static class StringExtension
    {
        public static string GetPhoneFromStr(this string phone)
        {
            return phone.Length > 10 ? phone.Substring(phone.Length - 10) : phone;
        }
    }
}
