using System.Collections.Generic;
using Terraria.Localization;

namespace ArmorAndAccessoryPrefixes.Prefixes;

public abstract class ArmorPrefix : ModPrefix
{
    public sealed override PrefixCategory Category => PrefixCategory.Custom;

	public override bool CanRoll(Item item) {
		return item.IsArmor();
	}
}

public abstract class MaxHPPrefix : ArmorPrefix
{
    public abstract int MaxHP { get; }

	private static LocalizedText MaxHPTooltip;

    public override void SetStaticDefaults()
    {
        MaxHPTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(MaxHPTooltip)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.MaxHP = MaxHP;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(MaxHPTooltip)}", MaxHPTooltip.Format(MaxHP)) {
            IsModifier = true
        };
    }
}

public class Hearty : MaxHPPrefix
{
	public override int MaxHP => 15;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Vital : MaxHPPrefix
{
	public override int MaxHP => 30;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public abstract class CritDamagePrefix : ArmorPrefix
{
    public abstract float CritDamage { get; }

	private static LocalizedText CritDamageTooltip;

    public override void SetStaticDefaults()
    {
        CritDamageTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(CritDamageTooltip)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.CritDamage = CritDamage;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(CritDamageTooltip)}", CritDamageTooltip.Format((int)(CritDamage * 100f))) {
            IsModifier = true
        };
    }
}

public class Blessed : CritDamagePrefix
{
	public override float CritDamage => 0.05f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Exalted : CritDamagePrefix
{
	public override float CritDamage => 0.05f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public class Tranquil : ArmorPrefix
{
    public const int AGGRO_REDUCTION = 200;

	private static LocalizedText ReducedAggroTooltip;

    public override void SetStaticDefaults()
    {
        ReducedAggroTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(ReducedAggroTooltip)}");
    }

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.15f;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.Aggro = -AGGRO_REDUCTION;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(ReducedAggroTooltip)}", ReducedAggroTooltip.Value) {
            IsModifier = true
        };
    }
}

public class Seething : ArmorPrefix
{
    public const int AGGRO_INCREASE = 200;

	private static LocalizedText IncreaseAggroTooltip;

    public override void SetStaticDefaults()
    {
        IncreaseAggroTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(IncreaseAggroTooltip)}");
    }

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.15f;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.Aggro = AGGRO_INCREASE;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(IncreaseAggroTooltip)}", IncreaseAggroTooltip.Value) {
            IsModifier = true
        };
    }
}

public abstract class LifeRegenPrefix : ArmorPrefix
{
    public abstract int LifeRegen { get; }

	private static LocalizedText LifeRegenTooltip;

    public override void SetStaticDefaults()
    {
        LifeRegenTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(LifeRegenTooltip)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.LifeRegen = LifeRegen;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(LifeRegenTooltip)}", LifeRegenTooltip.Format(LifeRegen / 2f)) {
            IsModifier = true
        };
    }
}

public class Holy : LifeRegenPrefix
{
	public override int LifeRegen => 1;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Divine : LifeRegenPrefix
{
	public override int LifeRegen => 2;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public abstract class JumpSpeedPrefix : ArmorPrefix
{
    public abstract float JumpSpeedBoost { get; }

	private static LocalizedText JumpSpeedBoostTooltip;

    public override void SetStaticDefaults()
    {
        JumpSpeedBoostTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(JumpSpeedBoostTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.legSlot >= 0;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.JumpSpeedBoost = JumpSpeedBoost;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(JumpSpeedBoostTooltip)}", JumpSpeedBoostTooltip.Format((int)(JumpSpeedBoost * 100f))) {
            IsModifier = true
        };
    }
}

public class Vaulting : JumpSpeedPrefix
{
	public override float JumpSpeedBoost => 0.6f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Leaping : JumpSpeedPrefix
{
	public override float JumpSpeedBoost => 1.2f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public abstract class ArmorPenPrefix : ArmorPrefix
{
    public abstract int ArmorPen { get; }

	private static LocalizedText ArmorPenTooltip;

    public override void SetStaticDefaults()
    {
        ArmorPenTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(ArmorPenTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.headSlot >= 0;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.ArmorPen = ArmorPen;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(ArmorPenTooltip)}", ArmorPenTooltip.Format(ArmorPen)) {
            IsModifier = true
        };
    }
}

public class Piercing : ArmorPenPrefix
{
	public override int ArmorPen => 2;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Shattering : ArmorPenPrefix
{
	public override int ArmorPen => 4;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public class Casters : ArmorPrefix
{
    public const int MINION_SLOTS = 1;

	private static LocalizedText IncreaseMinionSlotsTooltip;

    public override void SetStaticDefaults()
    {
        IncreaseMinionSlotsTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(IncreaseMinionSlotsTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.headSlot >= 0;
	}

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.MinionSlots = MINION_SLOTS;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(IncreaseMinionSlotsTooltip)}", IncreaseMinionSlotsTooltip.Format(MINION_SLOTS)) {
            IsModifier = true
        };
    }
}

public class Defenders : ArmorPrefix
{
    public const int SENTRY_SLOTS = 1;

	private static LocalizedText IncreaseSentrySlotsTooltip;

    public override void SetStaticDefaults()
    {
        IncreaseSentrySlotsTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(IncreaseSentrySlotsTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.headSlot >= 0;
	}

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.SentrySlots = SENTRY_SLOTS;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(IncreaseSentrySlotsTooltip)}", IncreaseSentrySlotsTooltip.Format(SENTRY_SLOTS)) {
            IsModifier = true
        };
    }
}

public abstract class DamageReductionPrefix : ArmorPrefix
{
    public abstract float DamageReduction { get; }

	private static LocalizedText DamageReductionTooltip;

    public override void SetStaticDefaults()
    {
        DamageReductionTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(DamageReductionTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.bodySlot >= 0;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.DamageReduction = DamageReduction;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(DamageReductionTooltip)}", DamageReductionTooltip.Format((int)(DamageReduction * 100f))) {
            IsModifier = true
        };
    }
}

public class Bulky : DamageReductionPrefix
{
	public override float DamageReduction => 0.04f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Fortified : DamageReductionPrefix
{
	public override float DamageReduction => 0.08f;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}

public abstract class FlightTimePrefix : ArmorPrefix
{
    public abstract int FlightTime { get; }

	private static LocalizedText FlightTimeTooltip;

    public override void SetStaticDefaults()
    {
        FlightTimeTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(FlightTimeTooltip)}");
    }

	public override bool CanRoll(Item item) {
		return item.bodySlot >= 0;
	}

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.FlightTime = FlightTime;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(FlightTimeTooltip)}", FlightTimeTooltip.Format(FlightTime / 60f)) {
            IsModifier = true
        };
    }
}

public class Lofty : FlightTimePrefix
{
	public override int FlightTime => 30;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
}

public class Soaring : FlightTimePrefix
{
	public override int FlightTime => 60;

	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.2f;
	}
}
