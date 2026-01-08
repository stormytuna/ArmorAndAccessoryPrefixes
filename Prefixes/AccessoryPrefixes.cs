using System.Collections.Generic;
using Terraria.Localization;

namespace ArmorAndAccessoryPrefixes.Prefixes;

public class Spellbound : ModPrefix
{
    public const int MANA_AMOUNT = 40;

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.MaxMana = MANA_AMOUNT;
        }
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(Spellbound)}", $"+{MANA_AMOUNT} {Lang.tip[31].Value}") {
            IsModifier = true
        };
    }
}

public abstract class AmmoPreservationPrefix : ModPrefix
{
    public abstract float AmmoPreservation { get; }

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.AmmoPreservation = AmmoPreservation;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(Spellbound)}", Language.GetTextValue("CommonItemTooltip.PercentChanceToSaveAmmo", (int)(AmmoPreservation * 100f))) {
            IsModifier = true
        };
    }
}

public class Extended : AmmoPreservationPrefix
{
    public override float AmmoPreservation => 0.1f;
    
    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }
}

public class Bountiful : AmmoPreservationPrefix
{
    public override float AmmoPreservation => 0.2f;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }
}

public abstract class MinionKnockbackPrefix : ModPrefix
{
    protected static LocalizedText MinionKnockbackTooltip { get; private set; }

    public abstract float MinionKnockback { get; }

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void SetStaticDefaults()
    {
        MinionKnockbackTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(MinionKnockbackTooltip)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.MinionKnockback = MinionKnockback;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(Spellbound)}", MinionKnockbackTooltip.Format(MinionKnockback)) {
            IsModifier = true
        };
    }
}

public class Sturdy : MinionKnockbackPrefix
{
    public override float MinionKnockback => 0.5f;
    
    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }
}

public class Colossal : MinionKnockbackPrefix
{
    public override float MinionKnockback => 1f;
    
    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }
}

public abstract class TileReachPrefix : ModPrefix
{
    protected static LocalizedText TileReachTooltip { get; private set; }

    public abstract int TileReach { get; }

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void SetStaticDefaults()
    {
        TileReachTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(TileReachTooltip)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.TileReach = TileReach;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(TileReachTooltip)}", TileReachTooltip.Format(TileReach)) {
            IsModifier = true
        };
    }
}

public class Reaching : TileReachPrefix
{
	public override int TileReach => 1;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }
}

public class Extending : TileReachPrefix
{
	public override int TileReach => 2;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }
}

public abstract class PickupRangePrefix : ModPrefix
{
    protected static LocalizedText PickupRangeTooltip { get; private set; }

    public abstract int PickupRange { get; }

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void SetStaticDefaults()
    {
        PickupRangeTooltip = Mod.GetLocalization($"PrefixTooltips.{nameof(PickupRangePrefix)}");
    }

    public override void Apply(Item item)
    {
        if (item.TryGetGlobalItem(out PrefixStats gi)) {
            gi.PickupRange = PickupRange;
        }
    }

    public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
    {
        yield return new TooltipLine(Mod, $"Prefix{nameof(PickupRangeTooltip)}", PickupRangeTooltip.Format(PickupRange)) {
            IsModifier = true
        };
    }
}

public class Pulling : PickupRangePrefix
{
	public override int PickupRange => 2;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }
}

public class Gravitating : PickupRangePrefix
{
	public override int PickupRange => 4;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }
}
