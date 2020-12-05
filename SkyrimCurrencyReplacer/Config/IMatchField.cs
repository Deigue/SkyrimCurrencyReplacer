namespace SkyrimCurrencyReplacer.Config
{
    public interface IMatchField
    {
        /// <summary>
        /// Defines all possible match types that can be made.
        /// </summary>
        enum MatchType
        {
            /// <summary>
            /// Normal Coins such as Gold, Aether and Ayleid
            /// </summary>
            Normal,

            /// <summary>
            /// Dwemer Coins (Kagrenacs) that can be found in Dwemer ruins and on their inhabitants Falmer 
            /// </summary>
            Dwemer,

            /// <summary>
            /// Nordic Coins (Alessia) that can be found on Dragons, in Nordic ruins and on their inhabitants Draugr.
            /// </summary>
            Nordic
        }

        /// <summary>
        /// Returns the closest corresponding MatchType for the given <paramref name="query"/>
        /// </summary>
        /// <param name="query">String to be matched to a particular MatchType</param>
        /// <returns>Returns the Match Type</returns>
        MatchType GetMatchType(string? query);

        /// <summary>
        /// Whether the <paramref name="query" string matches the provided <paramref name="matchType"/>/>
        /// </summary>
        /// <param name="matchType">Match Type to check against</param>
        /// <param name="query">String that need to be queried</param>
        /// <returns>Returns true if the query matches the <paramref name="matchType"/> provided.></returns>
        bool Matches(MatchType matchType, string? query);
    }
}