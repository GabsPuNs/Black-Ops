using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.SubmachineGuns
{
	public class MPL : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("MPL");
		}

		public override void SetDefaults() {

			Item.width = 48;
			Item.height = 26;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/SubmachineGuns/MPL");

			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 1.5f;
			Item.noMelee = true;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 11f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(7, 3);
		}
	}
}
