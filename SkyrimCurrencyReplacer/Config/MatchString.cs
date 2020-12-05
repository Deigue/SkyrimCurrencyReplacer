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