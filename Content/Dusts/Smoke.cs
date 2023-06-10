﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace BlackOps.Content.Dusts
{
    public class Smoke : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.scale *= Main.rand.NextFloat(0.1f, 0.6f);
            dust.frame = new Rectangle(0, 0, 34, 36);
            dust.rotation = Main.rand.NextFloat(6.28f);
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return dust.color;
        }

        public override bool Update(Dust dust)
        {
            dust.velocity *= 0.98f;
            dust.velocity.X *= 0.95f;
            dust.color *= 0.98f;

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
            dust.rotation += 0.04f;

            if (dust.alpha >= 255)
                dust.active = false;

            return false;
        }
    }

    public class Smoke2 : Smoke
    {
        public override string Texture => "BlackOps/Content/Dusts/Smoke";

        public override void OnSpawn(Dust dust)
        {
            dust.scale *= Main.rand.NextFloat(3.2f, 4.6f);
        }
    }
}
