using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
    public class MatchString : IMatchField
    {
        [JsonProperty("normal")] public MatcherDb Normal { get; }
        [JsonProperty("nordic")] public MatcherDb Nordic { get; }
        [JsonProperty("dwemer")] public MatcherDb Dwemer { get; }
        
    }
}