using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Items.Materials.Parts;
using System.Collections.Generic;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged;
using Trinitarian.Content.Tiles;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using System.Linq;
using Terraria.ModLoader.IO;
//using Trinitarian.Races;
using System.IO;
using Terraria.WorldBuilding;
using System;
using Terraria.GameContent.Generation;
using Terraria.IO;

namespace Trinitarian.Common
{
    public class TrinitarianWorld : ModSystem
    {
        //bosses
        public static bool downedViking;
        public static bool downedIceBoss;
        public static bool downedOceanGhost;

        







        
        public override void PostWorldGen()
        {

            // Complex math copied from source code. It's weirdly specific, but whatever, it works.
            int Shouldplant = (int)MathHelper.Lerp(151, (float)151 * 2.8f, MathHelper.Clamp((float)Main.maxTilesX / 4200f - 1f, 0f, 1f));
            // Value from 151.2 to 604.8 also representing world size.
            float numTilesToUpdate = (float)(Main.maxTilesX * Main.maxTilesY) * 3E-05f * (float)Main.desiredWorldTilesUpdateRate; // desiredWorldTilesUpdateRate defaults to 1.
            for (int i = 0; (float)i < numTilesToUpdate; i += 2)
            {
                // Very low chance
                if (Main.rand.Next(1200) == 0 && Main.rand.Next(Shouldplant) == 0)//change this number to increase/decreasethe growing rate
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

        
        #region Arrays of doom
        //all made with the log arrays methods, dont worry
        private readonly int[,] ShipSlope = {
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,},
{ 1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
};
      private readonly int[,] ShipWalls =
        {
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,},
{0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,}
        };
       
        private readonly int[,] ShipShape =
         {  
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,0,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,4,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,4,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},//14 e 17
 { 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,1,1,1,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0},
{ 1,1,0,0,0,0,0,2,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0 },
{ 1,1,0,0,0,0,0,1,1,3,3,3,1,1,1,0,0,0,0,0,0,0,0 },
{ 1,1,1,3,3,3,1,1,1,3,3,3,1,1,0,0,0,0,0,0,0,0,0},
{ 1,1,1,3,3,3,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
        #endregion
        public void CreateIceCastle(GenerationProgress progress, GameConfiguration g)
        {
            progress.Message = "Creating Ice Castle (Trinitarian)";
            Point Location = FindIceLocation();
            int[] Chests = StructureLoader.ReadStruct(Location, "Assets/Structures/IceCastle");
            foreach(int i in Chests)
            {
                //add with this
                //Main.chest[i].AddItem(type,stack);
                //this will only run once since theirs 1 chest
            }
        }
        int attempts = 0;
        const int MaxAttempts = 500000;
        private Point FindIceLocation()
        {
            attempts++;
            Point p = new Point();
            p.X = Main.rand.Next(0,Main.maxTilesX);
            p.Y = Main.rand.Next((int)WorldGen.rockLayerLow, (int)WorldGen.rockLayerHigh);
            bool VaildLoc = false;
            Tile t = Framing.GetTileSafely(p);
            if(t.TileType == TileID.IceBlock ||t.TileType == TileID.SnowBlock)
            {
                VaildLoc = true;
            }
            if (VaildLoc)
            {
                return p;
            }
            else if( attempts > MaxAttempts)
            {
                Mod.Logger.Warn("cannot find a snow index");
                throw new Exception($"cannot find snow with {MaxAttempts} attempts");
            }
            else
            {
                return FindIceLocation();
            }
        }

        private void MakeShipWreck(GenerationProgress progress, GameConfiguration g)
        {
            progress.Message = "Making Ship (Trinitarian)";
           int i = 50;
           int j = (int)Main.worldSurface - 50;
             Tile WF = Framing.GetTileSafely(i, j);
            while (WF.HasTile || WF.LiquidAmount > 5)
            {
                if (j < 10)
                {
                    Mod.Logger.Error("Error Making ship, cannot find a vaild y. \n please report this error to our discord if you see it -- Trinitarian Devs");
                    break;
                }
                j--;
                WF = Framing.GetTileSafely(i, j);
            }
            j -= 15;
            for (int x = 0; x < ShipShape.GetLength(0); x++)
            {
                for (int y = 0; y < ShipShape.GetLength(1); y++)
                {

                    {

                        switch (ShipShape[x, y])
                        {
                            case 0:
                                WorldGen.KillTile(i + x, j + y);
                                break;
                            case 1:
                                WorldGen.PlaceTile(i + x, j + y, TileID.WoodBlock, true, true);
                                //(i + x, j + y)
                                break;
                            case 2:
                                WorldGen.PlaceTile(i + x, j + y, TileID.Platforms, true, true);
                                break;
                            case 3:
                                WorldGen.PlaceTile(i + x, j + y, TileID.Glass, true, true);
                                break;
                            case 4:
                                WorldGen.PlaceTile(i + x, j + y, TileID.Torches, true, true);
                                break;

                        }
                        switch (ShipWalls[x, y])
                        {
                            case 1:
                                Tile t = Framing.GetTileSafely(i + x, j + y);
                                t.LiquidAmount = 0;
                                WorldGen.PlaceWall(i + x, j + y, WallID.Wood, false);
                                break;


                        }
                        Framing.GetTileSafely(i + x, j + y).Slope = ((SlopeType)(byte)ShipSlope[x, y]);
                    }
                }
            }
            //5, 14, 17
            int GoldCapChest = WorldGen.PlaceChest(i + Main.rand.Next(43,48), j + 6, 21, false, 1);
            int[] ChestItems =
            {
                ItemID.WaterWalkingBoots, ItemID.TsunamiInABottle , ItemID.CratePotion, ItemID.SonarPotion, ItemID.JourneymanBait
            };
            int Added = 0;
            Chest chest = Main.chest[GoldCapChest];
            foreach(int t in ChestItems)
            {
                Main.chest[GoldCapChest].AddItem(t, Main.rand.Next(1, 5));
            }
           
           
            MakeCrate(i, j);
        }
        
        /// <summary>
        /// Really scuffed rn, dont use outside of the place its hard coded for
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void MakeCrate(int i, int j)
        {
            for (int it = 0; it < 20; it++)
            {

                WorldGen.Place2x2(i + it, j + 14, TileID.FishingCrate, 0);
            }
            for (int it = 1; it < 20; it += 2)
            {

                WorldGen.Place2x2(i + it, j + 12, TileID.FishingCrate, 0);
            }
            for (int it = 2; it < 20; it += 2)
            {

                WorldGen.Place2x2(i + it, j + 10, TileID.FishingCrate, 0);
            }

            WorldGen.Place3x2(i + 28, j + 14, TileID.Tables,16);
            WorldGen.PlaceChest(i + 25, j + 14, 21, false, 5);
            WorldGen.PlaceChest(i + 29, j + 14, 21, false, 5);
            int CurrentR = 12;
            for(int c = 0; c < Main.rand.Next(2, 4); c++)
            {
                CurrentR += Main.rand.Next(5, 10);
                WorldGen.Place2x2Horizontal(i + CurrentR, j + 17, TileID.FishingCrate, Main.rand.NextBool(5) ? 2 :1);
            }
        }
        private void GenRoom(int x, int y, int w, int h, int type = TileID.WoodBlock, int wall = WallID.Wood, bool door = false, bool left = false)
    {
        Point point = new Point(x, y);
        WorldUtils.Gen(point, new Shapes.Rectangle(w, h), Actions.Chain(new GenAction[]{
             new Actions.SetTile((ushort)type),
            }));
        // new Actions.PlaceWall(WallID.Wood),
        WorldUtils.Gen(new Point(point.X + 1, point.Y + 1), new Shapes.Rectangle(w - 2, h - 2), Actions.Chain(new GenAction[]{
             new Actions.ClearTile(),
             new Actions.PlaceWall((byte)wall),
            }));
        if (door)
        {
            //WorldGen.KillTile(x,)
            WorldGen.PlaceDoor(x, y + h - 3, TileID.ClosedDoor);
        }
    }
        #region Log Array Tools
        //all impressivly HardCoded
        //for testing
        Dictionary<int, int> TileToID = new Dictionary<int, int>();
    private void LogArray()
    {
        int Tr = 0;
        String s = "The Below was used for help making 2d arrays for world gen, IF YOU SEE THIS IN YOUR LOG AND YOUR NOT A DEV(hi vintage) please report it on our homepage or server\n {";
        int x = 54;
        int y = 22;
        Vector2 m = Main.MouseWorld / 16f;
            for (int i = (int)(m.X); i < m.X + x; i++)
            {
                for (int j = (int)m.Y; j < m.Y + y; j++)
                {
                    int Ttype;
                    Tile t = Framing.GetTileSafely(i, j);
                    if (TileToID.TryGetValue(t.TileType, out Ttype))
                    {
                        s += Ttype;
                    }
                    else
                    {
                        TileToID.Add(t.TileType, Tr++);
                        s += Tr;
                    }
                    s += ",";
                }
                s += "\n}" ;
        }
        Mod.Logger.Info(s);
    }

        private void LogSlopes()
        {
            int Tr = 0;
            String s = "The Below was used for help making 2d arrays f  or world gen, IF YOU SEE THIS IN YOUR LOG AND YOUR NOT A DEV(hi vintage) please report it on our homepage or server\n {";
            int x = 54;
            int y = 22;
            Vector2 m = Main.MouseWorld / 16f;
            for (int i = (int)(m.X); i < m.X + x; i++)
            {
                for (int j = (int)m.Y; j < m.Y + y; j++)
                {
                    Tile t = Framing.GetTileSafely(i, j);
                    s += t.Slope;
                    s += ",";
                }
                s += "}\n{";
            }
            Mod.Logger.Info(s);
        }
        private void LogArrayWalls()
        {
            int Tr = 0;
            String s = "The Below was used for help making 2d arrays f  or world gen, IF YOU SEE THIS IN YOUR LOG AND YOUR NOT A DEV(hi vintage) please report it on our homepage or server\n {";
            int x = 54;
            int y = 22;
            Vector2 m = Main.MouseWorld / 16f;
            for (int i = (int)(m.X); i < m.X + x; i++)
            {
                for (int j = (int)m.Y; j < m.Y + y; j++)
                {
                    Tile t = Framing.GetTileSafely(i, j);
                    if (TileToID.TryGetValue(t.WallType, out int Ttype))
                    {
                        s += Ttype;
                    }
                    else
                    {
                        TileToID.Add(t.WallType, Tr++);
                        s += Tr;
                    }
                    s += ",";
                }
                s += "}\n{";
            }
            Mod.Logger.Info(s);
        }
        #endregion

   
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int CleanupIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            tasks.Insert(CleanupIndex, new PassLegacy("IceCastle", CreateIceCastle));
            tasks.Add(new PassLegacy("Tri Ship", MakeShipWreck));
        }
        
        private void Generate2Algea()
    {
        int attempts = 0;
        int Placer = ModContent.TileType<AlgaePlant>();
        Tile tile;
        Tile tileL;
        Tile tileR;
        Tile tileBelow;
        bool placeSuccessful = false;
        while (!placeSuccessful)
        {
            attempts++;
            // Pick a location.
            int x = WorldGen.genRand.Next(20, Main.maxTilesX / 10 - 1);
            int y = WorldGen.genRand.Next(20, Main.maxTilesY);
            tile = Framing.GetTileSafely(x, y);
            tileL = Framing.GetTileSafely(x - 1, y);
            tileR = Framing.GetTileSafely(x + 1, y);
            tileBelow = Framing.GetTileSafely(x, y + 1);
            if ((tileBelow.TileType == TileID.Sand || tileBelow.TileType == ModContent.TileType<AlgaePlant>() || tileR.TileType == ModContent.TileType<AlgaePlant>() || tileL.TileType == ModContent.TileType<AlgaePlant>()) && tile.LiquidAmount > 0 && !tile.HasTile)
            {
                WorldGen.PlaceTile(x, y, Placer, true);
                //Player nlayer = Main.player[Main.myPlayer];
                //nlayer.Center = new Vector2(x*16, y *16);
                placeSuccessful = tile.HasTile && tile.TileType == Placer;
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
            int x = WorldGen.genRand.Next(Main.maxTilesX / 10 * 9, Main.maxTilesX);
            int y = WorldGen.genRand.Next(20, Main.maxTilesY);
            tile = Framing.GetTileSafely(x, y);
            tileL = Framing.GetTileSafely(x - 1, y);
            tileR = Framing.GetTileSafely(x + 1, y);
            tileBelow = Framing.GetTileSafely(x, y + 1);
            if ((tileBelow.TileType == TileID.Sand || tileBelow.TileType == ModContent.TileType<AlgaePlant>() || tileR.TileType == ModContent.TileType<AlgaePlant>() || tileL.TileType == ModContent.TileType<AlgaePlant>()) && tile.LiquidAmount > 0 && !tile.HasTile)
            {
                WorldGen.PlaceTile(x, y, Placer, true);
                //Player nlayer = Main.player[Main.myPlayer];Testing
                //nlayer.Center = new Vector2(x * 16, y * 16);
                placeSuccessful = tile.HasTile && tile.TileType == Placer;
            }
            if (attempts >= 30000)
            {

                return;
            }
        }


    }

        internal static bool ActiveAndSolid(int x, int y)
        {
            return Framing.GetTileSafely(x, y).HasTile && Main.tileSolid[Main.tile[x, y].TileType] && !Main.tileCut[Main.tile[x, y].TileType];
        }

        internal static bool check2x2(int x, int y)
        {
            return 
                   ActiveAndSolid(x, y + 1) &&
                   ActiveAndSolid(x + 1, y + 1);
        }

        internal static bool check2x2_Liquid(int x, int y)
        {
            return 
                   ActiveAndSolid(x, y + 1) &&
                   ActiveAndSolid(x + 1, y + 1);
        }
    }
}                        
