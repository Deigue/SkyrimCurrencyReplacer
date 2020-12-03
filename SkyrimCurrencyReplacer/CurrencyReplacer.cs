using System;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace SkyrimCurrencyReplacer
{
    public static class CurrencyReplacer
    {
        private const string CoinsOfTamriel = "Coins of Tamriel V2 SSE Edition.esp";

        public static int Main(string[] args)
        {
            return SynthesisPipeline.Instance.Patch<ISkyrimMod, ISkyrimModGetter>(
                args: args,
                patcher: RunPatch,
                userPreferences: new UserPreferences()
                {
                    ActionsForEmptyArgs = new RunDefaultPatcher()
                    {
                        IdentifyingModKey = "SkyrimCurrencyReplacer.esp",
                        TargetRelease = GameRelease.SkyrimSE,
                        BlockAutomaticExit = true,
                    }
                });
        }
        
        private static void SynthesisLog(string message, bool special = false)
        {
            if (special)
            {
                Console.WriteLine();
                Console.Write(">>> ");
            }
            Console.WriteLine(message);
            if (special) Console.WriteLine();
        }

        private static void RunPatch(SynthesisState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // Detect presence of Replacer plugin.
            var coinsOfTamrielMod = state.LoadOrder.FirstOrDefault(x => x.Key.FileName is CoinsOfTamriel).Value.Mod;

            if (coinsOfTamrielMod is null)
            {
                SynthesisLog($"Could not find {CoinsOfTamriel} in load order.");
                return;
            }
            
            
            

            // Patch up Containers originating from CoT V2 Replacer.

            // Patch REFRs with randomized generated variations of coins/currencies across worldspaces and cells.

            // Handle leveled lists containing LVLI.

            // Handle flora actionable containers like pouches to emit currencies.
        }
    }
}