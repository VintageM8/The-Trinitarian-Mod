using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Weapons.Melee.PreHardmode;
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
         public static bool downedIceBoss;
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
       

               // WolrdMakeAlg();
            
           
    
        private void Generate2Algea()
        {
            int attempts = 0;
            int Placer = ModContent.TileType<Tiles.Algae>();
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
                tile = Framing.GetTileSafely(x, y);
                tileL = Framing.GetTileSafely(x - 1, y);
                tileR = Framing.GetTileSafely(x +1, y);
                tileBelow = Framing.GetTileSafely(x, y + 1);
                if ((tileBelow.type == TileID.Sand || tileBelow.type == ModContent.TileType<Tiles.Algae>() || tileR.type == ModContent.TileType<Tiles.Algae>() ||tileL.type == ModContent.TileType<Tiles.Algae>()) && tile.liquid > 0  && !tile.active())
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
                tile = Framing.GetTileSafely(x, y);
                tileL = Framing.GetTileSafely(x - 1, y);
                tileR = Framing.GetTileSafely(x + 1, y);
                tileBelow = Framing.GetTileSafely(x, y + 1);
                if ((tileBelow.type == TileID.Sand || tileBelow.type == ModContent.TileType<Tiles.Algae>() || tileR.type == ModContent.TileType<Tiles.Algae>() || tileL.type == ModContent.TileType<Tiles.Algae>()) && tile.liquid > 0  && !tile.active())
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
       
    }
}                        

