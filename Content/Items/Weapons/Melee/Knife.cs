using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace BlackOps.Content.Items.Weapons.Melee
{
	public class Knife : ModItem
	{
		public override void SetDefaults() {

			Item.width = 22;
			Item.height = 28;
			Item.rare = 4;
			Item.scale = 0.75f;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Melee/Knife1");
			Item.useTime = 18;
			Item.useAnimation = 18;

			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.knockBack = 3f;
			Item.crit = 3;
		}
	}
}
