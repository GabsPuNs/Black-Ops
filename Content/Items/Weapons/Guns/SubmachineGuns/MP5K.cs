using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.SubmachineGuns
{
	public class MP5K : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("MP5K");
		}

		public override void SetDefaults() {

			Item.width = 40;
			Item.height = 26;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/SubmachineGuns/MP5K");
			Item.useTime = 3;
			Item.useAnimation = 3;

			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 1.7f;
			Item.noMelee = true;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(8, 1);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float rot = velocity.ToRotation();
			float spread = 0.4f;

            Vector2 offset = new Vector2(0.7f, -0.02f * player.direction).RotatedBy(rot);
            Vector2 offset2 = new Vector2(0.5f, -0.02f * player.direction).RotatedBy(rot);

			for (int k = 0; k < 15; k++)
			{
				var direction = offset.RotatedByRandom(spread);

				Dust.NewDustPerfect(position + (offset * 70), ModContent.DustType<Dusts.Glow>(), direction * Main.rand.NextFloat(8), 125, new Color(150, 80, 40), Main.rand.NextFloat(0.2f, 0.5f));
			}

			Dust.NewDustPerfect(player.Center + offset * 70, ModContent.DustType<Dusts.Smoke>(), Vector2.UnitY * -2 + offset.RotatedByRandom(spread) * 5, 0, new Color(60, 55, 50) * 0.5f, Main.rand.NextFloat(0.5f, 1));
			Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), position + (offset2 * 70), velocity * 2, type, damage, knockback, player.whoAmI);

			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position + (offset * 70), Vector2.Zero, ModContent.ProjectileType<MuzzleFlash>(), 0, 0, player.whoAmI, rot);
  			return false;
        }
	}
}
