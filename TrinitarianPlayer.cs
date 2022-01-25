using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Trinitarian.Buffs;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Localization;
using Trinitarian.Items.Accessories.Mage;
using Trinitarian.Projectiles.Magus.Runes;
using Trinitarian.Projectiles.Abilltys;
using Trinitarian.Projectiles.Mage;

namespace Trinitarian
{
	public class TrinitarianPlayer : ModPlayer
	{
        //Shit for shit
		public int TitleID;
		public bool FocusBoss;
	    public bool ShowText;

		public int ScreenShake;
        public AbiltyID CurrentA;
        public bool canFocus = true;

        //Buffs
        public bool drowning = false;
        public bool nosferatu = false;
        public bool WizardBuff = false;

        //More Buffs
        public bool holyWrath;
        public bool mirrorBuff;
        public bool NecroHeal = false;

        //These are all important for the Orbiting staff. They could be used for other uses though. The orbiting staff uses at most the first 15 of the OrbitingProjectile array so the rest are free to use for other weapons.
        public int RotationTimer = 0;
        public int[] OrbitingProjectileCount = new int[5];                               //Current upadted count of how many projectiles are active.
        public Vector2[,] OrbitingProjectilePositions = new Vector2[5, 50];             //Used to store the desired positions for the projectiles.
        public Projectile[,] OrbitingProjectile = new Projectile[5, 50];                //This stores all the projectiles that are currently beeing used. A projectiles ID is equal to the index in this array.
        //End of orbiting projectile stuff.

        //Accessories
        public bool TrueHeart;

        //Weapons 'n shit
        public float ammoReduction = 1f;

        public Vector2[] PreviousVelocity = new Vector2[30];
        // private float amount = 0;


        public enum AbiltyID : int         
        {    
            None,//0
            Paladin,//1
            Elf,//2
            Necromancer,//3
            Wizard//4
        }
        public override TagCompound Save()
        {
            return new TagCompound 
            {
				{"CurrentA", (int)CurrentA},
            };
        }
        public override void Load(TagCompound tag)
        {
            CurrentA = (AbiltyID)tag.GetInt("CurrentA");        
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player p = Main.player[Main.myPlayer];
            if (Trinitarian.UseAbilty.JustPressed && !p.HasBuff(ModContent.BuffType<Cooldown>()))
            {
                switch (CurrentA)
                {//Add stuff for the abiltys here, if you want to make more, add more IDs
                    case (int)AbiltyID.None:
                        Main.NewText("No Abilty");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 120);
                        break;
                    case AbiltyID.Elf:
                        Main.NewText("Elf");
                        ModAbilitys.ElfAbility(player);
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                          Projectile.NewProjectile(Main.MouseWorld+ new Vector2(0,-50), new Vector2(0, 0), ModContent.ProjectileType<ElfAbilityMirror>(), 10, 0f, p.whoAmI);
                        break;
                    case AbiltyID.Paladin:
                        Main.NewText("Paladin");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        Projectile.NewProjectile(Main.MouseWorld+ new Vector2(0,-50), new Vector2(0, 0), ModContent.ProjectileType<LightSpawner>(), 10, 0f, p.whoAmI);
                        break;
                    case AbiltyID.Necromancer:
                        Main.NewText("Necromancer");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        break;
                    case AbiltyID.Wizard:
                        Main.NewText("Wizard");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 120);
                        Projectile.NewProjectile(Main.MouseWorld+ new Vector2(0,-50), new Vector2(0, 0), ModContent.ProjectileType<ElementalStormBottom>(), 10, 0f, p.whoAmI);
                        break;
                    default:
                        Main.NewText("That wasnt supposed to happen \n Your abilty isnt set to anything, or no abilty!", new Color(255, 0, 0));
                        break;
                }
            }
        }


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
            //Buffs
            drowning = false;
            nosferatu = false;
            mirrorBuff = false;
            WizardBuff = false;

            //More Buffs
            holyWrath = false;
            NecroHeal = false;

            //Accessories
            TrueHeart = false;

            //Weapons
            ammoReduction = 1f;
        }
        public override void UpdateDead()
        {
            drowning = false;
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
        public override void UpdateLifeRegen()
        {
            if (drowning)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 8; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }

            if (nosferatu)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }
        }

         public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
         {
            if (drowning)
            {
                int messageType = Main.rand.Next(4); //the number of different types of death messages you want to have
                if (messageType == 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 0
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " forgot to breathe.");
                }
                else if (messageType == 1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 1
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " is sleeping with the fish.");
                }
                else if (messageType == 2 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 2 etc
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " drowned.");
                }
                else if (messageType == 3 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " is shark food.");
                }
            }

            if (nosferatu)
            {
                int messageType = Main.rand.Next(4); //the number of different types of death messages you want to have
                if (messageType == 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 0
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " will could not overpower the dark.");
                }
                else if (messageType == 1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 1
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " has lost all light in their soul.");
                }
                else if (messageType == 2 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 2 etc
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " life has deteriorated.");
                }
                else if (messageType == 3 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(player.name + " is in the hands of death.");
                }
            }
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
         }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (mirrorBuff)
            {
                damage /= 2;
            }
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
                OrbitingProjectilePositions[0, i] = player.Center + new Vector2(200 * (float)Math.Cos(period * (RotationTimer + (300 / OrbitingProjectileCount[0] * i))), 200 * (float)Math.Sin(period * (RotationTimer + (300 / OrbitingProjectileCount[0] * i))));
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (TrueHeart)
            {
                int projectiles = 3;
                if (Main.netMode != NetmodeID.MultiplayerClient && Main.myPlayer == player.whoAmI)
                {
                    for (int i = 0; i < projectiles; i++)
                    {
                        Projectile.NewProjectile(player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<BloodRune>(), 19, 2, player.whoAmI);
                    }
                }
            }

            if (WizardBuff)
            {
                Main.PlaySound(SoundID.Item74);
                int projectiles = 9;
                for (int i = 0; i < projectiles; i++)
                {
                    Projectile.NewProjectile(player.Center, new Vector2(4).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<OceanCurseProj>(), 60, 9, player.whoAmI);
                }
            }
        }


        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
            if (item.melee)
			{
                if (holyWrath)
                { 
                    target.AddBuff(ModContent.BuffType<HolySmite>(), 600);
                }
            }
        }

        public void PickRandomAmmo(Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume = false)
        {
            Item item = new Item();
            List<int> possibleAmmo = new List<int>();

            for (int i = 0; i < 58; i++)
            {
                if (player.inventory[i].ammo == sItem.useAmmo && player.inventory[i].stack > 0)
                {
                    //item = player.inventory[i];

                    possibleAmmo.Add(i);

                    canShoot = true;
                }
            }

            if (canShoot)
            {
                item = player.inventory[possibleAmmo[Main.rand.Next(possibleAmmo.Count)]];
                speed += item.shootSpeed;
                if (item.ranged)
                {
                    if (item.damage > 0)
                    {
                        Damage += (int)((float)item.damage * player.rangedDamage);
                    }
                }
                else
                {
                    Damage += item.damage;
                }
                if (sItem.useAmmo == AmmoID.Arrow && player.archery)
                {
                    if (speed < 20f)
                    {
                        speed *= 1.2f;
                        if (speed > 20f)
                        {
                            speed = 20f;
                        }
                    }
                    Damage = (int)((double)((float)Damage) * 1.2);
                }
                KnockBack += item.knockBack;
                shoot = item.shoot;
                if (!dontConsume && item.maxStack > 1)
                {
                    item.stack--;
                }
                ItemLoader.PickAmmo(sItem, item, player, ref shoot, ref speed, ref Damage, ref KnockBack);
                bool flag2 = dontConsume;

                if (player.magicQuiver && sItem.useAmmo == AmmoID.Arrow && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (player.ammoBox && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (player.ammoPotion && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }

                if (player.ammoCost80 && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (player.ammoCost75 && Main.rand.Next(4) == 0)
                {
                    flag2 = true;
                }
                if (Main.rand.NextFloat() > ammoReduction)
                {
                    flag2 = true;
                }
                if (shoot == 85 && player.itemAnimation < player.itemAnimationMax - 6)
                {
                    flag2 = true;
                }

                if (!PlayerHooks.ConsumeAmmo(player, sItem, item))
                {
                    flag2 = true;
                }
                if (!ItemLoader.ConsumeAmmo(sItem, item, player))
                {
                    flag2 = true;
                }
            }
        }

        public override void OnHitAnything(float x, float y, Entity victim)
        {
			if(NecroHeal&& Main.rand.Next(4) == 0)
            { 
				int newLife = Main.rand.Next(2,6);
                player.statLife += newLife;
                player.HealEffect(newLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, newLife);
			}
        }
    }
}