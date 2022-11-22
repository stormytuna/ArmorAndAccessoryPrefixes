using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Divine : ArmorPrefix {
        public override bool CanRoll(Item item) => item.IsArmor() && ServerConfig.Instance.HolyDivine;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().LifeRegen = 2;
        }
    }
}
