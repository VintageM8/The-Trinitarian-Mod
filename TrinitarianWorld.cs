using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Weapons.Melee;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Trinitarian.Items.Materials.RadiatedSubclass;
using System.Collections.Generic;
using Trinitarian.Items.Weapons.Ranged;
using Trinitarian.Tiles;
using static Terraria.ModLoader.ModContent;


namespace Trinitarian
{
    public class TrinitarianWorld : ModWorld
    {
        //bosses

         public static bool downedViking;
        public override void PostUpdate()
        {
            // Complex math copied from source code. It's weirdly specific, but whatever, it works.

            int Shouldplant = (int)MathHelper.Lerp(151, (float)151 * 2.8f, MathHelper.Clamp((float)Main.maxTilesX / 4200f - 1f, 0f, 1f));
            // Value from 151.2 to 604.8 also representing world size.
            float numTilesToUpdate = (float)(Main.maxTilesX * Main.maxTilesY) * 3E-05f * (float)Main.worldRate; // worldRate defaults to 1.
            for (int i = 0; (float)i < numTilesToUpdate; i+=2)
            {
                // Very low chance
                if (Main.rand.Next(700) == 0 && Main.rand.Next(Shouldplant) == 0)//change this number to increase/decreasethe growing rate
                {
                    Generate2Algea();
                }
            }
        }
        /*public void WolrdMakeAlg()
        {


            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 1E-06); k++)
            {
                Generate2Algea();
            }
        }*/
        
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

               // WolrdMakeAlg();
            

            int[] itemsToPlaceInIceChests = { ModContent.ItemType<FrostyMinigun>(), ModContent.ItemType<IceSpear>(), ItemID.PinkJellyfishJar };
			int itemsToPlaceInIceChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) 
			{	Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36) 
				{	for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) 
					{	if (chest.item[inventoryIndex].type == ItemID.None) 
						{	
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
							itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
                        }
                    }
                }
            }
           
    }
        private void Generate2Algea()
        {
            int attempts = 0;
            int Placer = ModContent.TileType<Tiles.Algea>();
            Tile tile;
            Tile tileL;
            Tile tileR;
            Tile tileBelow;
            bool placeSuccessful = false;
            while (!placeSuccessful)
            {
                attempts++;
                // Pick a location.
                int x = WorldGen.genRand.Next(20, Main.maxTilesX/10 - 1);
                int y = WorldGen.genRand.Next(20, Main.maxTilesY);
                tile = Main.tile[x, y];
                tileL = Main.tile[x - 1, y];
                tileR = Main.tile[x - 1, y];
                tileBelow = Main.tile[x, y + 1];
                if ((tileBelow.type == TileID.Sand || tileBelow.type == ModContent.TileType<Tiles.Algea>() || tileR.type == ModContent.TileType<Tiles.Algea>() ||tileL.type == ModContent.TileType<Tiles.Algea>()) && tile.liquid > 0  && !tile.active())
                {
                    WorldGen.PlaceTile(x, y, Placer, true);
                    //Player nlayer = Main.player[Main.myPlayer];
                    //nlayer.Center = new Vector2(x*16, y *16);
                    placeSuccessful = tile.active() && tile.type == Placer;
                }
                if (attempts >= 30000)
                {
                    
                    placeSuccessful = true;
                }
            }
            placeSuccessful = false;
            while (!placeSuccessful)
            {
                attempts++;
                // Pick a location.
                int x = WorldGen.genRand.Next(Main.maxTilesX/10 * 9, Main.maxTilesX);
                int y = WorldGen.genRand.Next(20, Main.maxTilesY);
                tile = Main.tile[x, y];
                tileL = Main.tile[x - 1, y];
                tileR = Main.tile[x - 1, y];
                tileBelow = Main.tile[x, y + 1];
                if ((tileBelow.type == TileID.Sand || tileBelow.type == ModContent.TileType<Tiles.Algea>() || tileR.type == ModContent.TileType<Tiles.Algea>() || tileL.type == ModContent.TileType<Tiles.Algea>()) && tile.liquid > 0  && !tile.active())
                {
                    WorldGen.PlaceTile(x, y, Placer, true);
                    //Player nlayer = Main.player[Main.myPlayer];Testing
                    //nlayer.Center = new Vector2(x * 16, y * 16);
                    placeSuccessful = tile.active() && tile.type == Placer;
                }
                if (attempts >= 30000)
                {
                    
                    return;
                }
            }

        }
       
/* public static bool JustPressed(Keys key)
        {
            return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
        }
        public override void PostUpdate()
        {
            if (JustPressed(Keys.LeftControl))
            {
               // for(int i = 0; i < 50; i++) { Generate2Algea(); }
            }
                
        }*///TESTING STUFF you can uncomment and Add your own methods to test by hitting left control
    }
}                        

