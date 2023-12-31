using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace BlackOps.Content.Projectiles
{
    public class RayGunBulletProjectile : ModProjectile
    {
        public override string Texture => "BlackOps/Content/Projectiles/RayGunBulletProjectile";

        private Player Player => Main.player[Projectile.owner];

        private Vector2 direction = Vector2.Zero;

        public int ProjColdwn;

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Ray Gun");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults() {
            Projectile.width = 2;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;

            AIType = ProjectileID.Bullet;
        }

        public override void AI() {
            Lighting.AddLight(Projectile.position, 0f, 0.8f, 0f);
            ProjColdwn++;

            if  (ProjColdwn == 5f)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<RayGunBulletProjectile1>(), 0, 0f, Projectile.owner);

            if (ProjColdwn == 10f)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<RayGunBulletProjectile2>(), 0, 0f, Projectile.owner);
            
            if (ProjColdwn == 15f) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<RayGunBulletProjectile3>(), 0, 0f, Projectile.owner);
                ProjColdwn = 0;
            }
        }

        public override bool PreDraw(ref Color lightColor) {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;

            Vector2 drawOrigin = new Vector2(tex.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                SpriteEffects effects = Player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically;
                Texture2D bloomTex = ModContent.Request<Texture2D>(Texture + "_Glow").Value;
                Color bloomColor = Color.White;
                bloomColor.A = 0;

                Main.EntitySpriteDraw(bloomTex, drawPos, null, bloomColor, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
                Main.EntitySpriteDraw(tex, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            }

            return false;
        }

        public override void Kill(int timeLeft) {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ExplosionRayGun>(), Projectile.damage / 3, 0f, Projectile.owner);
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }

    public class RayGunBulletProjectile1 : ModProjectile
    {
        public override string Texture => "BlackOps/Content/Projectiles/RayGunBulletProjectile1";

        private Player Player => Main.player[Projectile.owner];

        private Vector2 direction = Vector2.Zero;

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Ray Gun");
        }

        public override void SetDefaults() {
            Projectile.width = 7;
            Projectile.height = 9;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.timeLeft = 60;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft < 85)
            {
                byte b = (byte)(Projectile.timeLeft * 3);
                byte a = (byte)(100f * (b / 255f));
                return new Color(b, b, b, a);
            }
            return new Color(255, 255, 255, 100);
        }

        public override void AI() {
            Lighting.AddLight(Projectile.position, 0f, 0.4f, 0f);
        }
    }

    public class RayGunBulletProjectile2 : RayGunBulletProjectile1
    {
        public override string Texture => "BlackOps/Content/Projectiles/RayGunBulletProjectile2";
    }

    public class RayGunBulletProjectile3 : RayGunBulletProjectile1
    {
        public override string Texture => "BlackOps/Content/Projectiles/RayGunBulletProjectile3";
    }
}