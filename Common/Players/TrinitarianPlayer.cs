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
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker;
using Trinitarian.Content.Projectiles.Bonuses;
using Trinitarian.Content.NPCs.Bosses.Zolzar;
using Trinitarian.Content.Buffs;
using Trinitarian.Common.Projectiles;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword;
using Terraria.Audio;

namespace Trinitarian.Common.Players
{
	public class TrinitarianPlayer : ModPlayer
	{
        //Shit for shit
		public int TitleID;
		public bool FocusBoss;
	    public bool ShowText;
        bool useViking = false;
        Vector2 screenPositionStore;
        private float amount = 0;

		public int ScreenShake;
        public AbiltyID CurrentA;
        public bool canFocus = true;

        //Boss stuff
        public int constantDamage = 0;
        public float percentDamage = 0f;
        public bool chaosDefense = false;
        public float defenseEffect = -1f;

        //Buffs
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
        public bool SummonerDeath;
        public bool StarSet;
        public bool oceanSet;
        public bool Reaper;
        public bool Reap;
        public bool PaladinScroll;
        public bool Dartboard;

        //Weapons 'n shit
        public float ammoReduction = 1f;

        public int MechtideCharge = 0;

        public int ownedthunder = 0;
        public bool shaking;
        public int shakeamount;
         public int timer = 0;
        private int othertimer = 0;

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
                        ModAbilitys.ElfAbility(Player);
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
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
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
            nosferatu = false;
            mirrorBuff = false;
            WizardBuff = false;

            //More Buffs
            holyWrath = false;
            NecroHeal = false;

            //Accessories
            SummonerDeath = false;
            StarSet = false;
            oceanSet = false;
            Reaper = false;
            Reap = false;
            Dartboard = false;

            //Weapons
            ammoReduction = 1f;
            shaking = false;
            shakeamount = 0;

            //Boss Stuff
            constantDamage = 0;
            percentDamage = 0f;
            chaosDefense = false;
            defenseEffect = -1f;


            if (PaladinScroll)
			{
				base.Player.statLifeMax2 += base.Player.statLifeMax2 / 5 / 20 * 100;
			}
        }
        public override void UpdateDead()
        {
            MechtideCharge = 0;

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

        public override void PreUpdate()
        {   
            if (Main.mouseRight)
            {
                while (MechtideCharge > 0)
                {
                    float angle = (Main.MouseWorld - Player.Center).ToRotation() + MathHelper.ToRadians(Main.rand.Next(-100, 101) * .05f);

                    Projectile.NewProjectile(Player.Center.X, Player.Center.Y, (float)Math.Cos(angle) * 12f, (float)Math.Sin(angle) * 12f, ModContent.ProjectileType<MechtideCharge>(), 20, 2f, Player.whoAmI);
                    MechtideCharge--;
                }
            }
        }

        public override void PostUpdateEquips()
        {
            if (Player.ownedProjectileCounts[ModContent.ProjectileType<LightningFragment>()] >= 1)

                if (++othertimer > 60)
                {
                    othertimer = 0;
                    timer++;
                    Color color = Color.Lerp(Color.Blue, Color.Aqua, timer);
                    if (timer == 1)
                        color = Color.White;
                    if (timer == 2)
                        color = Color.Azure;
                    if (timer == 3)
                        color = Color.Yellow;
                    if (timer == 4)
                        color = Color.Aqua;
                    if (timer == 5)
                        color = Color.Red;
                    if (timer < 6)
                        CombatText.NewText(Player.getRect(), color, timer * 20 + "%");
                    if (timer == 6)
                    {
                        int count = 0;
                        for (int i = 0; i < Main.maxNPCs - 1; i++)
                        {
                            if (Main.npc[i].active)
                                if (!Main.npc[i].townNPC)
                                    if (!Main.npc[i].friendly)
                                        if (Main.npc[i].Distance(Player.Center) < 1000)
                                            if (Main.npc[i].CanBeChasedBy())
                                                //     if (Main.npc[i].type != NPCID.EaterofWorldsTail && Main.npc[i].type != NPCID.EaterofWorldsBody && Main.npc[i].type != NPCID.TheDestroyerBody && Main.npc[i].type != NPCID.TheDestroyerTail)
                                                if (++count < 5)
                                                    Projectile.NewProjectile(Player.Center - Vector2.UnitY * 500, Vector2.Zero, ModContent.ProjectileType<LightningFragment>(), 400, 20, Main.myPlayer, Player.whoAmI, i);
                        }

                        shakeamount = 0;
                        shaking = false;
                        timer = 0;
                        othertimer = 0;
                        Main.projectile[ownedthunder].Kill();
                    }
                }
            if (timer > 2)
            {
                shakeamount += 1;
                shakeamount = (int)MathHelper.Clamp(shakeamount, 0, 10);
                shaking = true;
            }
            
        }

        public override void UpdateLifeRegen()
        {
            if (nosferatu)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 16; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }
        }

         public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
         {
            if (nosferatu)
            {
                int messageType = Main.rand.Next(4); //the number of different types of death messages you want to have
                if (messageType == 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 0
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " will could not overpower the dark.");
                }
                else if (messageType == 1 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 1
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " has lost all light in their soul.");
                }
                else if (messageType == 2 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) //messagetype == 2 etc
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " life has deteriorated.");
                }
                else if (messageType == 3 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(Player.name + " is in the hands of death.");
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

        private bool holdPosition;
        private int holdCounter = 0;
        private Vector2 focusTo;
        private int holdCameraLength;
        private float towardsLength;
        private float returnLength;
        public void PlayerFocusCamera(Vector2 focusTo, int holdCameraLength, float towardsLength, float returnLength)
        {
            // The position to move to and from
            this.focusTo = focusTo;

            // How long the camera stays in place
            this.holdCameraLength = holdCameraLength;

            // How long it takes to travel to the position
            this.towardsLength = towardsLength;

            // How long it takes to return to the player
            this.returnLength = returnLength;

            // Finally, flag boolean to activate ModifyScreenPosition hook
            FocusBoss = true;
            canFocus = true;
        }

		public override void ModifyScreenPosition()
        {

            if (FocusBoss)
            {
                if (canFocus)
                {
                    if (!Main.gamePaused)
                    {
                        screenPositionStore = new Vector2(MathHelper.Lerp(Player.Center.X - Main.screenWidth / 2, focusTo.X - Main.screenWidth / 2, amount), MathHelper.Lerp(Player.Center.Y - Main.screenHeight / 2, focusTo.Y - Main.screenHeight / 2, amount));
                    }

                    Main.screenPosition = screenPositionStore;
                    amount += 1 / towardsLength;
                    if (amount >= 1f)
                    {
                        holdPosition = true;
                        canFocus = false;
                        amount = 0;
                    }
                }
                else
                {
                    if (holdPosition)
                    {
                        Main.screenPosition = screenPositionStore;
                        holdCounter++;

                        if (holdCounter == holdCameraLength)
                        {
                            holdCounter = 0;
                            holdPosition = false;
                        }
                    }
                    else
                    {
                        if (!Main.gamePaused)
                        {
                            screenPositionStore = new Vector2(MathHelper.SmoothStep(focusTo.X - Main.screenWidth / 2, Player.Center.X - Main.screenWidth / 2, amount), MathHelper.SmoothStep(focusTo.Y - Main.screenHeight / 2, Player.Center.Y - Main.screenHeight / 2, amount));
                        }
                        Main.screenPosition = screenPositionStore;

                        amount += 1 / returnLength;

                        if (amount >= 1f)
                        {
                            amount = 0;
                            FocusBoss = false;
                            canFocus = true;
                            ShowText = false;
                        }
                    }
                }
            }

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

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (Dartboard && item.ranged && Main.rand.NextBool(5))
			{
                 int projectiles = 1;
				for (int j = 0; j < 3; j++)
				{
					Vector2 vector2 = Main.MouseWorld - Vector2.UnitY.RotatedByRandom(0.40000000596046448) * 1250f;
					Vector2 value = (vector2 - Main.MouseWorld).SafeNormalize(Vector2.UnitY).RotatedByRandom(0.10000000149011612);
					for (int i = 0; i < projectiles; i++)
                    {
                        Projectile.NewProjectile(Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<Dart>(), 19, 2, Player.whoAmI);
                    }
                }
			}
			return true;
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
                        Projectile.NewProjectile(Player.Center, new Vector2(7).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<ShatteringStar>(), 19, 2, Player.whoAmI);
                    }
                }
            }

            if (WizardBuff)
            {
                SoundEngine.PlaySound(SoundID.Item74);
                int projectiles = 9;
                for (int i = 0; i < projectiles; i++)
                {
                    Projectile.NewProjectile(Player.Center, new Vector2(4).RotatedBy(MathHelper.ToRadians((360 / projectiles) * i + i)), ModContent.ProjectileType<Boulder>(), 60, 9, Player.whoAmI);
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

            if (item.summon)
			{
                if (SummonerDeath)
                { 
                    target.AddBuff(ModContent.BuffType<Nosferatu>(), 600);
                }
            }
        }

        public void PickRandomAmmo(Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume = false)
        {
            Item item = new Item();
            List<int> possibleAmmo = new List<int>();

            for (int i = 0; i < 58; i++)
            {
                if (Player.inventory[i].ammo == sItem.useAmmo && Player.inventory[i].stack > 0)
                {
                    //item = player.inventory[i];

                    possibleAmmo.Add(i);

                    canShoot = true;
                }
            }

            if (canShoot)
            {
                item = Player.inventory[possibleAmmo[Main.rand.Next(possibleAmmo.Count)]];
                speed += item.shootSpeed;
                if (item.ranged)
                {
                    if (item.damage > 0)
                    {
                        Damage += (int)((float)item.damage * Player.GetDamage(DamageClass.Ranged));
                    }
                }
                else
                {
                    Damage += item.damage;
                }
                if (sItem.useAmmo == AmmoID.Arrow && Player.archery)
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
                ItemLoader.PickAmmo(sItem, item, Player, ref shoot, ref speed, ref Damage, ref KnockBack);
                bool flag2 = dontConsume;

                if (Player.magicQuiver && sItem.useAmmo == AmmoID.Arrow && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (Player.ammoBox && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (Player.ammoPotion && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }

                if (Player.ammoCost80 && Main.rand.Next(5) == 0)
                {
                    flag2 = true;
                }
                if (Player.ammoCost75 && Main.rand.Next(4) == 0)
                {
                    flag2 = true;
                }
                if (Main.rand.NextFloat() > ammoReduction)
                {
                    flag2 = true;
                }
                if (shoot == 85 && Player.itemAnimation < Player.itemAnimationMax - 6)
                {
                    flag2 = true;
                }

                if (!PlayerHooks.ConsumeAmmo(Player, sItem, item))
                {
                    flag2 = true;
                }
                if (!ItemLoader.ConsumeAmmo(sItem, item, Player))
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
                Player.statLife += newLife;
                Player.HealEffect(newLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, Player.whoAmI, newLife);
			}
        }

        public override void UpdateBiomeVisuals()
        {           
            if (NPC.AnyNPCs(Mod.Find<ModNPC>("VikingBoss").Type))
            {
                useViking = true;
            }
            Player.ManageSpecialBiomeVisuals("Trinitarian:VikingBoss", useViking);
        }


        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
          
            if (constantDamage > 0 || percentDamage > 0f)
            {
                int damageFromPercent = (int)(Player.statLifeMax2 * percentDamage);
                damage = Math.Max(constantDamage, damageFromPercent);
                if (chaosDefense)
                {
                    double cap = Main.expertMode ? 75.0 : 50.0;
                    int reduction = (int)(cap * (1.0 - Math.Exp(-Player.statDefense / 150.0)));
                    if (reduction < 0)
                    {
                        reduction = Player.statDefense / 2;
                    }
                    damage -= reduction;
                    if (damage < 0)
                    {
                        damage = 1;
                    }
                }
                customDamage = true;
            }
            else if (defenseEffect >= 0f)
            {
                if (Main.expertMode)
                {
                    defenseEffect *= 1.5f;
                }
                damage -= (int)(Player.statDefense * defenseEffect);
                if (damage < 0)
                {
                    damage = 1;
                }
                customDamage = true;
            }
            constantDamage = 0;
            percentDamage = 0f;
            defenseEffect = -1f;
            chaosDefense = false;
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
    }
}
                