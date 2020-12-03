using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace SkyrimCurrencyReplacer
{
    public static class CurrencyReplacer
    {
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

        private static void RunPatch(SynthesisState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // Detect presence of Replacer plugin.
            
            // Patch up Containers originating from CoT V2 Replacer.
            
            // Patch REFRs with randomized generated variations of coins/currencies across worldspaces and cells.
            
            // Handle leveled lists containing LVLI.
            
            // Handle flora activatable containers like pouches to emit currencies.
        }
    }
}
