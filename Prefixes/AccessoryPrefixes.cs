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
