using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Trinitarian.Tiles
{
	public class Algae : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			//Main.tileMergeDirt[Type] = true;ee
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileSolid[Type] = false;
			drop = ModContent.ItemType<Items.Materials.Parts.Algae>	();

			AddMapEntry(new Color(200, 200, 200));
			
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

    }
}
