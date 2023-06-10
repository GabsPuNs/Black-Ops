using BlackOps.Content.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BlackOps.Core
{
	public class MyPlayer : ModPlayer
	{
		public bool QuickRevive;

		public bool QuickReviveCooldown;

		public override void ResetEffects()
		{
			QuickRevive = false;
			QuickReviveCooldown = false;
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (QuickRevive)
			{
				Player.statLife = Player.statLifeMax2 / 2;
				Player.ClearBuff(ModContent.BuffType<QuickReviveBuff>());
				return false;
			}
			return true;
		}
	}
}