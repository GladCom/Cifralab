namespace Students.APIServer.Extension
{
    public static class StringExtension
    {
        public static string GetPhoneFromStr(this string phone)
        {
            return phone.Substring(phone.Length - 10); ;
        }
    }
}
