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
        /// Attempts to match the Major Record with one of the Match Types.
        /// </summary>
        /// <returns>Returns the Match Type closest representing the base major record.</returns>
        MatchType GetMatchType();

        /// <summary>
        /// Indicates if the Major Record patches the provided <paramref name="matchType"/>
        /// </summary>
        /// <param name="matchType">Match Type to check against</param>
        /// <returns>Returns true if the Major Record seems to match the provided <paramref name="matchType"/></returns>
        bool Matches(MatchType matchType);
    }
}