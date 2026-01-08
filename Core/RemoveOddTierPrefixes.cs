using System.Linq;

namespace ArmorAndAccessoryPrefixes.Core;

public class RemoveOddTierPrefixes : GlobalItem
{
    private static readonly int[] removedAccessoryPrefixes = [
		PrefixID.Hard,
		PrefixID.Armored,
		PrefixID.Jagged,
		PrefixID.Angry,
		PrefixID.Brisk,
		PrefixID.Hasty2,
		PrefixID.Wild,
		PrefixID.Intrepid
	];

	public override bool AllowPrefix(Item item, int pre) {
		if (ServerConfig.Instance.RemoveOddTierPrefixes && removedAccessoryPrefixes.Contains(pre)) {
			return false;
		}

		return base.AllowPrefix(item, pre);
	}
}
