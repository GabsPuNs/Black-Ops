using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BlackOps.Content.Dusts;

namespace BlackOps.Content.Projectiles
{
    public class ExplosionRayGun : ModProjectile
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Ray Gun Cloud");
        }

        public override void SetDefaults() {
            Projectile.width = Projectile.height = 100;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Ranged; //cringe
            Projectile.penetrate = -1;
            Projectile.timeLeft = 2;
            Projectile.tileCollide = false;
            Projectile.light = 0.75f;
            Projectile.extraUpdates = 1;

            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
        }

        public override void AI() {
            for (int i = 0; i < 10; i++) {
                Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<RayGunDust>());
                dust.velocity = Main.rand.NextVector2Circular(10, 10);
                dust.scale = Main.rand.NextFloat(0.6f, 1.0f);
                dust.alpha = 70 + Main.rand.Next(60);
                dust.rotation = Main.rand.NextFloat(6.28f);
            }

            for (int i = 0; i < 10; i++) {
                Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<RayGunDustTwo>());
                dust.velocity = Main.rand.NextVector2Circular(10, 10);
                dust.scale = Main.rand.NextFloat(0.6f, 1.0f);
                dust.alpha = Main.rand.Next(80) + 40;
                dust.rotation = Main.rand.NextFloat(6.28f);
            }
        }
    }
}