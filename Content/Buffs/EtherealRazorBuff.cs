using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class EtherealRazorBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ethereal Razor Tier I");
			// Description.SetDefault("Melee Attacks Ignore An Additional 5 Defense Points.\n15% Increased Melee Damage.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetArmorPenetration(DamageClass.Melee) += 5;
			player.GetDamage(DamageClass.Melee) += 0.15f;
		}
	}
}