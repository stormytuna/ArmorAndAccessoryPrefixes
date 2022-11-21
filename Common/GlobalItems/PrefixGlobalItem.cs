using ArmorAndAccessoryPrefixes.Common.Config;
using ArmorAndAccessoryPrefixes.Content.Prefixes.Armor;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ArmorAndAccessoryPrefixes.Common.GlobalItems {
    public class PrefixGlobalItem : GlobalItem {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.IsArmor() || entity.accessory;

        // Helper properties that get a list of our prefixes
        private static int[] removedAccessoryPrefixes = new int[] {
            PrefixID.Hard,
            PrefixID.Armored,
            PrefixID.Jagged,
            PrefixID.Angry,
            PrefixID.Fleeting,
            PrefixID.Quick,
            PrefixID.Wild,
            PrefixID.Intrepid,
        };

        private static int[] armorPrefixes = new int[] {
            ModContent.PrefixType<Hearty>(),
            ModContent.PrefixType<Vital>(),
            ModContent.PrefixType<Blessed>(),
            ModContent.PrefixType<Exalted>(),
            ModContent.PrefixType<Tranquil>(),
            ModContent.PrefixType<Seething>(),
            ModContent.PrefixType<Holy>(),
            ModContent.PrefixType<Divine>()
        };

        private static int[] legPrefixes = new int[] {
            ModContent.PrefixType<Vaulting>(),
            ModContent.PrefixType<Leaping>(),
            ModContent.PrefixType<Escalating>(),
            ModContent.PrefixType<Accelerating>()
        };

        private static int[] bodyPrefixes = new int[] {
            ModContent.PrefixType<Bulky>(),
            ModContent.PrefixType<Fortified>(),
            ModContent.PrefixType<Lofty>(),
            ModContent.PrefixType<Soaring>()
        };

        private static int[] headPrefixes = new int[] {
            ModContent.PrefixType<Piercing>(),
            ModContent.PrefixType<Shattering>(),
            ModContent.PrefixType<Casters>(),
            ModContent.PrefixType<Defenders>()
        };

        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand) {
            if (item.IsArmor() && ServerConfig.Instance.ArmorPrefixes) {
                switch (pre) {
                    // Lets armor be placed in tinker slot
                    case -3:
                        return true;
                    // Armor spawns in with a prefix 50% of the time
                    case -1:
                        return Utils.NextBool(rand, 2);
                }
            }

            if (item.accessory && ServerConfig.Instance.RemoveSteps) {
                // Prevent accessories spawning with a removed prefix
                if (removedAccessoryPrefixes.Contains(pre)) {
                    return false;
                }
            }

            return base.PrefixChance(item, pre, rand);
        }

        public override bool AllowPrefix(Item item, int pre) {
            // Removes prefixes from accessories
            if (removedAccessoryPrefixes.Contains(pre) && ServerConfig.Instance.RemoveSteps) {
                return false;
            }

            return base.AllowPrefix(item, pre);
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand) {
            // Gives armor prefixes
            if (item.IsArmor() && ServerConfig.Instance.ArmorPrefixes) {
                List<int> prefixes = armorPrefixes.ToList();
                if (item.legSlot > 0) {
                    prefixes.AddRange(legPrefixes.ToList());
                }
                if (item.bodySlot > 0) {
                    prefixes.AddRange(bodyPrefixes.ToList());
                }
                if (item.headSlot > 0) {
                    prefixes.AddRange(headPrefixes.ToList());
                }
                return rand.NextFromList(prefixes.ToArray());
            }

            // Don't need to add our accessory prefixes here as they can be naturally rolled

            return base.ChoosePrefix(item, rand);
        }
    }
}
