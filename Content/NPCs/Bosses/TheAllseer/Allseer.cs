using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using On.Terraria.GameContent.Events;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Boss.Allseer;

namespace Trinitarian.Content.NPCs.Bosses.TheAllseer
{
    [AutoloadBossHead]
    public class Allseer : ModNPC
    {
        public int t;
        public int progTimer2;
        public int progTimer1;
        public float someValue;
        public float someValue2;
        public int timerAttack;
        public int shootTimer;
        public int shootTimer2;
        public int shootTimer3;
        public int shootTimer4;
        public int dashTimer;
        public int dashTimer2;
        private float whiteIn = 0f;
        private int vint; 
        private int hibub;
        public static Allseer allseer;

        /*Boss Moveset
        Does Stuff*/


        private enum AllseerState
        {
            IdleMovement = 0,
            BigCrystals = 1,
            EnergyBlast = 2,
            BigCrystalRain = 3,
            EnergyBlastTwo = 4,
            Dash = 5,
            HomingCrystals = 6,
            Depression = 7,
            Empty = 8,
            CrystalHell = 9,
            PhaseTwoTransition = 10,
            ShadowDash = 11,
        }

        private AllseerState State
        {
            get => (AllseerState)NPC.ai[0];
            set => NPC.ai[0] = (float)value;
        }

        /// <summary>
        /// Manages several AI state attack timers.
        /// Gets and sets npc.ai[1] as tracker.
        /// </summary>
        private float AttackTimer
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;
        }

        /// <summary>
        /// Manages the phase 2
        /// Gets and sets npc.ai[2] as tracker.
        /// </summary>
        public float PhaseTwo
        {
            get => NPC.ai[2];
            set => NPC.ai[2] = value;
        }


        /// <summary>
        /// Changes the npc state and attack timer
        /// Allows easier code injection later on to interupt change states
        /// </summary>
        public void ChangeState(int stateIndex, int attackTimer = 0)
        {
            State = (AllseerState)stateIndex;
            if (PhaseTwo < 1 && NPC.life < NPC.lifeMax / 2)
                State = AllseerState.PhaseTwoTransition;

            if (PhaseTwo > 2000)
            {
                State = AllseerState.ShadowDash;
                PhaseTwo = Main.rand.Next(5, 200);

            }

            this.AttackTimer = attackTimer;

        }

        /*public override bool Autoload(ref string name)
        {
            ScreenObstruction.Draw += DrawOverBlackout;
            return true;
        }*/

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angrboda, Mechanical Terror of Ragnorok");
            Main.npcFrameCount[NPC.type] = 8;
        }
        public override void SetDefaults()
        {
            NPC.aiStyle = -1;  //5 is the flying AI
            NPC.lifeMax = 380000;
            NPC.damage = 325;  
            NPC.defense = 60;    
            NPC.knockBackResist = 0f;
            NPC.width = 220;
            NPC.height = 260;
            NPC.value = Item.buyPrice(0, 5, 75, 45);
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.DeathSound = SoundID.NPCHit5;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return NPC.localAI[2] > -30f && State != AllseerState.ShadowDash ? false : base.CanHitPlayer(target, ref cooldownSlot);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = 456000;  //boss life scale in expertmode
            NPC.damage = 413;  //boss damage increase in expermode
        }

        int moveSpeed = 0;
        bool text = false;
        int moveSpeedY = 0;

        public bool doingDash = false;

        public override void AI()
        {

            NPC.dontTakeDamage = NPC.localAI[2] > 0f && State != AllseerState.ShadowDash;
            NPC.localAI[0] = NPC.velocity.X * 0.025f;
            NPC.rotation += (NPC.localAI[0] - NPC.rotation) * 0.05f;

            NPC.localAI[2]--;
            if (NPC.localAI[2] < 1)
                NPC.localAI[3] *= 0.95f;

            allseer = this;

            if (PhaseTwo > 0 && State != AllseerState.PhaseTwoTransition)
            {
                PhaseTwo += 1;
            }

            NPC.TargetClosest(true);
            Player target = Main.player[NPC.target];
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
            var player = Main.player[NPC.target];
            Vector2 move = player.position - NPC.Center;

            float speed = 4.6f;
            Vector2 playerPos = player.position + new Vector2(0, 0);
            Vector2 moving = playerPos - NPC.Center;
            float magnitude = 1f;
            int RandomPos;
            float turnResistance = 5f;

            if (Main.dayTime || player.dead)
            {
                NPC.rotation *= 0.99f;
                NPC.velocity.Y -= 0.09f;
                NPC.timeLeft = 100;
                if (NPC.position.Y <= 16 * 20) //checking for top of the world practically
                    NPC.active = false;
                return;
            }

            switch (State)
            {

                case AllseerState.IdleMovement:

                    if (AttackTimer % 120 == 0)
                    {
                        RandomPos = 300;
                    }
                    else
                    {
                        RandomPos = -300;
                    }
                    playerPos = player.position + new Vector2(0, RandomPos);
                    {
                        speed = 4.6f;
                        moving = playerPos - NPC.Center;
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        turnResistance = 5f;
                        moving = (NPC.velocity * turnResistance + moving) / (turnResistance + 1f);
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        NPC.velocity = moving;
                        // Main.NewText("Idle Movement");
                        if (++AttackTimer >= 1)
                        {
                            NPC.netUpdate = true;

                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                ChangeState((int)AllseerState.BigCrystals);
                            }
                        }
                    }

                    break;
                case AllseerState.BigCrystals:

                    if (++AttackTimer <= 220)
                    {
                        //Main.NewText("Radial Icicles");

                        // follows player from the top and shoots a blast of icy spikes

                        float scalespeed = (PhaseTwo > 0 ? 0.2f : MathHelper.Clamp(AttackTimer / 300f, 0f, 1f)) * 10f;

                        if (AttackTimer < 30 && PhaseTwo > 0)
                        {
                            if (AttackTimer < 80)
                            {
                                NPC.localAI[2] = 2;
                                NPC.localAI[3] += (60f - NPC.localAI[3]) * 0.75f;
                            }
                            else
                            {
                                NPC.localAI[2] = 2;
                                NPC.localAI[3] += (0f - NPC.localAI[3]) * 0.75f;
                            }
                        }

                        NPC.velocity.X = (((NPC.velocity.X + move.X) / 20f)) * scalespeed;
                        NPC.velocity.Y = (((NPC.velocity.Y + move.Y - 300) / 20f)) * scalespeed;

                        int type = Mod.Find<ModProjectile>("BigCrystal").Type;
                        int damage = Main.expertMode ? 10 : 5;// if u want to change this, 15 is for expert mode, 10 is for normal mod
                        float speedX = 10f;
                        float speedY = 10f;
                        Vector2 position = NPC.Center;


                        shootTimer++;

                        if (shootTimer >= 90)
                        {
                            if (Main.netMode != 1)
                                for (int i = 0; i < 8; i++)
                                {
                                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(45 * i));
                                    Projectile.NewProjectile(Projectile.InheritSource(NPC), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 2f, Main.myPlayer);
                                }
                            shootTimer = 0;
                        }
                        if (AttackTimer == 220)
                        {
                            NPC.netUpdate = true;

                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                ChangeState(Main.rand.Next(2, 10));
                            }
                        }
                    }

                    break;
                case AllseerState.EnergyBlast:

                    if (++AttackTimer <= 180)
                    {
                        dashTimer = 0;
                        playerPos = player.position + new Vector2(Math.Sign(-move.X) * 500, 0);
                        speed = 3.2f;
                        moving = playerPos - NPC.Center;
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        turnResistance = 5f;
                        moving = (NPC.velocity * turnResistance + moving) / (turnResistance + 1f);
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        NPC.velocity = moving;
                        Main.NewText("Energy Blast");
                        vint++;
                        if (vint >= 40)
                        {
                            float Speed = 7f;
                            int damage = Main.expertMode ? 10 : 5;// if u want to change this, 15 is for expert mode, 10 is for normal mod
                            int type = Mod.Find<ModProjectile>("EnergyBlast").Type;
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            if (Main.netMode != 1)
                                Projectile.NewProjectile(Projectile.InheritSource(NPC), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                            vint = 0;
                        }
                    }
                    if (AttackTimer == 180)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState(Main.rand.Next(2, 10));
                        }
                    }

                    break;
                case AllseerState.EnergyBlastTwo:

                    if (++AttackTimer <= 180)
                    {
                        Main.NewText("DeadlyEnergyBlast");
                        /*Vector2 playerPos = player.position + new Vector2(0, -300);
                        float speed = 5.1f;
                        Vector2 moving = playerPos - npc.Center;
                        float magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        float turnResistance = 5f;
                        moving = (npc.velocity * turnResistance + moving) / (turnResistance + 1f);
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        npc.velocity = moving;*/
                        int damage = Main.expertMode ? 10 : 5;// if u want to change this, 15 is for expert mode, 10 is for normal mod
                        Vector2 position = NPC.Center;
                        int type = Mod.Find<ModProjectile>("EnergyBlast").Type;
                        float rotate = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        shootTimer2++;
                        if (shootTimer2 >= 50)
                        {
                            float numberProjectiles = 6;
                            float rotation = MathHelper.ToRadians(10);
                            position += Vector2.Normalize(new Vector2((float)((Math.Cos(rotate) * 5f) * -1), (float)((Math.Sin(rotate) * 5f) * -1))) * 45f;
                            for (int i = 0; i < numberProjectiles; i++)
                            {
                                Vector2 perturbedSpeed = new Vector2((float)((Math.Cos(rotate) * 5f) * -1), (float)((Math.Sin(rotate) * 5f) * -1)).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2f;
                                if (Main.netMode != 1)
                                {
                                    float speedMult = 1f;
                                    if (i == 1 || i == 3)
                                    {
                                        speedMult = 1.25f;
                                    }
                                    else if (i == 2)
                                    {
                                        speedMult = 1.5f;
                                    }
                                    SoundEngine.PlaySound(SoundID.Item101);
                                    Projectile.NewProjectile(Projectile.InheritSource(NPC), position.X, position.Y, perturbedSpeed.X * speedMult, perturbedSpeed.Y * speedMult, type, damage, 2f, Main.myPlayer);

                                }
                                shootTimer2 = 0;

                            }
                        }
                    }
                    if (AttackTimer == 180)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState(Main.rand.Next(2, 10));
                        }
                    }

                    break;
                case AllseerState.BigCrystalRain:

                    if (++AttackTimer <= 0)
                    {
                        progTimer1++;
                        Main.NewText("Rain");

                    }
                    if (AttackTimer == 1)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState(Main.rand.Next(2, 10));
                        }
                    }

                    break;
                case AllseerState.HomingCrystals:

                    NPC.velocity *= 0.99f;
                    //Main.NewText("HomingVoidSouls");
                    if (++AttackTimer <= 180)
                    {
                        hibub++;
                        if (hibub >= 100)
                        {
                            int damage = Main.expertMode ? 10 : 5;// if u want to change this, 15 is for expert mode, 10 is for normal mod
                            int type2 = Mod.Find<ModProjectile>("BigCrystal").Type;
                            Projectile.NewProjectile(Projectile.InheritSource(NPC), player.Center + new Vector2(0, -300), new Vector2(0, 0), type2, damage, 2f, player.whoAmI);
                            hibub = 0;
                        }
                        shootTimer2++;
                        if (shootTimer2 >= 150)
                        {
                            float numberProjectiles = 4;
                            for (int i = 0; i < numberProjectiles; i++)
                            {
                                if (Main.netMode != 1)
                                {
                                    FireLaser(ModContent.ProjectileType<HomingCrystal>(), 1, 0, player.whoAmI);
                                }
                                shootTimer2 = 0;

                            }
                        }
                    }
                    if (AttackTimer == 180)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState((int)AllseerState.Dash);
                        }
                    }

                    break;
                case AllseerState.Dash:


                    Vector2 movewhere = PhaseTwo > 0 ? move + new Vector2(Math.Sign(player.Center.X - NPC.Center.X) * -200, -200) : move;

                    //Main.NewText("Dash");
                    if (++AttackTimer >= 0 && AttackTimer < 480)
                    {
                        dashTimer++;

                        if (dashTimer % 240 < 150)
                        {

                            NPC.velocity = movewhere * MathHelper.Clamp((dashTimer % 240) / 100f, 0f, 1f) * (PhaseTwo > 0 ? 0.075f : 0.02f);
                            NPC.velocity *= 0.99f;//Friction

                        }
                        else if (dashTimer % 240 < 160 || dashTimer % 240 > 220)
                        {
                            //  Main.NewText("Dash Wait");
                            if (PhaseTwo > 0)
                            {
                                NPC.velocity = -Vector2.Normalize(move) * (12 * MathHelper.Clamp(AttackTimer / 60f, 0f, 1f));

                            }
                            NPC.velocity *= 0.75f;
                            moveSpeed = 0;
                        }
                        else
                        {
                            // Main.NewText("Dash Fly");
                            if (moveSpeed == 0)
                            {
                                SoundEngine.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), NPC.Center);
                                moveSpeed = Math.Sign(player.Center.X - NPC.Center.X) * 10;
                                if (PhaseTwo < 1)
                                {
                                    NPC.velocity.X = moveSpeed;
                                }
                                else
                                {
                                    NPC.velocity = Vector2.Normalize(move) * 16;
                                }
                            }
                        }
                    }

                    if (AttackTimer == 480)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState((int)AllseerState.BigCrystals);
                        }
                    }

                    break;
                case AllseerState.Depression:

                    Main.NewText("Depression");
                    if (++AttackTimer <= 80)
                    {
                        NPC.velocity *= 0.99f;
                        NPC.velocity.Y -= 0.02f;
                        float numberProjectiles = 2;
                        float rotation = MathHelper.ToRadians(10);
                        float rotate = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));

                        Vector2 position = NPC.Center;
                        someValue += 3f;
                        shootTimer2++;
                        position += Vector2.Normalize(new Vector2((float)((Math.Cos(rotate) * 5f) * -1), (float)((Math.Sin(rotate) * 5f) * -1))) * 45f;
                        if (shootTimer2 > 40)
                        {
                            if (Main.netMode != 1)
                            {
                                Projectile.NewProjectile(Projectile.InheritSource(NPC), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<Depressed>(), 15, 2f, Main.myPlayer, NPC.target);

                            }
                            shootTimer2 = -30;
                        }
                    }
                    if (AttackTimer == 80)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState((int)Main.rand.Next(2, 10));
                        }
                    }
                    break;
                case AllseerState.CrystalHell:

                    playerPos = player.position + new Vector2(-400, 0);
                    {
                        speed = 4.6f;
                        moving = playerPos - NPC.Center;
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        turnResistance = 5f;
                        moving = (NPC.velocity * turnResistance + moving) / (turnResistance + 1f);
                        magnitude = (float)Math.Sqrt(moving.X * moving.X + moving.Y * moving.Y);
                        if (magnitude > speed)
                        {
                            moving *= speed / magnitude;
                        }
                        NPC.velocity = moving;
                        float length = 850f;
                        {
                            Vector2 projectilePos = player.Center + (Main.rand.NextFloat() * MathHelper.TwoPi).ToRotationVector2() * length;
                            Vector2 projectileVelocity = Vector2.Normalize(target.Center - projectilePos) * 16;

                            Main.NewText("Crystal Hell....GL");
                            if (++AttackTimer % 5 == 0 && AttackTimer < 40)
                            {
                                NPC.dontTakeDamage = true;

                                Projectile.NewProjectile(Projectile.InheritSource(NPC), projectilePos, projectileVelocity, ModContent.ProjectileType<BigCrystal>(), NPC.damage, 1);
                            }
                        }
                        if (AttackTimer == 50)
                        {
                            NPC.dontTakeDamage = false;
                            NPC.netUpdate = true;

                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                ChangeState((int)Main.rand.Next(2, 10));
                            }
                        }
                    }

                    break;
                case AllseerState.PhaseTwoTransition:

                    var entitySource = NPC.GetSource_Death();
                    NPC.velocity *= 0.95f;
                    NPC.dontTakeDamage = true;

                    whiteIn = MathHelper.Clamp(whiteIn + (AttackTimer < 120 ? 0.025f : -0.15f), 0, 1f);

                    if (++AttackTimer == 120)
                    {
                        PhaseTwo = 1;

                        Microsoft.Xna.Framework.Audio.SoundEffectInstance snd = SoundEngine.PlaySound(new LegacySoundStyle(SoundID.Roar, 2), NPC.Center);

                        if (snd != null)
                        {
                            snd.Pitch = -0.25f;
                        }
                    }

                    if (AttackTimer == 200)
                    {
                        NPC.netUpdate = true;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            ChangeState((int)AllseerState.Dash);
                        }
                    }

                    break;
                case AllseerState.ShadowDash:

                    //Main.NewText("Dash");

                    AttackTimer += 1;

                    NPC.localAI[2] = 20;
                    NPC.localAI[3] += (60f - NPC.localAI[3]) * 0.15f;

                    if (AttackTimer < 600)
                        Terraria.GameContent.Events.ScreenObstruction.screenObstruction = MathHelper.Clamp(Terraria.GameContent.Events.ScreenObstruction.screenObstruction + 0.10f, 0f, 0.95f);

                    dashTimer++;

                    int dashindex = 200;

                    if (dashTimer % dashindex >= 140)
                    {

                        //Main.NewText(npc.velocity);

                        if (dashTimer % dashindex == 140)
                        {
                            NPC.velocity = Vector2.Normalize(move) * 32f;

                            Microsoft.Xna.Framework.Audio.SoundEffectInstance snd = SoundEngine.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), NPC.Center);

                            if (snd != null)
                            {
                                snd.Pitch = 0.50f;
                            }

                        }

                        if (dashTimer % 10 == 0)
                        {
                            Projectile.NewProjectile(Projectile.InheritSource(NPC), NPC.Center, -Vector2.Normalize(move) * 1f, ModContent.ProjectileType<HomingCrystal>(), 20, 0, Main.myPlayer);
                        }
                    }
                    else
                    {
                        if (dashTimer % dashindex < 100)
                        {
                            NPC.velocity += ((move + Vector2.UnitX.RotatedBy(move.ToRotation() + MathHelper.Pi) * (MathHelper.Max((dashTimer % dashindex * 12f) - 200, 240f))) - NPC.velocity) * 0.025f;
                            NPC.velocity = Vector2.Normalize(NPC.velocity) * MathHelper.Clamp(NPC.velocity.Length(), 0f, 12f);

                        }
                        NPC.velocity *= 0.95f;
                    }

                    if (AttackTimer == 650)
                    {
                        dashTimer = 0;
                        NPC.netUpdate = true;

                    }

                    break;
                default:

                    //when non is true
                    break;

            }
        }

        public override void FindFrame(int frameHeight)
        {
            int factor = (int)((Main.player[NPC.target].Center.X - NPC.Center.X) / Math.Abs(Main.player[NPC.target].Center.X - NPC.Center.X));
            NPC.frameCounter++;

            if (NPC.frameCounter % 6f == 5f)
            {
                NPC.frame.Y += frameHeight;
            }
            if (NPC.frame.Y >= frameHeight * 8) // 8 is max # of frames
            {
                NPC.frame.Y = 0; // Reset back to default
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                int DustType = DustID.PurpleTorch;
                int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }

        public void FireLaser(int type, float speed = 6f, float recoilMult = 2f, float ai1 = 0, float ai2 = 0)
        {
            Player player = Main.player[NPC.target];
            Vector2 toPlayer = player.Center - NPC.Center;
            toPlayer = toPlayer.SafeNormalize(new Vector2(1, 0));
            toPlayer *= speed;
            Vector2 from = NPC.Center - new Vector2(96, 0).RotatedBy(NPC.rotation);
            int damage = 75;
            /*if (Main.expertMode)
            {
                damage = (int)(damage / Main.expertDamage);
            }*/
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Projectile.NewProjectile(Projectile.InheritSource(NPC), from, toPlayer, type, damage, 3, Main.myPlayer, ai1, ai2);
            }
            NPC.velocity -= toPlayer * recoilMult;
        }
    }
}
