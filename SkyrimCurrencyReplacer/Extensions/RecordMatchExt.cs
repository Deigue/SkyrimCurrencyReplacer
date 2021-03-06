﻿using Mutagen.Bethesda.Skyrim;
using SkyrimCurrencyReplacer.Config;
using SkyrimCurrencyReplacer.Enums;

namespace SkyrimCurrencyReplacer.Extensions
{
    public static class RecordMatchExt
    {
        /// <summary>
        /// Returns the closest corresponding MatchType for the given <paramref name="record"/>
        /// </summary>
        /// <param name="record">Record that needs to be matched</param>
        /// <param name="config">Currency configurations that defines all matching rules</param>
        /// <typeparam name="T">Type of Plugin Record we are dealing with</typeparam>
        /// <returns>Returns Match Type for the provided record.></returns>
        public static MatchType GetMatchType<T>(this T record, CurrencyConfig config) where T : IContainerGetter
        {
            // TODO: Full implementation to take care of all situations.
            var matchName = config.MatchCriteria.Name;
            var query = record.Name?.String;
            
            // Implemented simple exact match so far.
            if (matchName.Matches(MatchType.Nordic, query)) return MatchType.Nordic;
            return matchName.Matches(MatchType.Dwemer, query)
                ? MatchType.Dwemer
                : MatchType.Normal;
        }
        
        /// <summary>
        /// Whether the provided <paramref name="record"/> matches the given <paramref name="matchType"/>/>
        /// </summary>
        /// <param name="record">Record to be matched</param>
        /// <param name="matchType">Match Type to check against</param>
        /// <param name="config">Currency configurations that defines all matching rules</param>
        /// <typeparam name="T">Type of Plugin Record we are dealing with</typeparam>
        /// <returns>Return true if match is successful.</returns>
        public static bool Matches<T>(this T record, MatchType matchType, CurrencyConfig config) where T : IContainerGetter
        {   
            // TODO : Just do exact name matches as proof of concept for now.
            var matchName = config.MatchCriteria.Name;
            var query = record.Name?.String;
            
            return matchType switch
            {
                MatchType.Normal => matchName.GetMatchType(query) == MatchType.Normal,
                MatchType.Dwemer => matchName.GetMatchType(query) == MatchType.Dwemer,
                MatchType.Nordic => matchName.GetMatchType(query) == MatchType.Nordic,
                _ => false
            };
        }
    }
}