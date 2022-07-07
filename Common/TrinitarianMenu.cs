using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trinitarian.Common
{
	public class TrinitarianMenu : ModMenu
	{
		public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("Trinitarian/logo");

		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/MenuTheme");


		public override string DisplayName => "Trinitarian Mod Menu";

		public override void OnSelected()
		{
			SoundEngine.PlaySound(SoundID.AbigailSummon); // Plays a thunder sound when this ModMenu is selected
		}
	}
}