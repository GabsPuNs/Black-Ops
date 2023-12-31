using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace BlackOps.Content.Projectiles
{
    public class IceFuryBulletProjectile : ModProjectile
    {
        public override string Texture => "BlackOps/Content/Projectiles/IceFuryBulletProjectile";

        private Player Player => Main.player[Projectile.owner];

        private Vector2 direction = Vector2.Zero;

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Ice Fury");
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

            AIType = ProjectileID.BulletHighVelocity;
        }

        public override void AI() {
            Lighting.AddLight(Projectile.position, 0f, 0f, 0.8f);
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
    }
}