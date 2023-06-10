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

namespace BlackOps.Common.Guns.Overhauls.WonderWeapons;

public class Blundergat : ItemOverhaul
{
	public static readonly SoundStyle BlundergatFireSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/WonderWeapons/Blundergat") {
		Volume = 0.5f,
		PitchVariance = 0.2f
	};
	public static readonly SoundStyle BlundergatPumpSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/WonderWeapons/BlundergatReload") {
		Volume = 0.5f,
		PitchVariance = 0.2f
	};

	private uint pumpTime;

	public SoundStyle? PumpSound { get; set; }
	public int ShellCount { get; set; } = 1;

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/WonderWeapons/Blundergat");

	public override void SetDefaults(Item item)
	{
		item.UseSound = BlundergatFireSound;
		PumpSound = BlundergatPumpSound;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 30f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(1f, 0.2f);
			});

			item.EnableComponent<ItemBulletCasings>(c => {
				c.CasingGoreType = ModContent.GoreType<ShellCasing>();
				c.CasingCount = 4;
				c.SpawnOnUse = false;
			});
		}
	}

	public override bool? UseItem(Item item, Player player)
	{
		bool? baseResult = base.UseItem(item, player);

		if (baseResult == false) {
			return false;
		}

		pumpTime = (uint)(Main.GameUpdateCount + 1);

		return baseResult;
	}

	public override void HoldItem(Item item, Player player)
	{
		base.HoldItem(item, player);

		if (!Main.dedServ && PumpSound != null && pumpTime != 0 && Main.GameUpdateCount == pumpTime) {
			SoundEngine.PlaySound(PumpSound.Value, player.Center);

			item.GetGlobalItem<ItemBulletCasings>().SpawnCasings(item, player);
		}
	}
}