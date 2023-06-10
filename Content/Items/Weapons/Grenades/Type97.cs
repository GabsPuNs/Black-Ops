using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Grenades
{
	public class Type97 : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Type97 Grenade");
		}

		public override void SetDefaults() {

			Item.CloneDefaults(168);

			Item.width = 14;
			Item.height = 22;
			Item.scale = 0.75f;
			Item.rare = 4;
			Item.maxStack = 4;

			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Grenades/FragGrenadeThrow");

			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.damage = 28;
			Item.knockBack = 28f;

			Item.shoot = ModContent.ProjectileType<Type97Proj>();
		}
	}
}
