using Terraria;

namespace ArmorAndAccessoryPrefixes {
    public static class Helpers {
        /// <summary>Returns true if an item is armor, returns false otherwise</summary>
        public static bool IsArmor(this Item item) {
            return item.headSlot > 0 || item.bodySlot > 0 || item.legSlot > 0;
        }
    }
}
