using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class TimeslipBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Timeslip Tier I");
			// Description.SetDefault("Decrease cooldown to use potions.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}