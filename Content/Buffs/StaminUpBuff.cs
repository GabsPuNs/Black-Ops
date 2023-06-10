using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class StaminUpBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Stamin-Up Tier I");
			// Description.SetDefault("25% Increased Movement Speed");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.moveSpeed *= 1.25f;
		}
	}
}