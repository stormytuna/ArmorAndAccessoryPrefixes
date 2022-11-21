using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorAndAccessoryPrefixes.Common.Config {
    public class ServerConfig : ModConfig {
        public static ServerConfig Instance;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("New Accessory prefixes")]
        [DefaultValue(true)]
        public bool AccessoryPrefixes { get; set; }

        [Label("Armor Prefixes")]
        [DefaultValue(true)]
        public bool ArmorPrefixes { get; set; }

        [Label("Remove 1% and 3% prefixes")]
        [DefaultValue(true)]
        public bool RemoveSteps { get; set; }
    }
}
