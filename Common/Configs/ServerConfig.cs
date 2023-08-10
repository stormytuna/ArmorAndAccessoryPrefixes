using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorAndAccessoryPrefixes.Common.Configs;

public class ServerConfig : ModConfig
{
    public static ServerConfig Instance;

    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("General")]
    [ReloadRequired]
    [DefaultValue(true)]
    public bool AccessoryPrefixes { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ArmorPrefixes { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool RemoveSteps { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool OtherModdedArmorPrefixes { get; set; }

    [Header("ArmorPrefixes")]
    [ReloadRequired]
    [DefaultValue(true)]
    public bool HeartyVital { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool BlessedExalted { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool TranquilSeething { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool HolyDivine { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PiercingShattering { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool CasterDefender { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool BulkyFortified { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool LoftySoaring { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool VaultingLeaping { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool EscalatingAccelerating { get; set; }

    [Header("AccessoryPrefixes")]
    [ReloadRequired]
    [DefaultValue(true)]
    public bool Spellbound { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PlentifulBountiful { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SturdyColossal { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool ReachingExtending { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool PullingGravitating { get; set; }

    [ReloadRequired]
    [DefaultValue(true)]
    public bool SpeedyTurbo { get; set; }
}