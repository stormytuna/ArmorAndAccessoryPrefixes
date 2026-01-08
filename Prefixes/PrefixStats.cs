using ArmorAndAccessoryPrefixes.Core;
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
		TileReach = null;
		PickupRange = null;
		MiningSpeed = null;
		MaxHP = null;
		CritDamage = null;
		Aggro = null;
		LifeRegen = null;
		JumpSpeedBoost = null;
		RunSpeedBoost = null;
		ArmorPen = null;
		MinionSlots = null;
		SentrySlots = null;
		DamageReduction = null;
		FlightTime = null;
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

		if (PickupRange is not null) {
			player.GetModPlayer<GrabRangePlayer>().GrabRange += PickupRange.Value;
		}

		if (MiningSpeed is not null) {
			player.pickSpeed -= MiningSpeed.Value;
		}

		if (MaxHP is not null) {
			player.statLifeMax2 += MaxHP.Value;
		}

		if (CritDamage is not null) {
			player.GetModPlayer<CritDamagePlayer>().CritDamage += CritDamage.Value;
		}

		if (Aggro is not null) {
			player.aggro += Aggro.Value;
		}

		if (LifeRegen is not null) {
			player.lifeRegen += LifeRegen.Value;
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

        if (TileReach is not null) {
            tag[nameof(TileReach)] = TileReach;
        }

        if (PickupRange is not null) {
            tag[nameof(PickupRange)] = PickupRange;
        }

        if (MiningSpeed is not null) {
            tag[nameof(MiningSpeed)] = MiningSpeed;
        }

        if (MaxHP is not null) {
            tag[nameof(MaxHP)] = MaxHP;
        }

        if (CritDamage is not null) {
            tag[nameof(CritDamage)] = CritDamage;
        }

        if (Aggro is not null) {
            tag[nameof(Aggro)] = Aggro;
        }

        if (LifeRegen is not null) {
            tag[nameof(LifeRegen)] = LifeRegen;
        }

        if (JumpSpeedBoost is not null) {
            tag[nameof(JumpSpeedBoost)] = JumpSpeedBoost;
        }

        if (RunSpeedBoost is not null) {
            tag[nameof(RunSpeedBoost)] = RunSpeedBoost;
        }

        if (ArmorPen is not null) {
            tag[nameof(ArmorPen)] = ArmorPen;
        }

        if (MinionSlots is not null) {
            tag[nameof(MinionSlots)] = MinionSlots;
        }

        if (SentrySlots is not null) {
            tag[nameof(SentrySlots)] = SentrySlots;
        }

        if (DamageReduction is not null) {
            tag[nameof(DamageReduction)] = DamageReduction;
        }

        if (FlightTime is not null) {
            tag[nameof(FlightTime)] = FlightTime;
        }
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

        if (tag.ContainsKey(nameof(TileReach))) {
            TileReach = tag.GetInt(nameof(TileReach));
        }

        if (tag.ContainsKey(nameof(PickupRange))) {
            PickupRange = tag.GetInt(nameof(PickupRange));
        }

        if (tag.ContainsKey(nameof(MiningSpeed))) {
            MiningSpeed = tag.GetInt(nameof(MiningSpeed));
        }

        if (tag.ContainsKey(nameof(MaxHP))) {
            MaxHP = tag.GetInt(nameof(MaxHP));
        }

        if (tag.ContainsKey(nameof(CritDamage))) {
            CritDamage = tag.GetInt(nameof(CritDamage));
        }

        if (tag.ContainsKey(nameof(Aggro))) {
            Aggro = tag.GetInt(nameof(Aggro));
        }

        if (tag.ContainsKey(nameof(LifeRegen))) {
            LifeRegen = tag.GetInt(nameof(LifeRegen));
        }

        if (tag.ContainsKey(nameof(JumpSpeedBoost))) {
            JumpSpeedBoost = tag.GetInt(nameof(JumpSpeedBoost));
        }

        if (tag.ContainsKey(nameof(RunSpeedBoost))) {
            RunSpeedBoost = tag.GetInt(nameof(RunSpeedBoost));
        }

        if (tag.ContainsKey(nameof(ArmorPen))) {
            ArmorPen = tag.GetInt(nameof(ArmorPen));
        }

        if (tag.ContainsKey(nameof(MinionSlots))) {
            MinionSlots = tag.GetInt(nameof(MinionSlots));
        }

        if (tag.ContainsKey(nameof(SentrySlots))) {
            SentrySlots = tag.GetInt(nameof(SentrySlots));
        }

        if (tag.ContainsKey(nameof(DamageReduction))) {
            DamageReduction = tag.GetInt(nameof(DamageReduction));
        }

        if (tag.ContainsKey(nameof(FlightTime))) {
            FlightTime = tag.GetInt(nameof(FlightTime));
        }
    }
}
