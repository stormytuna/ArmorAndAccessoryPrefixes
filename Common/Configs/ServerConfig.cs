using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorAndAccessoryPrefixes.Common.Config
{
    public class ServerConfig : ModConfig
    {
        public static ServerConfig Instance;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("General")]

        [Label("[i:158] New Accessory prefixes")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool AccessoryPrefixes { get; set; }

        [Label("[i:81] Armor Prefixes")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool ArmorPrefixes { get; set; }

        [Label("[i:509] Remove 1% and 3% prefixes")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool RemoveSteps { get; set; }

        [Label("[i:850] Allow armor to get prefixes from other mods")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool OtherModdedArmorPrefixes { get; set; }

        [Header("Armor Prefixes")]

        [Label("[i:29] Hearty/Vital")]
        [Tooltip("Applies to armor\n+15/+30 max life")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool HeartyVital { get; set; }

        [Label("[i:1248] Blessed/Exalted")]
        [Tooltip("Applies to armor\n+5%/+10% critical strike damage")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool BlessedExalted { get; set; }

        [Label("[i:3016] Tranquil/Seething")]
        [Tooltip("Applies to armor\nEnemies are less/more likely to target you")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool TranquilSeething { get; set; }

        [Label("[i:49] Holy/Divine")]
        [Tooltip("Applies to armor\n+1/+2 life regeneration")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool HolyDivine { get; set; }

        [Label("[i:3212] Piercing/Shattering")]
        [Tooltip("Applies to head\n+2/+4 armor penetration")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool PiercingShattering { get; set; }

        [Label("[i:1158] Caster's/Defender's")]
        [Tooltip("Applies to head\n+1 minion/sentry slot")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool CasterDefender { get; set; }

        [Label("[i:3224] Bulky/Fortified")]
        [Tooltip("Applies to body\n+4%/+8% damage reduction")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool BulkyFortified { get; set; }

        [Label("[i:493] Lofty/Soaring")]
        [Tooltip("Applies to body\n+0.5s/1s flight time")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool LoftySoaring { get; set; }

        [Label("[i:2423] Vaulting/Leaping")]
        [Tooltip("Applies to legs\n+15%/+30% jump speed")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool VaultingLeaping { get; set; }

        [Label("[i:5107] Escalating/Accelerating")]
        [Tooltip("Applies to legs\n+25%/+50% acceleration")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool EscalatingAccelerating { get; set; }


        [Header("Accessory prefixes")]

        [Label("[i:109] Spellbound")]
        [Tooltip("+40 mana")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool Spellbound { get; set; }

        [Label("[i:2177] Plentiful/Bountiful")]
        [Tooltip("+10%/+20% reduced ammo consumption")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool PlentifulBountiful { get; set; }

        [Label("[i:1167] Sturdy/Colossal")]
        [Tooltip("+0.5/+1 minion knockback")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool SturdyColossal { get; set; }

        [Label("[i:2215] Reaching/Extending")]
        [Tooltip("+1/+2 tile range")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool ReachingExtending { get; set; }

        [Label("[i:5010] Pulling/Gravitating")]
        [Tooltip("+2/+4 item pickup range")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool PullingGravitating { get; set; }

        [Label("[i:4056] Speedy/Turbo")]
        [Tooltip("+5%/+10% mining speed")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool SpeedyTurbo { get; set; }
    }
}
