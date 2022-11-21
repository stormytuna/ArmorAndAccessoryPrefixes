using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Vital : ArmorPrefix {
        public override bool CanRoll(Item item) => item.IsArmor();

        public override void ModifyValue(ref float valueMult) => valueMult = 1.4982f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().MaxHP = 30;
        }
    }
}
