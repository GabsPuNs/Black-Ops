using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class DeadshotBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Deadshot Daiquiri Tier I");
			// Description.SetDefault("25% Increased Crit Chance");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetCritChance(DamageClass.Generic) += 25;
		}
	}
}