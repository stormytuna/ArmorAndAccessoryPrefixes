using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Piercing : ArmorPrefix {
        public override bool CanRoll(Item item) => item.headSlot > 0;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2589f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().ArmorPenetration = 2;
        }
    }
}
