using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class TombstoneBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Tomsbtone Tier I");
			// Description.SetDefault("???");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}