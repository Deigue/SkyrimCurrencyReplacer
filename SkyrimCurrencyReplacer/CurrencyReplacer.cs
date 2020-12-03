using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using Mutagen.Bethesda;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using SkyrimCurrencyReplacer.COTV2;
using SkyrimCurrencyReplacer.Extensions;
using Wabbajack.Common;
using static Mutagen.Bethesda.FormKeys.SkyrimSE.Skyrim.LeveledItem;

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

        private static bool IsSkyrimBaseMod(this ModKey modKey)
        {
            return (new[] {"Skyrim", "Update", "Dawnguard", "HearthFires", "Dragonborn"}.Contains(modKey.Name));
        }

        private static void RunPatch(SynthesisState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // 0. Initialize method contextual variables.
            var cache = state.LinkCache;
            
            // 1. Detect presence of Coins of Tamriel V2 Replacer plugin.
            if (!state.LoadOrder.TryGetValue(CoinsOfTamrielModKey,
                    out (int index, IModListing<ISkyrimModGetter> modListing) coinsOfTamrielContainer) ||
                coinsOfTamrielContainer.modListing.Mod is null)
                throw new MissingModException(CoinsOfTamrielModKey,
                    $"Mod {CoinsOfTamrielModKey.Name} was not found in Load Order.");

            // 2. Patching ALL Containers for Currency Related information dynamically.
            var coinsOfTamrielMod = coinsOfTamrielContainer.modListing.Mod;
            var nativeContainers = coinsOfTamrielMod.Containers;

            // 2.a. Find winning containers we are allowed to change and apply our algorithm to.
            IEnumerable<ModContext<ISkyrimMod, IContainer, IContainerGetter>> containersToPatch = state.LoadOrder
                .PriorityOrder
                .Container()
                .WinningContextOverrides(cache)
                .Where(context =>
                {
                    // Detection Triggers ... 
                    return context.Record.Items?.Any(container =>
                        container.Item.Item.FormKey.IsOneOf(
                            LootPerkGoldenTouchChange,
                            LootImperialLuck
                        )) ?? false;
                });

            // 2.b. Patch up Native containers originating within Coins of Tamriel plugin that are left over.
            // NOTE: Will only patch against the most recent override, i.e. The load order provided must be already
            // conflict resolved for everything UPTO BUT NOT INCLUSIVE OF Coins of Tamriel V2 itself.

            #region Test 1

            // Test 1 : Overriding containers proof of concept works as expected.
            var counter = 0;
            foreach (var container in nativeContainers)
            {
                //state.LoadOrder.ListedOrder.Take(coinsOfTamrielContainer.index)
                //  .Do(x => Console.WriteLine(x.ModKey));

                var containerContext = state.LoadOrder.ListedOrder.Take(coinsOfTamrielContainer.index)
                    .Reverse()
                    .Container()
                    .WinningContextOverrides(state.LinkCache)
                    .FirstOrDefault(recentContainer => container.FormKey == recentContainer.Record.FormKey);

                if (containerContext is null) continue;
                var closestWinningContainer = containerContext.Record;

                SynthesisLog($"{containerContext.ModKey} for {containerContext.Record.Name}");
                //var cond2 = !Equals(closestWinningContainer, container);
                //var cond3 = !closestWinningContainer?.FormKey.ModKey.IsSkyrimBaseMod();
                //SynthesisLog($"{cond1} {cond2} {cond3}");

                if (!Equals(closestWinningContainer, container) &&
                    !containerContext.ModKey.IsSkyrimBaseMod())
                {
                    SynthesisLog("reached B");
                    var adjustedContainer = state.PatchMod.Containers.GetOrAddAsOverride(closestWinningContainer);
                    //var goldenTouchChange = state.LinkCache.Lookup<ILeveledItemGetter>(Skyrim.LeveledItem.LootPerkGoldenTouchChange);
                    var itemsToReplace = adjustedContainer.Items?.FindAll(i =>
                        i.Item.Item.FormKey == LootPerkGoldenTouchChange);
                    ContainerEntry goldenTouchChangeNordic = new ContainerEntry
                    {
                        Item = new ContainerItem()
                        {
                            Count = 1,
                            Item = new FormLink<IItemGetter>(CoinsOfTamrielV2.LeveledItem
                                .LootPerkGoldenTouchChangeNordic)
                        }
                    };

                    itemsToReplace?.Do(goldenTouchChange =>
                        adjustedContainer.Items.Replace<ContainerEntry>(goldenTouchChange, goldenTouchChangeNordic));

                    counter++;
                }
            }


            SynthesisLog($"Performed {counter} replacements in Containers", true);

            #endregion


            //state.LoadOrder.PriorityOrder.Container()
            //coinsOfTamrielMod.Containers.

            // Patch REFRs with randomized generated variations of coins/currencies across worldspaces and cells.

            // Handle leveled lists containing LVLI.

            // Handle flora actionable containers like pouches to emit currencies.
        }
    }
}