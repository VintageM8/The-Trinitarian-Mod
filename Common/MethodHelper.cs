using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Common
{
    public static class MethodHelper
    {
        public static Vector2 WorldEdge()
        {
            return new Vector2(Main.maxTilesX, Main.maxTilesY);
        }
        public static Vector2 DirectionTo(Vector2 Destination, Vector2 start)
        {
            return Vector2.Normalize(Destination - start);
        }
        public static Vector2 ToWorldCoordinants(int x, int y)
        {
            Vector2 vec = new Vector2(x, y).ToWorldCoordinates();
            return vec;
        }
        public static Vector2 FindBelowTile(Vector2 vec)
        {
            vec.Y /= 16;
            while (!Framing.GetTileSafely((int)vec.X / 16, (int)vec.Y).HasTile && Framing.GetTileSafely((int)vec.X / 16, (int)vec.Y).TileType != TileID.Tombstones && Framing.GetTileSafely((int)vec.X / 16, (int)vec.Y).TileType != TileID.Trees)
                vec.Y++;
            vec.Y *= 16;
            return vec;
        }
        //literraly just exists because im to lazy to figure out what function to use that gets a nomralized version of aa number;
        public static Vector2 Normalized(Vector2 input)
        {
            input.Normalize();
            return input;
        }
        //yoinked from vanilla
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        public static float GetLerpValue(float from, float to, float t, bool clamped = false)
        {
            if (clamped)
            {
                if (from < to)
                {
                    if (t < from)
                    {
                        return 0f;
                    }
                    if (t > to)
                    {
                        return 1f;
                    }
                }
                else
                {
                    if (t < to)
                    {
                        return 1f;
                    }
                    if (t > from)
                    {
                        return 0f;
                    }
                }
            }
            return (t - from) / (to - from);
        }
        public static float Percentage(float percent)
        {
            float percentage = percent / 100;
            return percentage;
        }

        public static NPC Sort(Projectile projectile, int index = 1)
        {
            NPC[] list = new NPC[200];
            float[] distances = new float[200];
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active)
                {
                    list[i] = Main.npc[i];
                    distances[i] = Vector2.Distance(projectile.Center, Main.npc[i].Center);
                }
            }
            Array.Sort(distances, list);
            Main.NewText(list[index].whoAmI);
            return list[index];
        }
        /*
        public static NPC FindClosest(Projectile projectile, int index = 0)
        {
            int[,] list = new int[2,200];
            int val1;
            int val2;
            int val3;
            int val4;
            int j;
            int affirmedpoints = 0;
            
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active)
                {
                    NPC nPC = Main.npc[i];
                    list[0,i]= (int)Vector2.Distance(nPC.Center, projectile.Center);
                //    Main.NewText(list[0, i]);
                    list[1, i] = i;
                }
            }
            
                while (affirmedpoints < 200)
                {
                    for (int k = 0; k < list.Length; k++)
                    {
                    if (AllMore(list,k) && AllLess(list, k))
                        {
                            affirmedpoints++;
                        }
              //      Main.NewText(affirmedpoints);
                    j = k;
                        while (list[0,j] < list[0,j+1])
                        {
                            val1 = list[0,j];
                            val2 = list[0,j + 1];
                            val3 = list[1,j];
                            val4 = list[1,j+1];
                            list[0,j + 1] = val1;
                            list[0,j] = val2;
                            list[1,j + 1] = val3;
                            list[1,j] = val4;
                            j += 1;
                        }
                    }
                
                    for(int l = 200; l > 0;l--)
                {
                    j = l;
                    while (list[0,j] > list[0,j - 1])
                    {
                        val1 = list[0,j];
                        val2 = list[0,j - 1];
                        val3 = list[1,j];
                        val4 = list[1,j - 1];
                        list[0,j - 1] = val1;
                        list[0,j] = val2;
                        list[1,j - 1] = val3;
                        list[1,j] = val4;
                        j += 1;
                    }
                }
                    
                    if(affirmedpoints != 200)
                    {
                        affirmedpoints = 0;
                    }
            }
              
            return Main.npc[list[1,index]];
        }
        public static bool AllMore(int[,] array, int index, int row = 0)
        {
            bool allless = true;
            for (int i = 0; i < index - 1; i++)
            {
                if (array[row,index] > array[row,i] && array[row, index] != array[row, i])
                {
                    allless = false;
                }
            }
            return allless;
           
        }
        public static bool AllLess(int[,] array, int index, int row = 0)
        {
            bool allmore = true;
            for(int i = index +1;i< 200;i++)
            {
                if(array[row,index] < array[row,i] && array[row, index] != array[row, i])
                {
                    allmore = false;
                }
            }
            return allmore;
        }
        */
        public static bool anybosses()
        {
            bool any = false;
            int bosscount = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].boss)
                {
                    bosscount++;
                }
            }
            if (bosscount > 0)
            {
                any = true;
            }

            return any;
        }
        public static bool PlayerIsInForest(Player player)
        {
            return !player.ZoneJungle
                && !player.ZoneDungeon
                && !player.ZoneCorrupt
                && !player.ZoneCrimson
                && !player.ZoneHallow
                && !player.ZoneSnow
                && !player.ZoneUndergroundDesert
                && !player.ZoneGlowshroom
                && !player.ZoneMeteor
                && !player.ZoneBeach
                && player.ZoneOverworldHeight;
        }
        /*public static void MakeFriendlyProjectile(Vector2 position, Vector2 velocity, int type, int damage, float knockback, int owner = 255, float ai0 = 0, float ai1 = 0)
        {
            Projectile projectile = Main.projectile[Projectile.NewProjectile(Player.GetSource_Misc, position, velocity, type, damage, knockback, owner, ai0, ai1)];
            projectile.friendly = true;
            projectile.hostile = false;
        }
        public static void MakeHostileProjectile(Vector2 position, Vector2 velocity, int type, int damage, float knockback, int owner = 255, float ai0 = 0, float ai1 = 0)
        {
            Projectile projectile = Main.projectile[Projectile.NewProjectile(position, velocity, type, damage, knockback, owner, ai0, ai1)];
            projectile.friendly = false;
            projectile.hostile = true;
        }*/
        public static int SecondsToTicks(int seconds)
        {
            return seconds * 60;
        }
        public static Vector3 ToVector3(this Vector2 vec)
        {
            return new Vector3(vec.X, vec.Y, 0);
        }
        public static Vector2 GetRandomVector(int MaxX, int MaxY, int MinX = 0, int MinY = 0)
        {
            return new Vector2(Main.rand.Next(MinX, MaxX), Main.rand.Next(MinY, MaxY));
        }
        public static Vector2 GetRandomVector(float mindistx, float mindisty, int MaxX, int MaxY, int MinX = 0, int MinY = 0)
        {
            float x = Main.rand.Next(MinX, MaxX);
            float y = Main.rand.Next(MinY, MaxY);
            while (Math.Abs(x) < mindistx)
                x = Main.rand.Next(MinX, MaxX);
            while (Math.Abs(y) < mindisty)
                y = Main.rand.Next(MinY, MaxY);
            return new Vector2(x, y);
        }
        public static Player Target(NPC npc, bool face = false)
        {
            npc.TargetClosest(face);
            Player player = Main.player[npc.target];
            npc.spriteDirection = npc.direction;
            return player;
        }
        public static Player FindClosest(Vector2 comparisonposition)
        {
            Player player = Main.player[0];
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active && !Main.player[i].dead)
                {
                    if (Vector2.Distance(Main.player[i].Center, comparisonposition) < player.Distance(comparisonposition))
                    {
                        player = Main.player[i];
                    }
                }
            }
            return player;
        }
        public static Projectile FindClosestProj(Vector2 comparisonposition)
        {
            Projectile projectile = Main.projectile[0];
            for (int i = 0; i < 255; i++)
            {
                if (Main.projectile[i].active)
                {
                    if (Vector2.Distance(Main.projectile[i].Center, comparisonposition) < projectile.Distance(comparisonposition))
                    {
                        projectile = Main.projectile[i];
                    }
                }
            }
            return projectile;
        }
        public static int FindClosestNPC(Vector2 comparisonposition)
        {
            int npc = 0;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active)
                {
                    if (Vector2.Distance(Main.npc[i].Center, comparisonposition) < Main.npc[npc].Distance(comparisonposition) && !Main.npc[i].friendly && Main.npc[i].type != NPCID.TargetDummy && !Main.npc[i].dontTakeDamage)
                    {
                        npc = i;
                    }
                }
            }
            return npc;

        }
        public static float DistanceFromDirection(int direction, Player player)
        {
            float returnvalue = 0;
            if (direction == 1)
                returnvalue = 0 - player.Center.Y;
            else if (direction == 2)
                returnvalue = Main.maxTilesX - player.Center.X;
            else if (direction == 3)
                returnvalue = Main.maxTilesY - player.Center.Y;
            else if (direction == 4)
                returnvalue = 0 - player.Center.X;
            return returnvalue;
        }
        public static int FindFirstProjectile(int type)
        {
            int j = -1;
            for (int i = 0; i < Main.maxProjectiles; i++)
                if (Main.projectile[i].type == type)
                {
                    j = i;
                    break;
                }
            return j;
        }
    }
}
