using Mutagen.Bethesda;

namespace SkyrimCurrencyReplacer.COTV2
{
    public static partial class CoinsOfTamrielV2
    {
        public static class Quest
        {
            private static readonly ModKey ModKey = ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");
            public static FormKey CoinsOfTamriel => ModKey.MakeFormKey(0xb6d6);
        }
    }
}
