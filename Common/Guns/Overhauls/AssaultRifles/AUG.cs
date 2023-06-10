using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaOverhaul.Common.Camera;
using TerrariaOverhaul.Common.Crosshairs;
using TerrariaOverhaul.Common.Items;
using TerrariaOverhaul.Common.Guns;
using TerrariaOverhaul.Common.Recoil;
using TerrariaOverhaul.Core.ItemComponents;
using TerrariaOverhaul.Core.ItemOverhauls;
using BlackOps.Content.Gores;

namespace BlackOps.Common.Guns.Overhauls.AssaultRifles;

public class AUG : ItemOverhaul
{
	public static readonly SoundStyle AUGFireSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/AssaultRifles/AUG") {
		Volume = 1f,
		PitchVariance = 0.2f,
	};

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/AssaultRifles/AUG");

	public override void SetDefaults(Item item)
	{
		base.SetDefaults(item);

		item.UseSound = AUGFireSound;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();
			item.EnableComponent<ItemPlaySoundOnEveryUse>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 7f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(0.45f, 0.2f);
			});

			item.EnableComponent<ItemBulletCasings>(c => {
				c.CasingGoreType = ModContent.GoreType<BulletCasing>();
			});
		}
	}
}