using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using BlackOps.Content.Projectiles;
using BlackOps.Common.PlayerLayers;
using static Terraria.ModLoader.ModContent;

namespace BlackOps.Content.Items.Weapons.Guns.AssaultRifles
{
	public class IceFury : ModItem
	{
        public override string Texture => "BlackOps/Content/Items/Weapons/Guns/AssaultRifles/IceFury";

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Galil-Ice Fury");
		}

		public override void SetDefaults() {

			Item.width = 84;
			Item.height = 26;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Carbines/GalilCordova");
			Item.useTime = 4;
			Item.useAnimation = 4;

			Item.damage = 81;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3.4f;
			Item.noMelee = true;

            if (!Main.dedServ)
            {
                Item.GetGlobalItem<ItemUseGlow>().glowTexture = Request<Texture2D>(Texture + "_Glow").Value;
            }

			Item.shoot = ModContent.ProjectileType<IceFuryBulletProjectile>();
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			type = ModContent.ProjectileType<IceFuryBulletProjectile>();
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(-10, 2);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float rot = velocity.ToRotation();
			float spread = 0.4f;

            Vector2 offset = new Vector2(0.825f, -0.02f * player.direction).RotatedBy(rot);
            Vector2 offset2 = new Vector2(0.625f, -0.06f * player.direction).RotatedBy(rot);

			for (int k = 0; k < 15; k++)
			{
				var direction = offset.RotatedByRandom(spread);

				Dust.NewDustPerfect(position + (offset * 70), ModContent.DustType<Dusts.Glow>(), direction * Main.rand.NextFloat(8), 125, new Color(40, 82, 150), Main.rand.NextFloat(0.2f, 0.5f));
			}

			Dust.NewDustPerfect(player.Center + offset * 70, ModContent.DustType<Dusts.Smoke>(), Vector2.UnitY * -2 + offset.RotatedByRandom(spread) * 5, 0, new Color(60, 55, 50) * 0.5f, Main.rand.NextFloat(0.5f, 1));
			Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), position + (offset2 * 70), velocity * 2, type, damage, knockback, player.whoAmI);

			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position + (offset * 70), Vector2.Zero, ModContent.ProjectileType<MuzzleFlashIce>(), 0, 0, player.whoAmI, rot);
  			return false;
        }
	}
}
