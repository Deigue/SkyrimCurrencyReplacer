using System;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace SkyrimCurrencyReplacer
{
    public static class CurrencyReplacer
    {
        private static readonly ModKey CoinsOfTamrielModKey =
            ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");

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
            if (!state.LoadOrder.TryGetValue(CoinsOfTamrielModKey,
                    out IModListing<ISkyrimModGetter>? coinsOfTamrielModListing) ||
                coinsOfTamrielModListing.Mod is null)
                throw new MissingModException(CoinsOfTamrielModKey,
                    $"Mod {CoinsOfTamrielModKey.Name} was not found in Load Order.");

           
            // Patch up Native containers originating within Coins of Tamriel plugin.
            // NOTE: Will only patch against the most recent override, i.e. The load order provided must be already
            // conflict resolved for everything except Coins of Tamriel V2 itself.
            var coinsOfTamrielMod = coinsOfTamrielModListing.Mod;
            foreach (var container in coinsOfTamrielMod.Containers)
            {
                // do replacements and override here.
            }


            //state.LoadOrder.PriorityOrder.Container()
            //coinsOfTamrielMod.Containers.

            // Patch REFRs with randomized generated variations of coins/currencies across worldspaces and cells.

            // Handle leveled lists containing LVLI.

            // Handle flora actionable containers like pouches to emit currencies.
        }
    }
}