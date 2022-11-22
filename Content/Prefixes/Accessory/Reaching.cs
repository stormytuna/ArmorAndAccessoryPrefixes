using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Accessory {
    public class Reaching : AccessoryPrefix {
        public override bool CanRoll(Item item) => item.accessory && ServerConfig.Instance.AccessoryPrefixes && ServerConfig.Instance.ReachingExtending;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.1f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<AccessoryGlobalItem>().TileReach = 1;
        }
    }
}
