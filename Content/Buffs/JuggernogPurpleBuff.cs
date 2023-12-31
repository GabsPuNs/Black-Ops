using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class JuggernogPurpleBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Juggernog Purple Tier I");
			// Description.SetDefault("Max Mana Increased By 25%.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
		    player.statLifeMax2 = (int)((double)(float)player.statManaMax2 * 1.25);
		}
	}
}