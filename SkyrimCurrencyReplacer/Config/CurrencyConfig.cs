using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using SkyrimCurrencyReplacer.Config;

namespace SkyrimCurrencyReplacer
{
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