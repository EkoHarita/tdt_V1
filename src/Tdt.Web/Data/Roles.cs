using System;

namespace Tdt.Web.Data
{
    internal static class Roles
    {
        public const string Default = "user";
        public const string Administrator = "administrator";

        public static string ToplulukManager(string market)
        {
            if (market == null) throw new ArgumentNullException(nameof(market));
            
            return $"{market.ToLowerInvariant()}.manager";
        }
    }
}