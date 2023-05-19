using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;
using Terraria.ModLoader;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor {
    public abstract class ArmorPrefix : ModPrefix {
        public override PrefixCategory Category => PrefixCategory.Custom;

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
            bool gotItem = item.TryGetGlobalItem(out ArmorGlobalItem gi);
            if (gotItem)
            {
                gi.MaxHP = 0;
                gi.CritDamage = 0f;
                gi.Aggro = 0;
                gi.LifeRegen = 0;
                gi.JumpSpeedBoost = 0f;
                gi.RunSpeedBoost = 1f;
                gi.ArmorPenetration = 0;
                gi.MinionSlots = 0;
                gi.SentrySlots = 0;
                gi.DamageReduction = 0;
                gi.FlightTime = 0;
            }   
        }
    }
}
