using Mutagen.Bethesda.Skyrim;
using SkyrimCurrencyReplacer.Config;

namespace SkyrimCurrencyReplacer.Extensions
{
    public static class RecordMatchExt
    {
        public static IMatchField.MatchType GetMatchType<T>(this T record, CurrencyConfig config) where T : IContainerGetter
        {
            // TODO: Full implementation to take care of all situations.
            var matchName = config.MatchCriteria.Name;
            var query = record.Name?.String;
            
            // Implemented simple exact match so far.
            if (matchName.Matches(IMatchField.MatchType.Nordic, query)) return IMatchField.MatchType.Nordic;
            return matchName.Matches(IMatchField.MatchType.Dwemer, query)
                ? IMatchField.MatchType.Dwemer
                : IMatchField.MatchType.Normal;
        }

        public static bool Matches<T>(this T record, IMatchField.MatchType matchType, CurrencyConfig config) where T : IContainerGetter
        {   
            // TODO : Just do exact name matches as proof of concept for now.
            var matchName = config.MatchCriteria.Name;
            var query = record.Name?.String;
            
            return matchType switch
            {
                IMatchField.MatchType.Normal => matchName.GetMatchType(query) == IMatchField.MatchType.Normal,
                IMatchField.MatchType.Dwemer => matchName.GetMatchType(query) == IMatchField.MatchType.Dwemer,
                IMatchField.MatchType.Nordic => matchName.GetMatchType(query) == IMatchField.MatchType.Nordic,
                _ => false
            };
        }
    }
}