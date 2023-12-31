using Terraria;
using Terraria.ModLoader;
using BlackOps.Core;

namespace BlackOps.Content.Buffs
{
	public class DoubleTapIIBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Double Tap Root Beer Tier II");
			// Description.SetDefault("Increased Ranged Firing Speed By 10%.\n50% Increased Ranged Damage.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Ranged) += 0.10f;
			player.GetDamage(DamageClass.Ranged) += 0.50f;
		}
	}
}