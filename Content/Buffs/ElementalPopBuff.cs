using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Buffs
{
	public class ElementalPopBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Elemental Pop Tier I");
			// Description.SetDefault("Increased Magic Firing Speed By 10%.");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetAttackSpeed(DamageClass.Magic) += 0.10f;
		}
	}
}