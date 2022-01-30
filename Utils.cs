using System;
using Terraria;
using Terraria.ID;

namespace Trinitarian
{

	public static class Utilty
	{
		public static int AddItem(this Chest c, int ItemType, int stack = 1, bool overrideFirst = false)
		{
			for(int i = 0; i < c.item.Length; i++)
            {
				if(c.item[i].type == ItemID.None)
                {
					Item t = new Item();
					t.SetDefaults(ItemType);
					c.item[i] = t;
					c.item[i].stack = stack;
					return i;
                }	
            }
            if (overrideFirst)
            {
				Item t = new Item();
				t.SetDefaults(ItemType);
				c.item[0] = t;
				return 0;
            }
			return -1;
		}
	/*	WIP
	 *	public static void PlaceFrameImportatn(int Type,int i, int j)
        {
			Tile t = new Tile();
			t.type = (ushort)Type;
			
        }*/
	}

}
