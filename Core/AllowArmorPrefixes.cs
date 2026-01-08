using Terraria.Utilities;

namespace ArmorAndAccessoryPrefixes.Core;

public class AllowArmorPrefixes : GlobalItem
{
    public override void Load() {
	On_Item.CanHavePrefixes += (orig, self) => {
	    bool ret = orig(self);

	    // TODO: Make this affect armor
	    if (self.type == ItemID.MagicMirror) {
		return true;
	    }

	    return ret;
	};
    }

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
	// TODO: Make this affect armor
	return entity.type == ItemID.MagicMirror;
    }

    public override bool CanReforge(Item item) {
	return true;
    }

    public override int ChoosePrefix(Item item, UnifiedRandom rand)
    {
	// TODO: Impl
	return 0;
    }
}
