using System;

namespace ShortLink.Core.Classes
{
    public static class LinkGenerator
    {
        /// <summary>
        /// تابع تولید لینک کوتاه شده
        /// </summary>
        /// <returns></returns>
        public static string GeneratLink()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
