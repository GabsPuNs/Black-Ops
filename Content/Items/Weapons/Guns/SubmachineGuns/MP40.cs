using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.SubmachineGuns
{
	public class MP40 : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("MP40");
		}

		public override void SetDefaults() {

			Item.width = 48;
			Item.height = 24;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/SubmachineGuns/MP40");

			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 2f;
			Item.noMelee = true;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 14f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(6, 4);
		}
	}
}
