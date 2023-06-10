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

public partial class AK103 : ItemOverhaul
{
	public static readonly SoundStyle AK103FireSound = new SoundStyle($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/AssaultRifles/AK103") {
		Volume = 0.8f,
		PitchVariance = 0.2f,
	};

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/AssaultRifles/AK103");

	public override void SetDefaults(Item item)
	{
		base.SetDefaults(item);

		item.UseSound = AK103FireSound;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();
			item.EnableComponent<ItemPlaySoundOnEveryUse>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 4f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(0.35f, 0.2f);
			});

			item.EnableComponent<ItemBulletCasings>(c => {
				c.CasingGoreType = ModContent.GoreType<BulletCasing>();
			});
		}
	}
}