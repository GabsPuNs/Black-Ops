using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using BlackOps.Content.Projectiles;

namespace BlackOps.Content.Items.Weapons.Guns.Flamethrowers
{
	public class M2Flamethrower : ModItem
	{
		private int ammoTimer = 5;

		public override void SetDefaults() {

			Item.width = 66;
			Item.height = 20;
			Item.scale = 0.75f;
			Item.rare = 4;

			Item.useTime = 6;
			Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Flamethrowers/M2Flamethrower");

			Item.damage = 42;
			Item.DamageType = DamageClass.Ranged;
            Item.channel = true;
            Item.noMelee = true;
			Item.knockBack = 0.3f;

            Item.shoot = ModContent.ProjectileType<M2FlamethrowerProj>();
		}

		public override bool CanConsumeAmmo(Item ammo, Player player) {
			return Main.rand.NextFloat() >= 0.1f;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(7, 2);
		}
	}
}
