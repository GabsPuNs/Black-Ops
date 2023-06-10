using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.Carbines
{
	public class GalilCordova : ModItem
	{
		public override void SetDefaults() {

			Item.width = 68;
			Item.height = 24;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Carbines/GalilCordova");
			Item.useTime = 4;
			Item.useAnimation = 4;

			Item.damage = 75;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3.2f;
			Item.noMelee = true;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 17f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-9, 2);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float rot = velocity.ToRotation();
			float spread = 0.4f;

            Vector2 offset = new Vector2(0.625f, -0.03f * player.direction).RotatedBy(rot);
            Vector2 offset2 = new Vector2(0.625f, -0.05f * player.direction).RotatedBy(rot);
            Vector2 offset3 = new Vector2(0.525f, -0.05f * player.direction).RotatedBy(rot);

			// Rotate the velocity randomly by 30 degrees at max.
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(1));

			// Decrease velocity randomly for nicer visuals.
			newVelocity *= 1f - Main.rand.NextFloat(0.1f);

			for (int k = 0; k < 15; k++)
			{
				var direction = offset.RotatedByRandom(spread);

				Dust.NewDustPerfect(position + (offset * 70), ModContent.DustType<Dusts.Glow>(), direction * Main.rand.NextFloat(8), 125, new Color(150, 80, 40), Main.rand.NextFloat(0.2f, 0.5f));
			}

			Dust.NewDustPerfect(player.Center + offset * 70, ModContent.DustType<Dusts.Smoke>(), Vector2.UnitY * -2 + offset.RotatedByRandom(spread) * 5, 0, new Color(60, 55, 50) * 0.5f, Main.rand.NextFloat(0.5f, 1));
			Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), position + (offset3 * 70), newVelocity, type, damage, knockback, player.whoAmI);

			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position + (offset2 * 70), Vector2.Zero, ModContent.ProjectileType<MuzzleFlash>(), 0, 0, player.whoAmI, rot);
  			return false;
        }
	}
}
