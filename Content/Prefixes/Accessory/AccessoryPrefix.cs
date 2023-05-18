using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;
using Terraria.ModLoader;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Accessory {
    public abstract class AccessoryPrefix : ModPrefix {
        public override PrefixCategory Category => PrefixCategory.Accessory;

        public override float RollChance(Item item) => 1f;

        public override bool CanRoll(Item item) => false;

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
            damageMult = 1f;
            knockbackMult = 1f;
            useTimeMult = 1f;
            scaleMult = 1f;
            shootSpeedMult = 1f;
            manaMult = 1f;
            critBonus = 0;
        }

        public override void Apply(Item item) {
            bool gotItem = item.TryGetGlobalItem(out AccessoryGlobalItem gi);
            if (gotItem)
            {
                gi.MaxMana = 0;
                gi.ReducedAmmo = 0;
                gi.MinionKnockback = 0;
                gi.TileReach = 0;
                gi.PickupRange = 0;
                gi.MiningSpeed = 0;
            }
        }
    }
}
