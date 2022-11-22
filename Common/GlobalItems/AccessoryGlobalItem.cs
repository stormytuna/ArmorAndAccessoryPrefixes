using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ArmorAndAccessoryPrefixes.Common.GlobalItems {
    public class AccessoryGlobalItem : GlobalItem {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.accessory;

        public int MaxMana { get; set; } = 0;

        public float ReducedAmmo { get; set; } = 0f;

        public float MinionKnockback { get; set; } = 0f;

        public int TileReach { get; set; } = 0;

        public int PickupRange { get; set; } = 0;

        public float MiningSpeed { get; set; } = 0f;

        public override void UpdateEquip(Item item, Player player) {
            player.statManaMax2 += MaxMana;
            if (ReducedAmmo == 0.1f) {
                player.GetModPlayer<AccessoryPlayer>().ReducedAmmoTier1++;
            }
            if (ReducedAmmo == 0.2f) {
                player.GetModPlayer<AccessoryPlayer>().ReducedAmmoTier2++;
            }
            player.GetKnockback(DamageClass.Summon) += MinionKnockback;
            player.blockRange += TileReach;
            player.GetModPlayer<AccessoryPlayer>().PickupRange = PickupRange;
            player.pickSpeed += MiningSpeed;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            // Should be after the last "Tooltip*" line
            int index = tooltips.FindLastIndex(tip => tip.Name.StartsWith("Tooltip")) + 1;

            if (MaxMana > 0) {
                TooltipLine line = new(Mod, "PrefixMaxMana", $"+{MaxMana} mana");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }

            if (ReducedAmmo > 0) {
                int reducedAmmo = (int)(ReducedAmmo * 100f);
                TooltipLine line = new(Mod, "PrefixReducedAmmo", $"{reducedAmmo}% reduced ammo consumption");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }

            if (MinionKnockback > 0) {
                string minionKnockback = string.Format("{0:0.#}", MinionKnockback);
                TooltipLine line = new(Mod, "PrefixMinionKnockback", $"+{minionKnockback} minion knockback");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }

            if (TileReach > 0) {
                TooltipLine line = new(Mod, "PrefixTileReach", $"+{TileReach} tile reach");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }

            if (PickupRange > 0) {
                TooltipLine line = new(Mod, "PrefixPickupRange", $"+{PickupRange} item pickup range");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }

            if (MiningSpeed > 0f) {
                int miningSpeed = (int)(MiningSpeed * 100f);
                TooltipLine line = new(Mod, "PrefixMiningSpeed", $"+{miningSpeed}% mining speed");
                line.IsModifier = true;
                tooltips.Insert(index, line);
            }
        }

        public override bool PreReforge(Item item) {
            MaxMana = 0;
            ReducedAmmo = 0f;
            MinionKnockback = 0f;
            TileReach = 0;
            PickupRange = 0;
            MiningSpeed = 0f;

            return base.PreReforge(item);
        }

        #region Not sure what to tag this, just leave it alone i guess

        public override void OnCreate(Item item, ItemCreationContext context) {
            MaxMana = 0;
            ReducedAmmo = 0f;
            MinionKnockback = 0f;
            TileReach = 0;
            PickupRange = 0;
            MiningSpeed = 0f;
        }

        public override GlobalItem Clone(Item from, Item to) {
            var clone = (AccessoryGlobalItem)base.Clone(from, to);
            clone.MaxMana = MaxMana;
            clone.ReducedAmmo = ReducedAmmo;
            clone.MinionKnockback = MinionKnockback;
            clone.TileReach = TileReach;
            clone.PickupRange = PickupRange;
            clone.MiningSpeed = MiningSpeed;
            return clone;
        }

        public override void SaveData(Item item, TagCompound tag) {
            tag["maxMana"] = MaxMana;
            tag["reducedAmmo"] = ReducedAmmo;
            tag["minionKnockback"] = MinionKnockback;
            tag["tileReach"] = TileReach;
            tag["pickupRange"] = PickupRange;
            tag["miningSpeed"] = MiningSpeed;
        }

        public override void LoadData(Item item, TagCompound tag) {
            MaxMana = tag.GetInt("maxMana");
            ReducedAmmo = tag.GetFloat("reducedAmmo");
            MinionKnockback = tag.GetFloat("minionKnockback");
            TileReach = tag.GetInt("tileReach");
            PickupRange = tag.GetInt("pickupRange");
            MiningSpeed = tag.GetFloat("miningSpeed");
        }

        #endregion
    }

    public class AccessoryPlayer : ModPlayer {
        public int ReducedAmmoTier1 { get; set; }
        public int ReducedAmmoTier2 { get; set; }

        public int PickupRange { get; set; }

        public override void ResetEffects() {
            ReducedAmmoTier1 = 0;
            ReducedAmmoTier2 = 0;
            PickupRange = 0;
        }

        public override void Load() {
            On.Terraria.Player.GetItemGrabRange += Player_GetItemGrabRange;
        }

        public override void Unload() {
            On.Terraria.Player.GetItemGrabRange -= Player_GetItemGrabRange;
        }

        private int Player_GetItemGrabRange(On.Terraria.Player.orig_GetItemGrabRange orig, Player self, Item item) {
            int ret = orig(self, item);

            ret += self.GetModPlayer<AccessoryPlayer>().PickupRange * 16;

            return ret;
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo) {
            // Weird solution ik but it's the easiest way to fix getting infinite ammo from additive bonuses
            for (int i = 0; i < ReducedAmmoTier1; i++) {
                if (Main.rand.NextBool(10)) {
                    return false;
                }
            }

            for (int i = 0; i < ReducedAmmoTier2; i++) {
                if (Main.rand.NextBool(5)) {
                    return false;
                }
            }

            return base.CanConsumeAmmo(weapon, ammo);
        }
    }
}
