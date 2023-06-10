using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Common.PlayerLayers;
using static Terraria.ModLoader.ModContent;

namespace BlackOps.Content.Items.Weapons.Melee
{
	public class Tomahawk : ModItem
	{
        public override string Texture => "BlackOps/Content/Items/Weapons/Melee/Tomahawk";

		public override void SetDefaults() {

			Item.width = 22;
			Item.height = 28;
			Item.rare = 4;
			Item.scale = 0.75f;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Melee/Knife1");
			Item.useTime = 18;
			Item.useAnimation = 18;

			Item.damage = 200;
			Item.DamageType = DamageClass.Melee;
			Item.knockBack = 3f;
			Item.crit = 3;
		}
	}
}
