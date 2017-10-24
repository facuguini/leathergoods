using System;
using System.Text.RegularExpressions;

namespace Framework.Extensions
{
    public static class StringExtension
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string StripTags(this string value)
        {
            return Regex.Replace(value, "<.*?>", String.Empty);
        }

    }
}
