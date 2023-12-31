using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class WidowsWineBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Widows Wine Tier I");
			// Description.SetDefault("35% Increased Melee Damage.\nGenerate an explosion when hit you.\nThe Explosion deal damage and ralentize enemies.\nThe Explosion requires Grenades.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetDamage(DamageClass.Melee) += 0.35f;
		}
	}
}