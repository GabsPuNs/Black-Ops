using Terraria.ID;
using Terraria.ModLoader;
using BlackOps.Content.Items.Ammo.Bullets;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Ammo.Bullets
{
	public class RayGunBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 16;

			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;

			Item.knockBack = 2f;
			Item.value = 20;
			Item.rare = 5;
			Item.maxStack = 180;
			Item.consumable = true;

			Item.ammo = Item.type;
		}
	}
}