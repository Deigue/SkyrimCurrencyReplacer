using System.Collections.Generic;
using Mutagen.Bethesda;
using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
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

        public IMatchField.MatchType GetMatchType()
        {
            throw new System.NotImplementedException();
        }

        public bool Matches(IMatchField.MatchType matchType)
        {
            throw new System.NotImplementedException();
        }
    }
}