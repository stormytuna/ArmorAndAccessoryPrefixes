using Terraria.DataStructures;

namespace ArmorAndAccessoryPrefixes.Core;

public class MaxFlightTimePlayer : ModPlayer
{
	public int ExtraMaxFlightTime = 0;

	public override void ResetEffects() {
		ExtraMaxFlightTime = 0;
	}

	public override void Load() {
		On_Player.GetWingStats += static (orig, self, wingId) => {
			WingStats ret = orig(self, wingId);

			int extraFlightTime = self.GetModPlayer<MaxFlightTimePlayer>().ExtraMaxFlightTime;
			ret.FlyTime += extraFlightTime;

			return ret;
		};
	}
}
