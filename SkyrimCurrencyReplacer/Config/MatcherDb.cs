using System.Collections.Generic;
using Newtonsoft.Json;

namespace SkyrimCurrencyReplacer.Config
{
    public struct MatcherDb
    {
        [JsonProperty("equals")] public HashSet<string>? EqualSet { get; }
        [JsonProperty("contains")] public HashSet<string>? ContainSet { get; }
    }
}