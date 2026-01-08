namespace ArmorAndAccessoryPrefixes.Core;

public class CritDamagePlayer : ModPlayer
{
	public float CritDamage = 0f;

	public override void ResetEffects() {
		CritDamage = 0f;
	}

	public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
		modifiers.CritDamage += CritDamage;
	}
}
