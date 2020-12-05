using System.Collections.Generic;
using Mutagen.Bethesda;
using Newtonsoft.Json;
using SkyrimCurrencyReplacer.Enums;

namespace SkyrimCurrencyReplacer.Config
{
    [JsonObject(ItemRequired = Required.Always)]
    public class MatchFormKey : IMatchField
    {
        [JsonConstructor]
        public MatchFormKey(HashSet<FormKey> normal, HashSet<FormKey> nordic, HashSet<FormKey> dwemer)
        {
            Normal = normal;
            Nordic = nordic;
            Dwemer = dwemer;
        }

        [JsonProperty("normal")] public HashSet<FormKey> Normal { get; }
        [JsonProperty("nordic")] public HashSet<FormKey> Nordic { get; }
        [JsonProperty("dwemer")] public HashSet<FormKey> Dwemer { get; }

        public MatchType GetMatchType(string? query)
        {
            throw new System.NotImplementedException();
        }

        public bool Matches(MatchType matchType, string? query)
        {
            throw new System.NotImplementedException();
        }
    }
}