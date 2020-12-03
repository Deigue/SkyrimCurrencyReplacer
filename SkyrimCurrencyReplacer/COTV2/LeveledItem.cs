using Mutagen.Bethesda;

namespace SkyrimCurrencyReplacer.COTV2
{
    public static partial class CoinsOfTamrielV2
    {
        public static class LeveledItem
        {
            private static readonly ModKey ModKey = ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");
            public static FormKey LootImperialLuckNordic => ModKey.MakeFormKey(0x55e5);
            public static FormKey LootPerkGoldenTouchChangeNordic => ModKey.MakeFormKey(0x55e4);
            public static FormKey LootGoldChangeNordic => ModKey.MakeFormKey(0x55e3);
            public static FormKey LootGoldChange25Nordic => ModKey.MakeFormKey(0x5b4d);
            public static FormKey LootUrnGoldChangeNordic => ModKey.MakeFormKey(0x5b4c);
            public static FormKey LootImperialLuckDwemer => ModKey.MakeFormKey(0x55e8);
            public static FormKey LootPerkGoldenTouchDwemer => ModKey.MakeFormKey(0x55e9);
            public static FormKey LootGoldChangeDwemer => ModKey.MakeFormKey(0x55e7);
            public static FormKey CoinPurseGoldLargeDwemer => ModKey.MakeFormKey(0x275d2);
            public static FormKey CoinPurseGoldMediumDwemer => ModKey.MakeFormKey(0x275d1);
            public static FormKey CoinPurseGoldSmallDwemer => ModKey.MakeFormKey(0x275d0);
            public static FormKey CoinPurseGoldLargeNordic => ModKey.MakeFormKey(0x275cf);
            public static FormKey CoinPurseGoldMediumNordic => ModKey.MakeFormKey(0x275ce);
            public static FormKey CoinPurseGoldSmallNordic => ModKey.MakeFormKey(0x275cd);
            public static FormKey LootGoldChange25DwemerGold => ModKey.MakeFormKey(0x275cc);
            public static FormKey LootGoldChange25DwemerSilver => ModKey.MakeFormKey(0x275cb);
            public static FormKey LootGoldChange25Dwemer => ModKey.MakeFormKey(0x275ca);
            public static FormKey LootGoldChange25NordicGold => ModKey.MakeFormKey(0x275c9);
            public static FormKey LootGoldChange25NordicSilver => ModKey.MakeFormKey(0x275c8);
            public static FormKey LootGoldChange25Silver => ModKey.MakeFormKey(0x40b79);
            public static FormKey LootGoldChange25Gold => ModKey.MakeFormKey(0x40b78);
            public static FormKey LootPerkGoldenTouchNordic => ModKey.MakeFormKey(0x55e6);
            public static FormKey LootFalmerGoldBossDwemer => ModKey.MakeFormKey(0xab0cc);
            public static FormKey LootFalmerCorpseGoldSublistDwemer => ModKey.MakeFormKey(0xab0cb);
        }
    }
}
