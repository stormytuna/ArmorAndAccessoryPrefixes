using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Accelerating : ArmorPrefix {
        public override bool CanRoll(Item item) => item.legSlot > 0 && ServerConfig.Instance.EscalatingAccelerating;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().RunSpeedBoost = 1.5f;
        }
    }
}
