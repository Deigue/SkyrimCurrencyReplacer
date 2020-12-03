using Mutagen.Bethesda;

namespace SkyrimCurrencyReplacer.CoinsOfTamrielV2
{
    public static partial class CoinsOfTamrielV2
    {
        public static class Flora
        {
            private static readonly ModKey ModKey = ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");
            public static FormKey CoinPurseLargeNordic => ModKey.MakeFormKey(0x275d5);
            public static FormKey CoinPurseSmallDwemer => ModKey.MakeFormKey(0x275d6);
            public static FormKey CoinPurseMediumDwemer => ModKey.MakeFormKey(0x275d7);
            public static FormKey CoinPurseLargeDwemer => ModKey.MakeFormKey(0x275d8);
            public static FormKey CoinPurseSmallNordic => ModKey.MakeFormKey(0x275d3);
            public static FormKey CoinPurseMediumNordic => ModKey.MakeFormKey(0x275d4);
        }
    }
}
