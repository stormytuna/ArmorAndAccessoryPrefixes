using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Shattering : ArmorPrefix {
        public override bool CanRoll(Item item) => item.headSlot > 0 && ServerConfig.Instance.PiercingShattering;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.2f;

        public override void Apply(Item item) {
            base.Apply(item);

            item.GetGlobalItem<ArmorGlobalItem>().ArmorPenetration = 4;
        }
    }
}
