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

namespace BlackOps.Common.Guns.Overhauls.Handguns;

public class DesertEagle : ItemOverhaul
{
	public static readonly SoundStyle DesertEagleFireSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/Handguns/DesertEagle") {
		Volume = 0.8f,
		PitchVariance = 0.2f,
	};

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Handguns/DesertEagle");

	public override void SetDefaults(Item item)
	{
		base.SetDefaults(item);

		item.UseSound = DesertEagleFireSound;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();
			item.EnableComponent<ItemPlaySoundOnEveryUse>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 12f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(0.55f, 0.15f);
			});

			item.EnableComponent<ItemBulletCasings>(c => {
				c.CasingGoreType = ModContent.GoreType<BulletCasing>();
			});
		}
	}
}