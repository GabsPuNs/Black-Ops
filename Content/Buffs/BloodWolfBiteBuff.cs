using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class BloodWolfBiteBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Blood Wolf Bite");
			// Description.SetDefault("5% Increased Minions Crit Chance.\n15% Increased Minions Damage.\n+1 Minions Slot.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetCritChance(DamageClass.Summon) += 5;
			player.GetDamage(DamageClass.Summon) += 0.15f;
			player.maxMinions += 1;
		}
	}
}