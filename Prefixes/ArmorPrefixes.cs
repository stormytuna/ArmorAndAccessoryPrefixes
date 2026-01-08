using System.Collections.Generic;
using Terraria.Localization;

namespace ArmorAndAccessoryPrefixes.Prefixes;

public abstract class ArmorPrefix : ModPrefix
{
    public sealed override PrefixCategory Category => PrefixCategory.Custom;

	public sealed override bool CanRoll(Item item) {
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
