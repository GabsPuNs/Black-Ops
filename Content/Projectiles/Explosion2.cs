using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BlackOps.Content.Dusts;

namespace BlackOps.Content.Projectiles
{
    public class Explosion2 : ModProjectile
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Explosion");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults() {
            Projectile.width = Projectile.height = 12;
            Projectile.friendly = false;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged; //cringe
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.alpha = 255;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
        }

        public override void AI() {
            Projectile.scale *= 0.98f;
            if (Main.rand.Next(2) == 0)
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<NeedlerDustThree>(), Main.rand.NextVector2Circular(1.5f, 1.5f));
                dust.scale = 0.6f * Projectile.scale;
                dust.rotation = Main.rand.NextFloatDirection();
            }
        }
    }
}