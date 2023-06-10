using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using TerrariaOverhaul.Common.Camera;
using TerrariaOverhaul.Common.Crosshairs;
using TerrariaOverhaul.Common.Items;
using TerrariaOverhaul.Common.Guns;
using TerrariaOverhaul.Common.Recoil;
using TerrariaOverhaul.Core.ItemComponents;
using TerrariaOverhaul.Core.ItemOverhauls;

namespace BlackOps.Common.Guns.Overhauls.Flamethrowers;

public class M2Flamethrower : ItemOverhaul
{
	public static readonly SoundStyle FireSound = new($"{nameof(BlackOps)}/Assets/Sounds/Items/Guns/Flamethrowers/M2Flamethrower") {
		IsLooped = true,
		Volume = 0.4f,
		PitchVariance = 0.2f,
	};

	private SlotId soundId;

	public override bool ShouldApplyItemOverhaul(Item item)
		=> item.UseSound == new SoundStyle("BlackOps/Assets/Sounds/Items/Guns/Flamethrowers/M2Flamethrower");

	public override void SetDefaults(Item item)
	{
		base.SetDefaults(item);

		item.UseSound = null;

		if (!Main.dedServ) {
			item.EnableComponent<ItemAimRecoil>();
			item.EnableComponent<ItemCrosshairController>();

			item.EnableComponent<ItemUseVisualRecoil>(c => {
				c.Power = 4f;
			});

			item.EnableComponent<ItemUseScreenShake>(c => {
				c.ScreenShake = new ScreenShake(0.2f, 0.2f);
			});
		}
	}

	public override bool? UseItem(Item item, Player player)
	{
		if (!soundId.IsValid || !SoundEngine.TryGetActiveSound(soundId, out _)) {
			soundId = SoundEngine.PlaySound(FireSound, player.Center);
		}

		return base.UseItem(item, player);
	}

	public override void HoldItem(Item item, Player player)
	{
		base.HoldItem(item, player);

		if (SoundEngine.TryGetActiveSound(soundId, out var activeSound)) {
			if (!player.ItemAnimationActive && player.itemTime <= 0) {
				activeSound.Stop();

				soundId = SlotId.Invalid;
			} else {
				activeSound.Position = player.Center;
			}
		}
	}
}