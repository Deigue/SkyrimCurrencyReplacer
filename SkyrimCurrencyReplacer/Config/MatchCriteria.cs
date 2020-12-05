using Newtonsoft.Json;

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

        [JsonProperty("editorId")] public IMatchField EditorId { get; }
        [JsonProperty("name")] public IMatchField Name { get; }
        [JsonProperty("formId")] public IMatchField FormKey { get; }
    }
}