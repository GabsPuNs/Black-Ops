using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class DyingWishBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dying Wish Tier I");
			// Description.SetDefault("You Will Be Revived Apon Death With 1 Health.\n20% More Damage When Revived.\nYou Are Immune For 3s Upon Death.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {

		}
	}
}