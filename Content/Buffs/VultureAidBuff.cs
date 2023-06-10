using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class VultureAidBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Vulture Aid Tier I");
			// Description.SetDefault("33% Increased Movement Speed");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}