using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Dusts
{
	public class RayGunDust : ModDust
    {
        public override string Texture => "BlackOps/Content/Dusts/Smoke";
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.scale *= Main.rand.NextFloat(0.8f, 2f);
            dust.frame = new Rectangle(0, 0, 34, 36);
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            Color gray = new Color(25, 25, 25);
            Color ret;
            if (dust.alpha < 80)
            {
                ret = Color.Lerp(new Color(122, 255, 50), new Color(78, 144, 32), dust.alpha / 80f);
            }
            else if (dust.alpha < 120)
            {
                ret = Color.Lerp(new Color(78, 144, 32), gray, (dust.alpha - 80) / 80f);
            }
            else
                ret = gray;
            return ret * ((140 - dust.alpha) / 140f);
        }

        public override bool Update(Dust dust)
        {
            if (dust.velocity.Length() > 3)
                dust.velocity *= 0.85f;
            else
                dust.velocity *= 0.92f;
            if (dust.alpha > 100)
            {
                dust.scale += 0.01f;
                dust.alpha += 2;
            }
            else
            {
                Lighting.AddLight(dust.position, dust.color.ToVector3() * 0.1f);
                dust.scale *= 0.985f;
                dust.alpha += 4;
            }
            dust.position += dust.velocity;
            if (dust.alpha >= 140)
                dust.active = false;

            return false;
        }
    }

    public class RayGunDustTwo : ModDust
    {
        public override string Texture => "BlackOps/Content/Dusts/Smoke";

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.scale *= Main.rand.NextFloat(0.8f, 2f);
            dust.frame = new Rectangle(0, 0, 34, 36);
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            Color gray = new Color(25, 25, 25);
            Color ret;
            if (dust.alpha < 80)
            {
                ret = Color.Lerp(new Color(122, 255, 50), new Color(78, 144, 32), dust.alpha / 80f);
            }
            else if (dust.alpha < 120)
            {
                ret = Color.Lerp(new Color(78, 144, 32), gray, (dust.alpha - 80) / 80f);
            }
            else
                ret = gray;
            return ret * ((140 - dust.alpha) / 140f);
        }

        public override bool Update(Dust dust)
        {
            if (dust.velocity.Length() > 3)
                dust.velocity *= 0.85f;
            else
                dust.velocity *= 0.92f;

            if (dust.alpha > 100)
            {
                dust.scale *= 0.975f;
                dust.alpha += 2;
            }
            else
            {
                Lighting.AddLight(dust.position, dust.color.ToVector3() * 0.1f);
                dust.scale *= 0.985f;
                dust.alpha += 4;
            }
            dust.position += dust.velocity;

            if (dust.alpha >= 140)
                dust.active = false;

            return false;
        }
    }
}