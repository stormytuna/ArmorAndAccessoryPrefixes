using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Blessed : ArmorPrefix {
        public override bool CanRoll(Item item) => item.IsArmor() && ServerConfig.Instance.BlessedExalted;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.1f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().CritDamage = 1.025f;
        }
    }
}
