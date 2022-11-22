using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Leaping : ArmorPrefix {
        public override bool CanRoll(Item item) => item.legSlot > 0 && ServerConfig.Instance.VaultingLeaping;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().JumpSpeedBoost = 1.5f;
        }
    }
}
