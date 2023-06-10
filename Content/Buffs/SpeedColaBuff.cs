using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class SpeedColaBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Speed Cola Tier I");
			// Description.SetDefault("25% Increased Melee Attack Speed");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
			player.GetAttackSpeed(DamageClass.Throwing) += 0.25f;
		}
	}
}