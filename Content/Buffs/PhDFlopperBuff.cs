using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class PhDFlopperBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("PhD Flopper Tier I");
			// Description.SetDefault("Reduces Explosion Damages To Player\nReduces Ray Gun Cloud Damage To Player\nReduces Fall Damage");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}