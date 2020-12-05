using Newtonsoft.Json;
using SkyrimCurrencyReplacer.Converters;

namespace SkyrimCurrencyReplacer.Config
{
    public class MatchCriteria
    {
        [JsonConstructor]
        public MatchCriteria(IMatchField editorId, IMatchField name, IMatchField formKey)
        {
            EditorId = editorId;
            Name = name;
            FormKey = formKey;
        }

        [JsonProperty("editorId")]
        [JsonConverter(typeof(MatchStringConverter))]
        public IMatchField EditorId { get; }

        [JsonProperty("name")]
        [JsonConverter(typeof(MatchStringConverter))]
        public IMatchField Name { get; }

        [JsonProperty("formId")]
        [JsonConverter(typeof(MatchFormKeyConverter))]
        public IMatchField FormKey { get; }
    }
}