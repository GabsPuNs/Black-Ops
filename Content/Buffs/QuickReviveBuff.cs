using Terraria;
using Terraria.ModLoader;
using BlackOps.Core;

namespace BlackOps.Content.Buffs
{
	public class QuickReviveBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Quick Revive Tier I");
			// Description.SetDefault("Life Regen Increased By 50%\nYou Will Be Revived Apon Death.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<MyPlayer>().QuickRevive = true;
			player.lifeRegen = (int)((float)player.lifeRegen * 1.5f);
		}
	}
}