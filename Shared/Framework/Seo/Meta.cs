using System;
using Framework.Extensions;

namespace Framework.Seo
{
    public class Meta
    {
        public static string Title(string title)
        {
            return $"<title>{title}</title>";

        }

        public static string Description(string description)
        {
            string safeDescription = description.StripTags().Truncate(160);
            return $"<meta name=\"description\" content=\"{safeDescription}\">";
        }
    }
}
