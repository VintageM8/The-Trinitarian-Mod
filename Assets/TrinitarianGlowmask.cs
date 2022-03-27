using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Assets
{
	public class TrinitarianGlowmask : ModPlayer
	{
		private static readonly Dictionary<int, Texture2D> ItemGlowMask = new Dictionary<int, Texture2D>();

		internal static void Unload()
		{
			ItemGlowMask.Clear();
		}

		public static void AddGlowMask(int itemType, string texturePath)
		{
			ItemGlowMask[itemType] = ModContent.GetTexture(texturePath);
		}

		public override void ModifyDrawLayers(List<PlayerLayer> layers)
		{
			
			Texture2D textureItem;
			if (player.HeldItem.type >= ItemID.Count && ItemGlowMask.TryGetValue(player.HeldItem.type, out textureItem))//Held ItemType
			{
				InsertAfterVanillaLayer(layers, "HeldItem", new PlayerLayer(mod.Name, "GlowMaskHeldItem", delegate (PlayerDrawInfo info) {
					GlowmaskUtils.DrawItemGlowMask(textureItem, info);
				}));
			}
		}

		public static void InsertAfterVanillaLayer(List<PlayerLayer> layers, string vanillaLayerName, PlayerLayer newPlayerLayer)
		{
			for (int i = 0; i < layers.Count; i++)
			{
				if (layers[i].Name == vanillaLayerName && layers[i].mod == "Terraria")
				{
					layers.Insert(i + 1, newPlayerLayer);
					return;
				}
			}
			layers.Add(newPlayerLayer);
		}
	}
}