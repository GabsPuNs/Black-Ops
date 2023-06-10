using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Content.Dusts;
using TerrariaOverhaul.Common.Camera;

namespace BlackOps.Content.Projectiles
{
	public class Type97Proj : ModProjectile
	{
        public override string Texture => "BlackOps/Content/Items/Weapons/Grenades/Type97";

		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Grenade);
            AIType = ProjectileID.Grenade;
			Projectile.width = 14;
			Projectile.height = 22;
			Projectile.timeLeft = 270;
		}

		public override void Kill(int timeLeft) {
			var screenShake = new ScreenShake(25f, 1f);
            SoundEngine.PlaySound(new SoundStyle("BlackOps/Assets/Sounds/Items/Grenades/Explosion/FragGrenadeExplosion", 2), Projectile.Center);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Explosion1>(), Projectile.damage, 0f, Projectile.owner);
			for (int i = 0; i < 5; i++)
			{
				Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Main.rand.NextFloat(6.28f).ToRotationVector2() * Main.rand.NextFloat(2, 3), ModContent.ProjectileType<Explosion2>(), Projectile.damage, 0f, Projectile.owner);
			}
			ScreenShakeSystem.New(screenShake, null);
			for (int i = 0; i < 10; i++)
			{
				Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<NeedlerDust>());
				dust.velocity = Main.rand.NextVector2Circular(10, 10);
				dust.scale = Main.rand.NextFloat(1.5f, 1.9f);
				dust.alpha = 70 + Main.rand.Next(60);
				dust.rotation = Main.rand.NextFloat(6.28f);
			}
			for (int i = 0; i < 10; i++)
			{
				Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(16, 16), 0, 0, ModContent.DustType<NeedlerDustTwo>());
				dust.velocity = Main.rand.NextVector2Circular(10, 10);
				dust.scale = Main.rand.NextFloat(1.5f, 1.9f);
				dust.alpha = Main.rand.Next(80) + 40;
				dust.rotation = Main.rand.NextFloat(6.28f);
			}
		}
	}
}