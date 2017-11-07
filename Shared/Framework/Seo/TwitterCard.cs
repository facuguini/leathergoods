using System;
using Framework.Extensions;

namespace Framework.Seo
{
    public class TwitterCard
    {
        private static string TwCard()
        {
            return $"<meta property=\"twitter:card\" content=\"summary\">";

        }

        private static string TwSiteName(string twSiteName)
        {
            return $"<meta property=\"twitter:site\" content=\"{twSiteName}\">";
        }

        private static string TwTitle(string twTitle)
        {
            return $"<meta property=\"twitter:title\" content=\"{twTitle}\">";
        }

        private static string TwDescription(string twDescription)
        {
            string safeDescription = twDescription.StripTags().Truncate(140);
            return $"<meta property=\"twitter:description\" content=\"{safeDescription}\">";
        }

        private static string TwImage(string twImageUrl)
        {
            return $"<meta property=\"twitter:image\" content=\"{twImageUrl}\">";
        }

        private static string TwUrl(string twUrl)
        {
            return $"<meta property=\"twitter:url\" content=\"{twUrl}\">";

        }

        public static string Build (
            string twSiteName,
            string twTitle,
            string twDescription,
            string twImageUrl,
            string twUrl
        )
        {
            return $@"
                {TwCard()}
                {TwSiteName(twSiteName)}
                {TwTitle(twTitle)}
                {TwDescription(twDescription)}
                {TwImage(twImageUrl)}
                {TwUrl(twUrl)}";
        }
    }
}
