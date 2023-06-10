using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace BlackOps;

[Autoload(Side = ModSide.Client)]
public sealed class BlackOpsMenu : ModMenu
{
	private Asset<Texture2D>? logoBlackOps;
	//private BlendState blendState;

	public override Asset<Texture2D>? Logo => logoBlackOps;

	public override int Music => MusicLoader.GetMusicSlot("BlackOps/Assets/Sounds/Music/DamnedOps");

	public override void Load()
	{
		logoBlackOps = Mod.Assets.Request<Texture2D>("Logo_BlackOps");
	}

	public override bool PreDrawLogo(SpriteBatch sb, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
	{
		if (logoBlackOps?.IsLoaded != true) {
			return false;
		}

		var textureSize = logoBlackOps.Value.Size();
		var textureCenter = textureSize * 0.5f;

		sb.Draw(logoBlackOps.Value, logoDrawCenter, null, drawColor, logoRotation, textureCenter, logoScale, SpriteEffects.None, 0f);
		
		return false;
	}
}