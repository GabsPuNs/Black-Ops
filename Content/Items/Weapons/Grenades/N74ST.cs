using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Grenades
{
	public class N74ST : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("No.74 ST");
		}

		public override void SetDefaults() {

			Item.CloneDefaults(168);

			Item.width = 14;
			Item.height = 30;
			Item.scale = 0.75f;
			Item.rare = 4;
			Item.maxStack = 4;

			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Grenades/FragGrenadeThrow");

			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.damage = 63;
			Item.knockBack = 28f;

			Item.shoot = ModContent.ProjectileType<N74STProj>();
		}
	}
}
