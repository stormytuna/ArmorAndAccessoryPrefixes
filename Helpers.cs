namespace ArmorAndAccessoryPrefixes;

public static class Helpers 
{
	public static bool IsArmor(this Item item) {
		return item.headSlot >= 0 || item.bodySlot >= 0 || item.legSlot >= 0;
	}
}
