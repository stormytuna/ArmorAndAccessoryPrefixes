using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Accessory {
    public class Colossal : AccessoryPrefix {
        public override bool CanRoll(Item item) => item.accessory && ServerConfig.Instance.AccessoryPrefixes;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<AccessoryGlobalItem>().MinionKnockback = 1f;
        }
    }
}
