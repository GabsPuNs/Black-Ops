using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace BlackOps.Content.Projectiles
{
	public class MuzzleFlash : ModProjectile
    {
        public override string Texture => "BlackOps/Content/Projectiles/MuzzleFlash";

		private Player owner => Main.player[Projectile.owner];

		private Vector2 offset = Vector2.Zero;

		private bool initialized = false;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Muzzle Flash");
		}
		public override void SetDefaults()
		{
			Projectile.width = 2;
			Projectile.damage = 0;
			Projectile.height = 2;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 5;
			Projectile.friendly = false;
		}

        public override void AI()
        {
            if (!initialized)
            {
				initialized = true;
				offset = Projectile.Center - owner.Center;
            }
			Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.4f);
			Projectile.Center = owner.Center + offset;
			Projectile.rotation = Projectile.ai[0];
        }
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D mainTex = TextureAssets.Projectile[Projectile.type].Value;
			Main.spriteBatch.Draw(mainTex, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, new Vector2(8, mainTex.Height / 2), Projectile.scale, SpriteEffects.None, 0f);

			Texture2D glowTex = ModContent.Request<Texture2D>(Texture + "_Glow").Value;
			Color glowColor = Color.Orange;
			glowColor.A = 0;
			Main.spriteBatch.Draw(glowTex, Projectile.Center - Main.screenPosition, null, glowColor, Projectile.rotation, new Vector2(8, glowTex.Height / 2), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
	public class MuzzleFlashIce : MuzzleFlash
    {
        public override string Texture => "BlackOps/Content/Projectiles/MuzzleFlashIce";

        public override void AI()
        {
			Lighting.AddLight(Projectile.Center, Color.Blue.ToVector3() * 0.4f);
        }
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D glowTex = ModContent.Request<Texture2D>("BlackOps/Content/Projectiles/MuzzleFlash_Glow").Value;
			Color glowColor = Color.Blue;
			return false;
		}
	}
	public class MuzzleFlashRayGun : MuzzleFlash
    {
        public override string Texture => "BlackOps/Content/Projectiles/MuzzleFlashRayGun";

        public override void AI()
        {
			Lighting.AddLight(Projectile.Center, Color.Green.ToVector3() * 0.4f);
        }
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D glowTex = ModContent.Request<Texture2D>("BlackOps/Content/Projectiles/MuzzleFlash_Glow").Value;
			Color glowColor = Color.Green;
			return false;
		}
	}
}