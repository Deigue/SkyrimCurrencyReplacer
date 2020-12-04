using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
    public class MatchCriteria
    {
        [JsonProperty("editorId")] public MatchField EditorId { get; }
        [JsonProperty("name")] public MatchField Name { get; }
    }
}