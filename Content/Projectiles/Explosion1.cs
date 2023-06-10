using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BlackOps.Content.Dusts;

namespace BlackOps.Content.Projectiles
{
    public class Explosion1 : ModProjectile
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Explosion");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults() {
            Projectile.width = Projectile.height = 200;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged; //cringe
            Projectile.penetrate = -1;
            Projectile.timeLeft = 20;
            Projectile.tileCollide = false;
            Projectile.light = 0.75f;
            Projectile.extraUpdates = 1;

            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
        }

        public override void AI() {
            for (int i = 0; i < 2; i++)
                Gore.NewGoreDirect(Projectile.GetSource_FromThis(), Projectile.Center + Main.rand.NextVector2Circular(25, 25), Main.rand.NextFloat(3.14f,6.28f).ToRotationVector2() * 7, Mod.Find<ModGore>("MagmiteGore").Type, Main.rand.NextFloat(0.4f, 0.8f));
        }

        public override bool PreDraw(ref Color lightColor) {
            return false;
        }
    }
}