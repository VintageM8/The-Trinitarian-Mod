using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Items.Weapons.Ranged;
using Trinitarian.Items.Weapons.Melee;

namespace Trinitarian
{
    public class TrinitarianWorld : ModWorld
    {
        //bosses
         public static bool downedViking;

        public override void PostWorldGen()
        {
            int[] itemsToPlaceInChests = { ModContent.ItemType<Uranium>() };
            int itemsToPlaceInChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        {
                            if (Main.rand.NextFloat() < .25f)
                            {
                                if (chest.item[inventoryIndex].type == ItemID.None)
                                {
                                    chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[itemsToPlaceInChestsChoice]);
                                    itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests.Length;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            int[] itemsToPlaceInIceChests = { ModContent.ItemType<FrostyMinigun>(), ModContent.ItemType<IceSpear>(), ItemID.PinkJellyfishJar };
			int itemsToPlaceInIceChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) 
			{	Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36) 
				{	for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) 
					{	if (chest.item[inventoryIndex].type == ItemID.None) 
						{	chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
							itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
                        }
                    }
                }
            }
        }
    }
}                        