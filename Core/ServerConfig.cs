using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorAndAccessoryPrefixes.Core;

public class ServerConfig : ModConfig
{
	public static ServerConfig Instance => ModContent.GetInstance<ServerConfig>();

    public override ConfigScope Mode => ConfigScope.ServerSide;

	[DefaultValue(true)]
	[ReloadRequired]
	public bool EnableArmorPrefixes;

	[DefaultValue(true)]
	[ReloadRequired]
	public bool EnableNewAccessoryPrefixes;

	[DefaultValue(true)]
	[ReloadRequired]
	public bool RemoveOddTierPrefixes;
}
