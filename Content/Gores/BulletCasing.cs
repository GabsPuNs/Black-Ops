using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using TerrariaOverhaul.Common.BloodAndGore;

namespace BlackOps.Content.Gores;

public class BulletCasing : ModGore
{
	public static readonly SoundStyle BounceSound = new($"{nameof(BlackOps)}/Assets/Sounds/HitEffects/9mm/9mm", 11) {
		Volume = 1f,
		PitchVariance = 0.2f,
	};

	public override void SetStaticDefaults()
	{
		ChildSafety.SafeGore[Type] = true;
	}

	public override void OnSpawn(Gore gore, IEntitySource source)
	{
		gore.Frame = new SpriteFrame(1, 1, 0, 0);
		gore.sticky = false;
		gore.light = 0f;
		gore.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
		gore.scale = 0.7f;
	}

	public override bool Update(Gore gore)
	{
		if (gore is OverhaulGore goreExt) {
			goreExt.CustomBounceSound = BounceSound;
		}

		return base.Update(gore);
	}
}
