using SkyrimCurrencyReplacer.Enums;

namespace SkyrimCurrencyReplacer.Config
{
    public interface IMatchField
    {
        /// <summary>
        /// Returns the closest corresponding MatchType for the given <paramref name="query"/>
        /// </summary>
        /// <param name="query">String to be matched to a particular MatchType</param>
        /// <returns>Returns the Match Type</returns>
        MatchType GetMatchType(string? query);

        /// <summary>
        /// Whether the <paramref name="query"/> string matches the provided <paramref name="matchType"/>/>
        /// </summary>
        /// <param name="matchType">Match Type to check against</param>
        /// <param name="query">String that need to be queried</param>
        /// <returns>Returns true if match is successful.></returns>
        bool Matches(MatchType matchType, string? query);
    }
}