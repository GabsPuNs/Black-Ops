using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class SaleSodaBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sale Soda Tier I");
			// Description.SetDefault("???");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}