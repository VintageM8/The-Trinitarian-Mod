using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Trinitarian.Content.Buffs.Damage;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Localization;
using Trinitarian.Content.Projectiles.Abilltys.Paladin;
using Trinitarian.Content.Projectiles.Abilltys.Wizard;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using Trinitarian.Content.Projectiles.Weapon.Melee;
using Trinitarian.Content.Projectiles.Bonuses;
using Trinitarian.Content.NPCs.Bosses.Zolzar;
using Trinitarian.Content.Buffs;
using Trinitarian.Common.Projectiles;
using Terraria.Audio;

namespace Trinitarian.Common.Players
{
	public class TrinitarianPlayer : ModPlayer
	{
           //stuffs
           public int ScreenShake;
           public bool canFocus = true;
           public int timer = 0;
           private int othertimer = 0;
           public Vector2[] PreviousVelocity = new Vector2[30];

           //Orbiting
           public int RotationTimer = 0;
           public int[] OrbitingProjectileCount = new int[5];                               //Current upadted count of how many projectiles are active.
           public Vector2[,] OrbitingProjectilePositions = new Vector2[5, 50];             //Used to store the desired positions for the projectiles.
           public Projectile[,] OrbitingProjectile = new Projectile[5, 50];                //This stores all the projectiles that are currently beeing used. A projectiles ID is equal to the index in this array.

           //Accessories
           public bool SummonerDeath;
           public bool Dartboard;
           public bool TrueHeart;

           //Armor
           public bool SteelSet
           public bool StarSet;
           public bool oceanSet;
           public bool Reaper;
           public bool Reap;
       
           public int timer = 0;
           private int othertimer = 0;

          public Vector2[] PreviousVelocity = new Vector2[30];

        public override void OnEnterWorld(Player player)
        {
            //Important for Orbiting projectiles.
            for (int i = 0; i < OrbitingProjectileCount.Length; i++)
            {
                OrbitingProjectileCount[i] = 0;
            }
        }

        public override void ResetEffects()
        {
            //Accessories
            SummonerDeath = false;
            Dartboard = false;
            TrueHeart = false;

            //Armor
            SteelSet = false;
            StarSet = false;
            oceanSet = false;
            Reaper = false;
            Reap = false;

        }
        public override void UpdateDead()
        {

            nosferatu = false;
            //Important for Orbiting projectiles.
            for (int i = 0; i < OrbitingProjectileCount.Length; i++)
            {
                OrbitingProjectileCount[i] = 0;
            }
        }
        //This is where we make our central timer that the orbiting projectile uses.
        public override void PostUpdate()
        {
            bool temp = false;
            for (int i = 0; i < 5; i++)
            {
                if (OrbitingProjectileCount[i] > 0) temp = true;
            }
            if (temp)
            {
                GenerateProjectilePositions();
                RotationTimer++;
            }
            else RotationTimer = 0;
             }

 
     		public override void ModifyScreenPosition()
            {

            if (!Main.gamePaused)
            {
                if (ScreenShake > 0)
                {
                    Main.screenPosition += new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
                    ScreenShake--;
                }
            }
        }
        //oudated. Will delete soon.
        public void GenerateProjectilePositions()
        {           
            double period = 2f * Math.PI / 300f;
            for (int i = 0; i < OrbitingProjectileCount[0]; i++)
            {
                //Radius 200.
                OrbitingProjectilePositions[0, i] = Player.Center + new Vector2(200 * (float)Math.Cos(period * (RotationTimer + (300 / OrbitingProjectileCount[0] * i))), 200 * (float)Math.Sin(period * (RotationTimer + (300 / OrbitingProjectileCount[0] * i))));
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

            if (StarSet)
            {
                int projectiles = 1;
                if (Main.netMode != NetmodeID.MultiplayerClient && Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < projectiles; i++)
                    {
                         Projectile.NewProjectile(Player.GetSource_OnHurt(null), Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<ShatteringStar>(), 19, 2, Player.whoAmI);
                    }
                }
            }

            if (SteelSet)
            {
                int projectiles = 1;
                if (Main.netMode != NetmodeID.MultiplayerClient && Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < projectiles; i++)
                    {
                         Projectile.NewProjectile(Player.GetSource_OnHurt(null), Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<Boulder>(), 19, 2, Player.whoAmI);
                    }
                }
            }

            if (TrueHeart)
            {
                int projectiles = 3;
                if (Main.netMode != NetmodeID.MultiplayerClient && Main.myPlayer == Player.whoAmI)
                {
                    for (int i = 0; i < projectiles; i++)
                    {
                        Projectile.NewProjectile(Player.GetSource_OnHurt(null), Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<Boulder>(), 19, 2, Player.whoAmI);
                    }
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.DamageType == DamageClass.Summon)
	    {
                if (SummonerDeath)
                { 
                    target.AddBuff(ModContent.BuffType<Nosferatu>(), 600);
                }
            }
        }   
    }
}
