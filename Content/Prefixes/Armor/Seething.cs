using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Seething : ArmorPrefix {
        public override bool CanRoll(Item item) => item.IsArmor();

        public override void ModifyValue(ref float valueMult) => valueMult = 1.3759f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().Aggro = 250;
        }
    }
}
