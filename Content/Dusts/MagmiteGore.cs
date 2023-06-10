using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BlackOps.Content.Dusts
{
    internal class MagmiteGore : ModGore
    {
        public override void OnSpawn(Gore gore, IEntitySource source)
        {
            gore.timeLeft = 180;
            gore.sticky = true;
            gore.numFrames = 2;
            gore.behindTiles = true;
        }

        public override Color? GetAlpha(Gore gore, Color lightColor) => Color.White * (gore.scale < 0.5f ? gore.scale * 2 : 1);

        public override bool Update(Gore gore)
        {
            Lighting.AddLight(gore.position, new Vector3(1.6f, 0.8f, 0) * gore.scale);

            gore.scale *= 0.99f;

            if (gore.scale < 0.1f)
                gore.active = false;

            if (gore.velocity.Y == 0)
            {
                gore.velocity.X = 0;
                gore.rotation = 0;
                gore.frame = 1;
            }

            //gore.position += gore.velocity;

            if (gore.frame == 0) gore.velocity.Y += 0.5f;

            return true;
        }
    }
}