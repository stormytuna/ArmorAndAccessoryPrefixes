using System.Collections.Generic;
using Terraria.Utilities;

namespace ArmorAndAccessoryPrefixes.Core;

public class AllowArmorPrefixes : GlobalItem
{
	public override bool IsLoadingEnabled(Mod mod) {
		return ServerConfig.Instance.EnableArmorPrefixes;
	}
	
	public override void Load() {
		On_Item.CanHavePrefixes += (orig, self) => {
			bool ret = orig(self);

			if (self.IsArmor()) {
				return true;
			}

			return ret;
		};
	}

	public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
		return entity.IsArmor();
	}

	public override bool CanReforge(Item item) {
		return true;
	}

	public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand) {
		return pre switch {
			-3 => true,
			-1 => item.maxStack == 1 && rand.NextBool(),
			_ => base.PrefixChance(item, pre, rand),
		};
	}

	public override int ChoosePrefix(Item item, UnifiedRandom rand)
	{
		IReadOnlyList<ModPrefix> allPrefixes = PrefixLoader.GetPrefixesInCategory(PrefixCategory.Custom);
		List<ModPrefix> rollablePrefixes = new();

		foreach (ModPrefix prefix in allPrefixes) {
			if (prefix.Mod.Name == nameof(ArmorAndAccessoryPrefixes) && prefix.CanRoll(item)) {
				rollablePrefixes.Add(prefix);
			}
		}

		if (rollablePrefixes.Count > 0) {
			return rand.Next(rollablePrefixes).Type;
		}

		return base.ChoosePrefix(item, rand);
	}
}
