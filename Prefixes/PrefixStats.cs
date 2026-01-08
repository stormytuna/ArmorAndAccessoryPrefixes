using Terraria.ModLoader.IO;

namespace ArmorAndAccessoryPrefixes.Prefixes;

public class PrefixStats : GlobalItem
{
    // Accessory stats
    public int? MaxMana = null;
    public float? AmmoPreservation = null;
    public float? MinionKnockback = null;
    public int? TileReach = null;
    public int? PickupRange = null;
    public float? MiningSpeed = null;

    // Armor stats
    public int? MaxHP = null;
    public float? CritDamage = null;
    public int? Aggro = null;
    public int? LifeRegen = null;
    public float? JumpSpeedBoost = null;
    public float? RunSpeedBoost = null;
    public int? ArmorPen = null;
    public int? MinionSlots = null;
    public int? SentrySlots = null;
    public float? DamageReduction = null;
    public int? FlightTime = null;

    public override bool InstancePerEntity => true;

    public override void PreReforge(Item item)
    {
        MaxMana = null;
        AmmoPreservation = null;
        MinionKnockback = null;
        // TODO: rest of them...
    }

    public override void UpdateEquip(Item item, Player player)
    {
        if (MaxMana is not null) {
            player.statManaMax2 += MaxMana.Value;
        }

        if (MinionKnockback is not null) {
            player.GetKnockback(DamageClass.Summon).Base += MinionKnockback.Value;
        }

		if (TileReach is not null) {
			player.blockRange += TileReach.Value;
		}

        // TODO: rest of them...
    }

    public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player)
    {
        if (AmmoPreservation is not null && Main.rand.NextFloat() < AmmoPreservation.Value) {
            return false;
        }

        return base.CanConsumeAmmo(weapon, ammo, player);
    }

    public override void SaveData(Item item, TagCompound tag)
    {
        if (MaxMana is not null) {
            tag[nameof(MaxMana)] = MaxMana;
        }

        if (AmmoPreservation is not null) {
            tag[nameof(AmmoPreservation)] = AmmoPreservation;
        }

        if (MinionKnockback is not null) {
            tag[nameof(MinionKnockback)] = MinionKnockback;
        }

        // TODO: rest of them...
    }

    public override void LoadData(Item item, TagCompound tag)
    {
        if (tag.ContainsKey(nameof(MaxMana))) {
            MaxMana = tag.GetInt(nameof(MaxMana));
        }

        if (tag.ContainsKey(nameof(AmmoPreservation))) {
            AmmoPreservation = tag.GetInt(nameof(AmmoPreservation));
        }

        if (tag.ContainsKey(nameof(MinionKnockback))) {
            MinionKnockback = tag.GetInt(nameof(MinionKnockback));
        }

        // TODO: rest of them...
    }
}
