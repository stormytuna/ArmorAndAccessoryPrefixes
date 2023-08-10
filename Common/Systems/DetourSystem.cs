using ArmorAndAccessoryPrefixes.Common.Configs;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ArmorAndAccessoryPrefixes.Common.Systems;

public class DetourSystem : ModSystem
{
    public override void Load() {
        if (ServerConfig.Instance.ArmorPrefixes) {
            On_ItemSlot.MouseHover_ItemArray_int_int += ItemSlot_MouseHover_ItemArray_int_int;
        }
    }

    public override void Unload() {
        if (ServerConfig.Instance.ArmorPrefixes) {
            On_ItemSlot.MouseHover_ItemArray_int_int -= ItemSlot_MouseHover_ItemArray_int_int;
        }
    }

    private void ItemSlot_MouseHover_ItemArray_int_int(On_ItemSlot.orig_MouseHover_ItemArray_int_int orig, Item[] inv, int context, int slot) {
        orig(inv, context, slot);

        Item item = Main.mouseItem;
        if (item.IsArmor()) {
            switch (context) {
                case 10:
                    item.accessory = false;
                    return;
                case 5:
                    item.accessory = (item.IsArmor() && !item.accessory) || item.accessory;
                    return;
            }
        }
    }
}