using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class JuggernogBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Juggernog Tier I");
			// Description.SetDefault("Max Health Increased By 25%.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
		    player.statLifeMax2 = (int)((double)(float)player.statLifeMax2 * 1.25);
		}
	}
}