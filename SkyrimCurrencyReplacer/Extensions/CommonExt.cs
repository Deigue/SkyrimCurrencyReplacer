using System.Linq;

namespace SkyrimCurrencyReplacer.Extensions
{
    public static class CommonExt
    {
        public static bool IsOneOf<T>(this T obj, params T[] args)
        {
            return args.Contains(obj);
        }
    }
}