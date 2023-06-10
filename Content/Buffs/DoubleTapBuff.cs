using Terraria;
using Terraria.ModLoader;
using BlackOps.Core;

namespace BlackOps.Content.Buffs
{
	public class DoubleTapBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Double Tap Root Beer Tier I");
			// Description.SetDefault("Increased Ranged Firing Speed By 10%");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Ranged) += 0.10f;
		}
	}
}