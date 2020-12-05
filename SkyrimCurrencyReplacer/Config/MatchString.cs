using System;
using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
    public class MatchString : IMatchField
    {
        [JsonConstructor]
        public MatchString(MatcherDb normal, MatcherDb nordic, MatcherDb dwemer)
        {
            Normal = normal;
            Nordic = nordic;
            Dwemer = dwemer;
        }

        [JsonProperty("normal")] public MatcherDb Normal { get; }
        [JsonProperty("nordic")] public MatcherDb Nordic { get; }
        [JsonProperty("dwemer")] public MatcherDb Dwemer { get; }


        public IMatchField.MatchType GetMatchType(string? query)
        {
            // TODO: Full implementation.
            
            // Just doing exact equal matches for now ...
            if (query is null) return IMatchField.MatchType.Normal;
            if (Normal.EqualSet.Contains(query)) return IMatchField.MatchType.Normal;
            if (Nordic.EqualSet.Contains(query)) return IMatchField.MatchType.Nordic;
            return Dwemer.EqualSet.Contains(query) ? IMatchField.MatchType.Dwemer : IMatchField.MatchType.Normal;
        }

        public bool Matches(IMatchField.MatchType matchType, string? query)
        {
            // TODO: Full implementation to take care of all situations.
            
            // Implemented simple exact match so far.
            return matchType switch
            {
                IMatchField.MatchType.Normal => GetMatchType(query) == IMatchField.MatchType.Normal,
                IMatchField.MatchType.Dwemer => GetMatchType(query) == IMatchField.MatchType.Dwemer,
                IMatchField.MatchType.Nordic => GetMatchType(query) == IMatchField.MatchType.Nordic,
                _ => false
            };
        }
    }
}