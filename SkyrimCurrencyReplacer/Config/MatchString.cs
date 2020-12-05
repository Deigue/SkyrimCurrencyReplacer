using System;
using Newtonsoft.Json;
using SkyrimCurrencyReplacer.Enums;

namespace SkyrimCurrencyReplacer.Config
{
    [JsonObject(ItemRequired = Required.Always)]
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


        public MatchType GetMatchType(string? query)
        {
            // TODO: Full implementation.
            
            // Just doing exact equal matches for now ...
            if (query is null) return MatchType.Normal;
            if (Normal.EqualSet.Contains(query)) return MatchType.Normal;
            if (Nordic.EqualSet.Contains(query)) return MatchType.Nordic;
            return Dwemer.EqualSet.Contains(query) ? MatchType.Dwemer : MatchType.Normal;
        }

        public bool Matches(MatchType matchType, string? query)
        {
            // TODO: Full implementation to take care of all situations.
            
            // Implemented simple exact match so far.
            return matchType switch
            {
                MatchType.Normal => GetMatchType(query) == MatchType.Normal,
                MatchType.Dwemer => GetMatchType(query) == MatchType.Dwemer,
                MatchType.Nordic => GetMatchType(query) == MatchType.Nordic,
                _ => false
            };
        }
    }
}