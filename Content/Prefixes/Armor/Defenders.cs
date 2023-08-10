﻿using ArmorAndAccessoryPrefixes.Common.Configs;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Armor;

public class Defenders : ArmorPrefix
{
	public override bool CanRoll(Item item) => item.headSlot > 0 && ServerConfig.Instance.CasterDefender;

	public override void ModifyValue(ref float valueMult) => valueMult = 1.15f;

	public override void Apply(Item item) {
		base.Apply(item);
		bool gotItem = item.TryGetGlobalItem(out ArmorGlobalItem gi);
		if (gotItem) {
			gi.SentrySlots = 1;
		}
	}

	public override string Name => "Defender's";
}