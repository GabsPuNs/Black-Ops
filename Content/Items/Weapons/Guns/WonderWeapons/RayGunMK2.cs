using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using BlackOps.Content.Buffs;
using BlackOps.Content.Projectiles;
using BlackOps.Content.Items.Ammo.Bullets;
using BlackOps.Common.PlayerLayers;
using static Terraria.ModLoader.ModContent;

namespace BlackOps.Content.Items.Weapons.Guns.WonderWeapons
{
	public class RayGunMK2 : ModItem
	{
        public override string Texture => "BlackOps/Content/Items/Weapons/Guns/WonderWeapons/RayGunMK2";

		public override void SetDefaults() {

			Item.width = 58;
			Item.height = 26;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/WonderWeapons/RayGunMK2");
				
			Item.damage = 500;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.autoReuse = true;

            if (!Main.dedServ)
            {
                Item.GetGlobalItem<ItemUseGlow>().glowTexture = Request<Texture2D>(Texture + "_Glow").Value;
            }

			Item.shoot = ModContent.ProjectileType<RayGunBulletProjectile>();
			Item.shootSpeed = 11f;
			Item.useAmmo = ModContent.ItemType<RayGunBullet>();
			Item.channel = true;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(1, -1);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float rot = velocity.ToRotation();
			float spread = 0.4f;

            Vector2 offset = new Vector2(0.4f, -0.03f * player.direction).RotatedBy(rot);
            Vector2 offset2 = new Vector2(0.3f, -0.05f * player.direction).RotatedBy(rot);

			// Rotate the velocity randomly by 30 degrees at max.
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2));

			// Decrease velocity randomly for nicer visuals.
			newVelocity *= 1f - Main.rand.NextFloat(0.1f);

			for (int k = 0; k < 15; k++)
			{
				var direction = offset.RotatedByRandom(spread);

				Dust.NewDustPerfect(position + (offset * 70), ModContent.DustType<Dusts.Glow>(), direction * Main.rand.NextFloat(8), 125, new Color(85, 150, 40), Main.rand.NextFloat(0.2f, 0.5f));
			}

			Dust.NewDustPerfect(player.Center + offset * 70, ModContent.DustType<Dusts.Smoke>(), Vector2.UnitY * -2 + offset.RotatedByRandom(spread) * 5, 0, new Color(78, 144, 32) * 0.5f, Main.rand.NextFloat(0.5f, 1));
			Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), position + (offset2 * 70), newVelocity, type, damage, knockback, player.whoAmI);

			Projectile.NewProjectile(player.GetSource_ItemUse(Item), position + (offset * 70), Vector2.Zero, ModContent.ProjectileType<MuzzleFlashRayGun>(), 0, 0, player.whoAmI, rot);
  			return false;
        }
	}
}
