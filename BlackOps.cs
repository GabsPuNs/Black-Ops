using Terraria;
using Terraria.ModLoader;

namespace BlackOps
{
	public class BlackOps : Mod
	{
		public static BlackOps instance;

		public BlackOps()
		{
			ContentAutoloadingEnabled = true;
			GoreAutoloadingEnabled = true;
			MusicAutoloadingEnabled = true;
		}

		public override void Unload()
		{
			instance = null;
		}

		public override void Load()
		{
			instance = this;
		}
	}
}