using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Enums;
using System;

namespace BlackOps.Content.Projectiles
{
    public class M2FlamethrowerProj : ModProjectile
    {
        public override string Texture => "BlackOps/Content/Projectiles/M2Flamethrower";

        private Player Player => Main.player[Projectile.owner];

        private Vector2 direction = Vector2.Zero;

        private float scaleCounter = 0f;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            Projectile.hostile = false;
            Projectile.width = 114;
            Projectile.height = 36;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 999999;
            Projectile.ownerHitCheck = true;
        }

        public override void AI()
        {
            if (Projectile.wet)
            {
                Projectile.Kill(); //This kills the projectile when touching water. However, since our projectile is a cursed flame, we will comment this so that it won't run it. If you want to test this, feel free to uncomment this.
            }

            float spread = 0.4f;

            Vector2 offset = new Vector2(1f, -0.02f * Player.direction).RotatedBy(Projectile.rotation);
            Vector2 offset2 = new Vector2(0.15f, 0.05f * Player.direction).RotatedBy(Projectile.rotation);
            Vector2 offset3 = new Vector2(1.2f, 0f * Player.direction).RotatedBy(Projectile.rotation);

            if (scaleCounter < 1)
                scaleCounter += 0.1f;
            Projectile.scale = scaleCounter;

            Projectile.velocity = Vector2.Zero;
            if (Player.channel)
            {
                Projectile.timeLeft = 2;
                Player.itemTime = Player.itemAnimation = 2;

                direction = Player.DirectionTo(Main.MouseWorld);
                direction.Normalize();
                Player.ChangeDir(Math.Sign(direction.X));

                Player.itemRotation = direction.ToRotation();

                if (Player.direction != 1)
                    Player.itemRotation -= 3.14f;

                Player.itemRotation = MathHelper.WrapAngle(Player.itemRotation);
            }
            Projectile.rotation = direction.ToRotation();
            Projectile.Center = Player.Center + new Vector2(0, Player.gfxOffY) + new Vector2(45, -4 * Player.direction).RotatedBy(Projectile.rotation);

            for (int k = 0; k < 15; k++)
            {
                var direction = offset.RotatedByRandom(spread);

                Dust.NewDustPerfect(Projectile.Center + (offset2 * 70), ModContent.DustType<Dusts.Glow>(), direction * Main.rand.NextFloat(8), 125, new Color(150, 80, 40), Main.rand.NextFloat(0.2f, 0.5f));
            }

            Dust.NewDustPerfect(Projectile.Center + offset3 * 70, ModContent.DustType<Dusts.Smoke2>(), Vector2.UnitY * -2 + offset.RotatedByRandom(spread) * 5, 0, new Color(60, 55, 50) * 0.5f, Main.rand.NextFloat(0.5f, 1));

            for (int i = 0; i < Projectile.width * Projectile.scale; i++)
                Lighting.AddLight(Projectile.Center + (direction * i), Color.Red.ToVector3() * 0.6f);

            Projectile.frameCounter++;
            if (Projectile.frameCounter % 2 == 0)
                Projectile.frame++;
            Projectile.frame %= Main.projFrames[Projectile.type];
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 240);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.OnFire, 240, false);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;

            int frameHeight = tex.Height / Main.projFrames[Projectile.type];
            Rectangle frame = new Rectangle(0, frameHeight * Projectile.frame, tex.Width, frameHeight);


            SpriteEffects effects = Player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically;
            Texture2D bloomTex = ModContent.Request<Texture2D>(Texture + "_Glow").Value;
            Color bloomColor = Color.White;
            bloomColor.A = 0;
            Main.EntitySpriteDraw(bloomTex, Projectile.Center - Main.screenPosition, frame, bloomColor, Projectile.rotation, new Vector2(0, tex.Height / (2 * Main.projFrames[Projectile.type])), Projectile.scale, effects, 0);

            Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, frame, Color.White, Projectile.rotation, new Vector2(0, tex.Height / (2 * Main.projFrames[Projectile.type])), Projectile.scale, effects, 0);

            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + (direction * Projectile.width * Projectile.scale), Projectile.height * Projectile.scale, ref collisionPoint);
        }

        public override bool? CanCutTiles()
        {
            return true;
        }
        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Utils.PlotTileLine(Projectile.Center, Projectile.Center + (direction * Projectile.width * Projectile.scale), Projectile.height * Projectile.scale, DelegateMethods.CutTiles);
        }
    }
}