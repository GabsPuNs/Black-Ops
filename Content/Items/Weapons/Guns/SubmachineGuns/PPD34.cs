using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.SubmachineGuns
{
	public class PPD34 : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("PPD-34");
		}

		public override void SetDefaults() {

			Item.width = 62;
			Item.height = 24;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/SubmachineGuns/PPD34");

			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 1.6f;
			Item.noMelee = true;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 11f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-7, -1);
		}
	}
}
