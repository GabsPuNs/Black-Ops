using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class VictoriousTortiseBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Victorious Tortise Tier I");
			// Description.SetDefault("Grants +4 defense.\n10% Increased Endurance.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 4;
			player.endurance += 0.10f;
		}
	}
}