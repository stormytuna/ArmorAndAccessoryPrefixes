using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public class Tranquil : ArmorPrefix {
        public override bool CanRoll(Item item) => item.IsArmor() && ServerConfig.Instance.TranquilSeething;

        public override void ModifyValue(ref float valueMult) => valueMult = 1.15f;

        public override void Apply(Item item) {
            base.Apply(item);
            bool gotItem = item.TryGetGlobalItem(out ArmorGlobalItem gi);
            if (gotItem)
            {
                gi.Aggro = -250;
            }
        }
    }
}
