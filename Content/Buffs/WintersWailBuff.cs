using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class WintersWailBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Winter's Wail Tier I");
			// Description.SetDefault("Generate an explosion when hit you.\nExplosion ralentize and deal great damage to the enemies.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}