using Terraria;
using Terraria.ModLoader;

namespace ArmorAndAccessoryPrefixes.Common.Systems {
    public class DetourSystem : ModSystem {
        public override void Load() {
            On.Terraria.UI.ItemSlot.MouseHover_ItemArray_int_int += ItemSlot_MouseHover_ItemArray_int_int;
        }

        public override void Unload() {
            On.Terraria.UI.ItemSlot.MouseHover_ItemArray_int_int -= ItemSlot_MouseHover_ItemArray_int_int;
        }

        private void ItemSlot_MouseHover_ItemArray_int_int(On.Terraria.UI.ItemSlot.orig_MouseHover_ItemArray_int_int orig, Terraria.Item[] inv, int context, int slot) {
            orig(inv, context, slot);

            var item = Main.mouseItem;
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
}
