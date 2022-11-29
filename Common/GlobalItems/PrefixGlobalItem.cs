using ArmorAndAccessoryPrefixes.Common.Config;
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
            PrefixID.Brisk,
            PrefixID.Hasty2,
            PrefixID.Wild,
            PrefixID.Intrepid,
        };

        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand) {
            if (item.IsArmor() && ServerConfig.Instance.ArmorPrefixes) {
                switch (pre) {
                    // Lets armor be placed in tinker slot
                    case -3:
                        return true;
                    // Armor spawns in with a prefix 50% of the time
                    // maxStack check here prevents things like buckets getting prefixes when being crafted
                    case -1:
                        return Utils.NextBool(rand, 2) && item.maxStack == 1;
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
            if (removedAccessoryPrefixes.Contains(pre) && item.accessory && ServerConfig.Instance.RemoveSteps) {
                return false;
            }

            return base.AllowPrefix(item, pre);
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand) {
            // Gives armor prefixes
            if (item.IsArmor()) {
                var prefixes = PrefixLoader.GetPrefixesInCategory(PrefixCategory.Custom);
                List<ModPrefix> rollable = new();
                foreach (var pre in prefixes) {
                    if (pre.CanRoll(item)) {
                        rollable.Add(pre);
                    }
                }

                if (rollable.Count > 0) {
                    return rand.NextFromList(rollable.ToArray()).Type;
                }
            }

            // Don't need to add our accessory prefixes here as they can be naturally rolled

            return base.ChoosePrefix(item, rand);
        }

        public override void UpdateInventory(Item item, Player player) {
            if (item.IsArmor()) {
                item.accessory = false;

                if (item.canBePlacedInVanityRegardlessOfConditions && !item.vanity) {
                    item.vanity = true;
                    item.canBePlacedInVanityRegardlessOfConditions = false;
                }
            }
        }
    }
}
