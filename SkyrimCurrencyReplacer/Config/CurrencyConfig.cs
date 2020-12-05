using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
    [JsonObject(ItemRequired = Required.Always)]
    public class CurrencyConfig
    {
        [JsonConstructor]
        public CurrencyConfig(MatchCriteria matchCriteria)
        {
            MatchCriteria = matchCriteria;
        }

        // TODO: Match criterion priority order
        // Exact Name > Exact EDID > Contains in EDID

        // [JsonConstructor]
        // private CurrencyConfig()
        // {
        // }

        [JsonProperty("matchCriteria")]
        [NotNull]
        public MatchCriteria MatchCriteria { get; }
    }
}