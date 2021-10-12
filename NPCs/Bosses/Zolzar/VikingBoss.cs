using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Projectiles;
using Trinitarian;
using Trinitarian.NPCs.Bosses.Zolzar;

namespace Trinitarian.NPCs.Bosses.Zolzar
{
    [AutoloadBossHead]
    public class VikingBoss : ModNPC
    {
        private int bufferCount = 0;

        bool npcDashing = false;
        int spriteDirectionStore = 0;

        private const int State_Spawning = 0;
        private const int State_Moving = 1;
        private const int State_Attacking = 2;
        private const int State_Circling = 3; //This is used for the Adds the boss never enters this state.

        private const float AttackTargetingDistanceSQ = 1000 * 1000;
        private const int MovementTime = 300;
        private const int MaxDashes = 2;
        private const float Max_Speed = 6;
        private const int DashStartTime = 200;
        private const int DashDelay = 20;

        private const float SoftMovementDistanceSQ = 700 * 700;

        private const float DashSpeed = 18;

        private const int SpawnDelay = 60;

        private float DashTime;
        private int TimesDashed;
        private Vector2 tempPos;
        private Vector2 IntSpeed;

        public float AI_State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        public float Attack_State
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }
        public float AI_Timer
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }
        public float AddNumber
        {
            get => npc.ai[3];
            set => npc.ai[3] = value;
        }
        public float RotationTimer
        {
            get => npc.localAI[0];
            set => npc.localAI[0] = value;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar, Berserker Viking");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults()
        {
            npc.width = 102;
            npc.height = 102;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.damage = 195;
            npc.defense = 45;
            npc.lifeMax = 139000;
            npc.HitSound = SoundID.NPCHit4;
            npc.value = Item.buyPrice(gold: 5);
            npc.boss = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.defense = 17;
        }

        private void BossText(string text) // boss messages
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, Color.Green);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), Color.Green);
            }
        }
        public override bool PreAI()
        {
            Player target = Main.player[npc.target];
            TrinitarianPlayer globaltarget = target.GetModPlayer<TrinitarianPlayer>();
            int Frames = 20;
            for (int i = 1; i < Frames; i++)
            {
                globaltarget.PreviousVelocity[i] = globaltarget.PreviousVelocity[i - 1];
            }
            globaltarget.PreviousVelocity[0] = target.velocity;
            for (int i = 0; i < Frames; i++)
            {
                IntSpeed = Vector2.Lerp(IntSpeed, globaltarget.PreviousVelocity[Frames - 1 - i], 0.14f);
            }

            return true;
        }
        public override void AI()
        {
            //TODO better targeting selection
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];

            //This handles the timing for calculating the spinning adds. The period for 1 rotation is exactly 300 ticks. Changing this makes the circle spinn slower/faster but changing it is not recommended.
            //There are a a coupple things that rely on the rotation speed that would have to be changed which involves some math. So unless you know what you are doing don't touch this number.
            //Things that would require recalculation: Add movementspeed, Add locking distance, GenerateAddPositions.
            if (RotationTimer == 300)
            {
                RotationTimer = 0;
            }
            GenerateAddPositions();
            RotationTimer++;

            //Initial spawning. Boss starts with 5 Adds
            if (!TrinitarianWorld.downedViking && AI_State == State_Spawning)
            {
                npc.dontTakeDamage = true;
                npc.netUpdate = true;
               
                if (AI_Timer <= 200)
                {
                    if (AI_Timer % 50 == 0)
                    {
                        SpawnAdd(npc.Center);
                    }
                }
                else
                {
                    npc.dontTakeDamage = false;
                    AI_State = State_Moving;
                    AI_Timer = 0;
                    npc.netUpdate = true;
                }
                AI_Timer++;
                return;
            }

            // Handles Despawning
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                Main.NewText("Bye");
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }

            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = 2000;
                Main.NewText("bye");
            }

            //TODO not sure what this is but it wont ever get called
            //if (npc.ai[3] == 90)
            //{
            //    Main.PlaySound(new Terraria.Audio.LegacySoundStyle(SoundID.NPCKilled, 10), npc.Center); // every half second while dying, play a sound
            //    for (int i = 0; i < Main.maxPlayers; i++)
            //    {
            //        float distance = Vector2.Distance(npc.Center, Main.player[i].Center);
            //        if (distance <= 600)
            //        {
            //            Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 30;
            //        }
            //    }
            //}
            
            //Basic non attacking cooldown phase.
            if (AI_State == State_Moving)
            {
                Moving();
                float distPlayerSQ = (npc.Center - player.Center).LengthSquared();
                //Condition for when the boss can attack.
                if (AI_Timer >= MovementTime && npc.HasValidTarget && distPlayerSQ < AttackTargetingDistanceSQ)
                {
                    AI_State = State_Attacking;
                    AI_Timer = 0;
                }
            }

            //Attack logic.
            if (AI_State == State_Attacking)
            {
                //Initialization for the Attacks.
                if (AI_Timer == 0)
                {
                    //prevents repeat BigDAshAttack
                    if (Attack_State != 0) Attack_State = Main.rand.Next(0, 9);
                    else Attack_State = Main.rand.Next(1, 9);

                    if (AddNumber == 0) Attack_State = 0;
                    //Attack_State = 0;
                    npc.netUpdate = true;
                }
                switch (Attack_State)
                {
                    case 0:
                        if (AI_Timer == 0)
                        {
                            if (AddNumber == 0) SpawnAdd(npc.Center, 5);
                            //else SpawnAdd(npc.Center, 2);
                        }
                        BigDashAttack();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        //if (AI_Timer == 0) SpawnAdd(npc.Center);
                        for (int i = 0; i < (int)AddNumber/2f; i++)
                        {
                            SendAdd(2, 60*i);
                        }
                        if (AI_Timer >= 60 * AddNumber)
                        {
                            AI_State = State_Moving;
                            AI_Timer = -1;
                        }
                        break;
                    case 4:
                    case 5:
                    case 6:
                        if (AI_Timer == 0) SpawnAdd(npc.Center);
                        LightningStrike();
                        if (AI_Timer >= ((int)(AddNumber/2f) - 1) * SpawnDelay)
                        {
                            AI_State = State_Moving;
                            AI_Timer = -1;
                        }
                        break;
                    case 7:
                    case 8:
                        if (AI_Timer == 0) SpawnAdd(npc.Center);
                        LightningStrike((int)(AddNumber / 4f));
                        SendAdd(2, 20);
                        SendAdd(2, 80);
                        if (AI_Timer >= 180)
                        {
                            AI_State = State_Moving;
                            AI_Timer = -1;
                        }
                        break;
                }
            }
            AI_Timer++;
        }
        private void Moving()
        {
            Player player = Main.player[npc.target];
            float distPlayerSQ = (npc.Center - player.Center).LengthSquared();
            Vector2 npcAcc = player.Center - npc.Center;
            float maxspeed = Max_Speed;
            //Assign weight of the NPC
            if (npcAcc != Vector2.Zero)
            {
                npcAcc.Normalize();
                npcAcc *= 1 / 5f;
            }
            //scale speed with distance. Closer = Slower.
            if (distPlayerSQ < SoftMovementDistanceSQ)
            {
                //Simple scaling function !!NOT linear since the quantitys are squared!!.
                maxspeed *= distPlayerSQ / SoftMovementDistanceSQ;
            }
            //apply acceleration
            if ((npc.velocity + npcAcc).LengthSquared() <= maxspeed * maxspeed)
            {
                npc.velocity += npcAcc;
            }
            //Enforce the maxspeed by setting the magnitude of the vector.
            else
            {
                npc.velocity += npcAcc;
                if (npc.velocity != Vector2.Zero)
                {
                    npc.velocity.Normalize();
                }
                npc.velocity *= maxspeed;
            }
        }
        //This spawns the Adds.
        private void SpawnAdd(Vector2 pos, int count = 1)
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            for (int i = 0; i < count; i++)
            {   
                globalnpc.Add[(int)AddNumber] = NPC.NewNPC((int)pos.X, (int)pos.Y, ModContent.NPCType<VikingBossAdd>(), 0, 1, npc.whoAmI, 0, AddNumber, npc.target);
                AddNumber++;
            }           
            GenerateAddPositions();
        }
        //This is here to use in the BigDash.
        private void SendAdd(int SendCount, int delay = 0)
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            Moving();
            if (AI_Timer == delay)
            {
                int j = 0;
                //this selects the adds that are currently available.
                for (int i = 0; i < SendCount; i++)
                {                  
                    while (Main.npc[globalnpc.Add[j]].ai[0] != State_Circling && j < 40)
                    {
                        j++;
                    }
                    Main.npc[globalnpc.Add[j]].ai[0] = State_Attacking;   //Setting the State of the Add
                    Main.npc[globalnpc.Add[j]].ai[2] = 0;   //carefull here we need to reset to 0 and not -1 !!
                    Main.npc[globalnpc.Add[j]].localAI[0] = 1;  //Assigning the Attack state of the Add
                    j++;
                }
            }
        }

        private void LightningStrike(int delay = 0)
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            Moving();
            //this selects the adds that are currently available.
            if (AI_Timer >= delay)
            {
                int j = 0;
                if ((AI_Timer - delay) % SpawnDelay == 0)
                {
                    while (Main.npc[globalnpc.Add[j]].ai[0] != State_Circling && j < 40)
                    {
                        j++;
                    }
                    Main.npc[globalnpc.Add[j]].ai[0] = State_Attacking;   //Setting the State of the Add
                    Main.npc[globalnpc.Add[j]].ai[2] = 0;   //carefull here we need to reset to 0 and not -1 !!
                    Main.npc[globalnpc.Add[j]].localAI[0] = 0;  //Assigning the Attack state of the Add
                }
            }
        }
        private void Dash(int delay = 0)
        {
            Player target = Main.player[npc.target];
            if (AI_Timer == delay)
            {
                float time = 0;
                Vector2 npcVel = ModTargeting.LinearAdvancedTargeting(npc.Center, target.Center, IntSpeed, DashSpeed, ref time);
                ModTargeting.FallingTargeting(npc, target, new Vector2(0, -28), (int)DashSpeed, ref time, ref npcVel);
                if (time > 20) DashTime = time * (1.4f + 0.3f*TimesDashed);
                else DashTime = 26;
                //if (npcVel != Vector2.Zero)
                //{
                //    npcVel.Normalize();
                //}
                //npcVel *= DashSpeed;
                npc.velocity = npcVel;
            }
        }
        private void BigDashAttack()
        {
            Player target = Main.player[npc.target];
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            if (AI_Timer == 0)
            {
                for (int i = 0; i < AddNumber; i++)
                {
                    Main.npc[globalnpc.Add[i]].ai[0] = State_Attacking;   //Setting the State of the Add
                    Main.npc[globalnpc.Add[i]].ai[2] = 0;   //carefull here we need to reset to 0 and not -1 !!
                    Main.npc[globalnpc.Add[i]].localAI[0] = 2;  //Assigning the Attack state of the Add
                }
            }
            if (AI_Timer < DashStartTime && TimesDashed == 0)
            {
                float factor = target.Center.X - npc.Center.X;
                factor /= Math.Abs(factor); 
                MoveTo(target.Center - new Vector2 (factor * Main.screenWidth/3f, Main.screenHeight / 3f), 12, true);
            }  
            
            Dash(DashStartTime);
            
            if (AI_Timer >= DashTime + DashStartTime && TimesDashed < MaxDashes)
            {
                AI_Timer = DashStartTime - DashDelay;
                npc.velocity *= 0.04f;
                TimesDashed++;
            }
            if (TimesDashed == MaxDashes)
            {
                TimesDashed = 0;
                AI_State = State_Moving;
                AI_Timer = -1;
            }           
        }
        private void GenerateAddPositions()
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            double period = 2f * Math.PI / 300f;
            for (int i = 0; i < AddNumber; i++)
            {
                globalnpc.AddPositions[i] = npc.Center + new Vector2(300 * (float)Math.Cos(period * (RotationTimer + (300 / AddNumber * i))), 300 * (float)Math.Sin(period * (RotationTimer + (300 / AddNumber * i))));
            }
        }
        private bool MoveTo(Vector2 WantedPosition, float TravelSpeed, bool follow)
        {
            if (AI_Timer == 0 || follow)
            {
                tempPos = WantedPosition;
                Vector2 npcVel = tempPos - npc.Center;
                if (npcVel != Vector2.Zero)
                {
                    npcVel.Normalize();
                }
                npcVel *= TravelSpeed;
                npc.velocity = npcVel;
            }
            if (npc.DistanceSQ(tempPos) <= 14 * 14)
            {
                npc.Center = tempPos;
                npc.velocity = Vector2.Zero;
                return true;
            }
            return false;
        }
        private void SpawnThorns()
        {
            Player player = Main.player[npc.target];
            if (AI_Timer % 60 == 0 && AI_Timer < 240)
            {
                // Get the ground beneath the player
                Vector2 playerPos = new Vector2(player.position.X / 16, player.position.Y / 16);
                Tile tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                while (!tile.active() || tile.type == TileID.Trees)
                {
                    playerPos.Y += 1;
                    tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                }
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ModContent.ProjectileType<Lightning>(), 26, 2.5f, Main.myPlayer, 0f, 0f);
                }
            }

            if (AI_Timer == 240)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Get the ground beneath the player
                    Vector2 playerPos = new Vector2((player.position.X - 30 * i) / 16, (player.position.Y) / 16);
                    Vector2 playerPos2 = new Vector2((player.position.X + 30 * i) / 16, (player.position.Y) / 16);
                    Tile tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                    while (!tile.active() || tile.type == TileID.Trees)
                    {
                        playerPos.Y += 1;
                        tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                    }

                    Tile tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                    while (!tile2.active() || tile2.type == TileID.Trees)
                    {
                        playerPos2.Y += 1;
                        tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                    }
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (i == 0)
                        {
                            Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerPos2 * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }

            if (AI_Timer == 300)
            {
                AI_State = State_Moving;
                AI_Timer = -1;
            }
        }
        private void ShootSeeds()
        {
            if (AI_Timer % 75 == 0)
            {
                int numSeeds = npc.life <= npc.lifeMax * 0.25f ? 16 : 13;
                float numberProjectiles = Main.rand.Next(7, numSeeds);
                Vector2 position = npc.Center;
                int speedX = 1;
                int speedY = Main.rand.Next(-25, -15);
                float rotation = MathHelper.ToRadians(45);
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f; // This defines the projectile roatation and speed. .4f == projectile speed
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 85, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PhantasmalBolt, 17, 1f, Main.myPlayer);
                    }
                }
            }

            //if (AI_Timer == 300)
            //{
            //    if (changedPhase2)
            //    {
            //        AI_State = State_Moving;
            //        AI_Timer = -1;
            //    }
            //    else
            //    {
            //        AI_State = State_Moving;
            //        AI_Timer = -1;
            //    }
            //}
        }
        private void MultipleThorns()
        {
            Player player = Main.player[npc.target];
            if (AI_Timer % 120 == 0)
            {
                int randChoice = Main.rand.Next(2);
                npc.netUpdate = true;
                if (randChoice == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        // Get the ground beneath the player
                        Vector2 playerPos = new Vector2((player.position.X - 30 * i) / 16, (player.position.Y) / 16);
                        Vector2 playerPos2 = new Vector2((player.position.X + 30 * i) / 16, (player.position.Y) / 16);
                        Tile tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                        while (!tile.active() || tile.type == TileID.Trees)
                        {
                            playerPos.Y += 1;
                            tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                        }

                        Tile tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                        while (!tile2.active() || tile2.type == TileID.Trees)
                        {
                            playerPos2.Y += 1;
                            tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                        }
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            if (i == 0)
                            {
                                Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                                Projectile.NewProjectile(playerPos2 * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        // Get the ground beneath the player
                        Vector2 playerPos = new Vector2((player.position.X - 90 * i) / 16, (player.position.Y) / 16);
                        Vector2 playerPos2 = new Vector2((player.position.X + 90 * i) / 16, (player.position.Y) / 16);
                        Tile tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                        while (!tile.active() || tile.type == TileID.Trees)
                        {
                            playerPos.Y += 1;
                            tile = Framing.GetTileSafely((int)playerPos.X, (int)playerPos.Y);
                        }

                        Tile tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                        while (!tile2.active() || tile2.type == TileID.Trees)
                        {
                            playerPos2.Y += 1;
                            tile2 = Framing.GetTileSafely((int)playerPos2.X, (int)playerPos2.Y);
                        }
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            if (i == 0)
                            {
                                Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(playerPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                                Projectile.NewProjectile(playerPos2 * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 28, 2.5f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
            }

            if (AI_Timer == 320)
            {
                AI_State = State_Moving;
                AI_Timer = -1;
            }
        }
        private void ThornWave()
        {
            if (AI_Timer % 15 == 0)
            {
                // Get the ground beneath the player
                Vector2 npcPos = new Vector2((npc.position.X - 60 * bufferCount) / 16, npc.position.Y / 16);
                Tile tile = Framing.GetTileSafely((int)npcPos.X, (int)npcPos.Y);
                while (!tile.active() || tile.type == TileID.Trees)
                {
                    npcPos.Y += 1;
                    tile = Framing.GetTileSafely((int)npcPos.X, (int)npcPos.Y);
                }

                // Same thing going right, I'm lazy
                Vector2 npcPos2 = new Vector2((npc.position.X + npc.width + (60 * bufferCount)) / 16, npc.position.Y / 16);
                Tile tile2 = Framing.GetTileSafely((int)npcPos2.X, (int)npcPos2.Y);
                while (!tile2.active() || tile2.type == TileID.Trees)
                {
                    npcPos2.Y += 1;
                    tile2 = Framing.GetTileSafely((int)npcPos2.X, (int)npcPos2.Y);
                }

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(npcPos2 * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 31, 2.5f, Main.myPlayer, 0f, 0f);

                    Projectile.NewProjectile(npcPos * 16, new Vector2(0, -10), ProjectileID.CultistBossLightningOrb, 31, 2.5f, Main.myPlayer, 0f, 0f);
                    bufferCount++;
                }
            }

            if (AI_Timer == 180)
            {
                AI_State = State_Moving;
                AI_Timer = -1;
                bufferCount = 0;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            Texture2D texture = mod.GetTexture("NPCs/Bosses/Zolzar/VikingBoss");
            for (int i = 0; i < AddNumber; i++)
            {
                spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/Zolzar/DebugSqure"), globalnpc.AddPositions[i] - Main.screenPosition, new Color(0, 0, 254));
            }

        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;

            if (npc.frameCounter % 6f == 5f)
            {
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 10) // 10 is max # of frames
            {
                npc.frame.Y = 0; // Reset back to default
            }

            if (Main.player[npc.target].Center.X < npc.Center.X && npcDashing == false)
            {
                npc.spriteDirection = -1;
            }
            while (npcDashing == true && npc.spriteDirection != spriteDirectionStore)
            {
                npc.spriteDirection = spriteDirectionStore;
            }
        }

        public override bool CheckDead()
        {
            npc.boss = false;
            //TODO despawn adds
            return base.CheckDead();
        }

        public override void NPCLoot()
        {
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<VikingBossP2>(), 0, 0f, 0f, 0f, 0f);

            // Spawn 2nd Phase
            if (Main.netMode == NetmodeID.SinglePlayer) // Singleplayer
            {
                Main.NewText("You have truley angred the Berserker....YOU FOOL", Color.Blue);
            }
            else if (Main.netMode == NetmodeID.Server) // Server
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You have truley angred the Berserker...YOU FOOL"), Color.Blue);
            }
        }
    }
}
