using System.Numerics;

namespace Students.APIServer.Extension
{
    /// <summary>
    /// Странное расширение для строки
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Крайне странный способ получения номера телефона из строки
        /// </summary>
        /// <param name="phone">номер телефона</param>
        /// <returns></returns>
        public static string GetPhoneFromStr(this string phone)
        {
            return phone.Length > 10 ? phone.Substring(phone.Length - 10) : phone;
        }
    }
}
