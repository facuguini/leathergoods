using System;
using Framework.Extensions;

namespace Framework.Seo
{
    public class OpenGraph
    {
        private static string OGType(string ogType)
        {
            return $"<meta property=\"og:type \" content=\"{ogType}\">";

        }

        private static string OGSiteName(string ogSiteName)
        {
            return $"<meta property=\"og:site_name\" content=\"{ogSiteName}\">";
        }

        private static string OGTitle(string ogTitle)
        {
            return $"<meta property=\"og:title\" content=\"{ogTitle}\">";

        }

        private static string OGDescription(string ogDescription)
        {
            string safeDescription = ogDescription.StripTags().Truncate(110);
            return $"<meta property=\"og:description\" content=\"{safeDescription}\">";
        }

        private static string OGImage(string ogImageUrl)
        {
            return $"<meta property=\"og:image\" content=\"{ogImageUrl}\">";
        }

        private static string OGUrl(string ogUrl)
        {
            return $"<meta property=\"og:url\" content=\"{ogUrl}\">";

        }

        public static string Build (
            string ogType,
            string ogSiteName,
            string ogTitle,
            string ogDescription,
            string ogImageUrl,
            string ogUrl
        )
        {
            return $@"
                {OGType(ogType)}
                {OGSiteName(ogSiteName)}
                {OGTitle(ogTitle)}
                {OGDescription(ogDescription)}
                {OGImage(ogImageUrl)}
                {OGUrl(ogUrl)}";
        }
    }
}
