using Mutagen.Bethesda;

namespace SkyrimCurrencyReplacer.CoinsOfTamrielV2
{
    public static partial class CoinsOfTamrielV2
    {
        public static class MiscItem
        {
            private static readonly ModKey ModKey = ModKey.FromNameAndExtension("Coins of Tamriel V2 SSE Edition.esp");
            public static FormKey Gold002 => ModKey.MakeFormKey(0xd62);
            public static FormKey Gold003 => ModKey.MakeFormKey(0xd63);
            public static FormKey Alessia001 => ModKey.MakeFormKey(0x54db);
            public static FormKey Alessia002 => ModKey.MakeFormKey(0x54dc);
            public static FormKey Alessia003 => ModKey.MakeFormKey(0x54dd);
            public static FormKey Dwemercoin001 => ModKey.MakeFormKey(0x54de);
            public static FormKey Dwemercoin002 => ModKey.MakeFormKey(0x54df);
            public static FormKey Dwemercoin003 => ModKey.MakeFormKey(0x54e0);
        }
    }
}
