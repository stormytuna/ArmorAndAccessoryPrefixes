namespace ArmorAndAccessoryPrefixes.Core;

public class BuffDurationPlayer : ModPlayer
{
	public float BuffDuration = 1f;

	public override void ResetEffects() {
		BuffDuration = 1f;
	}

	public override void Load() {
		On_Player.AddBuff_DetermineBuffTimeToAdd += (orig, self, type, time) => {
			int ret = orig(self, type, time);

			if (!Main.debuff[type]) {
				ret = (int)(ret * self.GetModPlayer<BuffDurationPlayer>().BuffDuration);
			}

			return ret;
		};
	}
}
