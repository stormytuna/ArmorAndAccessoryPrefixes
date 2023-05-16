using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Soaring : ArmorPrefix {
        public override bool CanRoll(Item item) => item.bodySlot > 0 && ServerConfig.Instance.LoftySoaring;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);
            bool gotItem = item.TryGetGlobalItem(out ArmorGlobalItem gi);
            if (gotItem)
            {
                gi.FlightTime = 60;
            }
        }
    }
}
