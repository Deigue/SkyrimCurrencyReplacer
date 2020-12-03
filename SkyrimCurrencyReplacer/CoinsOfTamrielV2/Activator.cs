using Mutagen.Bethesda;

namespace SkyrimCurrencyReplacer.CoinsOfTamrielV2
{
    public static partial class CoinsOfTamrielV2
    {
        public static class Activator
        {
            private static readonly ModKey ModKey = ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");
            public static FormKey DLC2GoldPile03 => ModKey.MakeFormKey(0x182a2);
            public static FormKey DLC2GoldPile04 => ModKey.MakeFormKey(0x182a3);
            public static FormKey DLC2GoldPile06 => ModKey.MakeFormKey(0x45c81);
            public static FormKey DLC2GoldPile05 => ModKey.MakeFormKey(0x45c7f);
        }
    }
}
