using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Grenades
{
	public class M67 : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("M67 Frag");
		}

		public override void SetDefaults() {

			Item.CloneDefaults(168);

			Item.width = 16;
			Item.height = 20;
			Item.scale = 0.75f;
			Item.rare = 4;
			Item.maxStack = 4;

			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Grenades/FragGrenadeThrow");

			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.damage = 100;
			Item.knockBack = 28f;

			Item.shoot = ModContent.ProjectileType<M67Proj>();
		}
	}
}
