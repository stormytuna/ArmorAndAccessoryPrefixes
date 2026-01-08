namespace ArmorAndAccessoryPrefixes.Core;

public class GrabRangePlayer : ModPlayer
{
	public int GrabRange = 0;

	public override void ResetEffects() {
		GrabRange = 0;
	}
}

public class GrabRangeGlobalItem : GlobalItem
{
	public override void GrabRange(Item item, Player player, ref int grabRange) {
		int extraGrabRange = player.GetModPlayer<GrabRangePlayer>().GrabRange;
		grabRange += extraGrabRange * 16;
	}
}
