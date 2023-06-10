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

namespace BlackOps.Common.Guns.Overhauls.Shotguns;

public class Olympa : ItemOverhaul
{
	public static readonly SoundStyle OlympaFireSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/Shotguns/Olympa") {
		Volume = 0.5f,
		PitchVariance = 0.2f
	};

	public int ShellCount { get; set; } = 1;

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Shotguns/Olympa");

	public override void SetDefaults(Item item)
	{
		item.UseSound = OlympaFireSound;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 25f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(0.8f, 0.2f);
			});

			item.EnableComponent<ItemBulletCasings>(c => {
				c.CasingGoreType = ModContent.GoreType<ShellCasing>();
				c.CasingCount = 2;
			});
		}
	}
}