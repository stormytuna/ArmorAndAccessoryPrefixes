﻿using ArmorAndAccessoryPrefixes.Common.Configs;
using ArmorAndAccessoryPrefixes.Common.GlobalItems;
using Terraria;

namespace ArmorAndAccessoryPrefixes.Content.Prefixes.Accessory;

public class Speedy : AccessoryPrefix
{
	public override bool CanRoll(Item item) => item.accessory && ServerConfig.Instance.AccessoryPrefixes && ServerConfig.Instance.SpeedyTurbo;

	public override void ModifyValue(ref float valueMult) => valueMult = 1.1f;

	public override void Apply(Item item) {
		base.Apply(item);
		bool gotItem = item.TryGetGlobalItem(out AccessoryGlobalItem gi);
		if (gotItem) {
			gi.MiningSpeed = 0.05f;
		}
	}
}