using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Accessory {
    public class Bountiful : AccessoryPrefix {
        public override bool CanRoll(Item item) => item.accessory && ServerConfig.Instance.AccessoryPrefixes && ServerConfig.Instance.PlentifulBountiful;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);
            bool gotItem = item.TryGetGlobalItem(out AccessoryGlobalItem gi);
            if (gotItem)
            {
                gi.ReducedAmmo = 0.2f;
            }
        }
    }
}
