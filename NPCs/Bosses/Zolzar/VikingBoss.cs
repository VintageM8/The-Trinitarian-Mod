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
        bool changedPhase2 = false;
        private int bufferCount = 0;

        bool npcDashing = false;
        int spriteDirectionStore = 0;

        private const int State_Spawning = 0;
        private const int State_Moving = 1;
        private const int State_Attacking = 2;
        private const int State_Circling = 3;

        private const float AttackTargetingDistanceSQ = 1000 * 1000;
        private const int MovementTime = 300;
        private const int MaxDashes = 2;
        private const float Max_Speed = 6;

        private float DashTime;
        private int TimesDashed;

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

        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (RotationTimer == 300)
            {
                RotationTimer = 0;
            }
            GenerateAddPositions();
            RotationTimer++;
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
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
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
            }
            //TODO phase change
            //if (npc.life <= npc.lifeMax * 0.5f)
            //{
            //    changedPhase2 = true;
            //}

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

            if (AI_State == State_Moving)
            {
                Moving();
                float distPlayerSQ = (npc.Center - player.Center).LengthSquared();
                if (AI_Timer >= MovementTime && npc.HasValidTarget && distPlayerSQ < AttackTargetingDistanceSQ)
                {
                    AI_State = State_Attacking;
                    AI_Timer = -1;
                }
            }

            if (AI_State == State_Attacking)
            {
                if (AI_Timer == 0)
                {
                    Attack_State = Main.rand.Next(0, 7);
                    if (AddNumber == 0) Attack_State = 0;
                    npc.netUpdate = true;
                }
                switch (Attack_State)
                {
                    case 0:
                        if (AI_Timer == 0)
                        {
                            if (AddNumber == 0) SpawnAdd(npc.Center, 5);
                            else SpawnAdd(npc.Center, 2);
                        }
                        BigDashAttack();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        if (AI_Timer == 0) SpawnAdd(npc.Center);
                        SendAdd((int)AddNumber);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        if (AI_Timer == 0) SpawnAdd(npc.Center);
                        LightningStrike((int)AddNumber);
                        break;               
                }
            }
            AI_Timer++;
            Main.NewText(AddNumber);
        }
        private void Moving()
        {
            Player player = Main.player[npc.target];
            float distPlayerSQ = (npc.Center - player.Center).LengthSquared();
            Vector2 npcAcc = player.Center - npc.Center;
            float maxspeed = Max_Speed;
            if (npcAcc != Vector2.Zero)
            {
                npcAcc.Normalize();
                npcAcc *= 1 / 5f;
            }
            if (distPlayerSQ < 700 * 700)
            {
                maxspeed *= distPlayerSQ / (700 * 700);
            }
            if ((npc.velocity + npcAcc).LengthSquared() <= maxspeed * maxspeed)
            {
                npc.velocity += npcAcc;
            }
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

        private void SpawnAdd(Vector2 pos, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
                globalnpc.Add[(int)AddNumber] = NPC.NewNPC((int)pos.X, (int)pos.Y, ModContent.NPCType<VikingBossAdd>(), 0, 1, npc.whoAmI, 0, AddNumber, Main.myPlayer);
                AddNumber++;
            }           
            GenerateAddPositions();
        }
        private void Dash(int delay)
        {
            Player target = Main.player[npc.target];
            float DashSpeed = 18;
             if (AI_Timer == 0 + delay)
             {
                Vector2 npcVel = target.Center - npc.Center;
                DashTime = 1.5f * npcVel.Length() / DashSpeed;
                if (npcVel != Vector2.Zero)
                {
                    npcVel.Normalize();
                }
                npcVel *= DashSpeed;
                npc.velocity = npcVel;
             }

        }
        private void SendAdd(int SendCount)
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            if (AI_Timer == 0)
            {
                npc.velocity = Vector2.Zero;
                int j = 0;
                for (int i = 0; i < SendCount; i++)
                {
                    while (Main.npc[globalnpc.Add[j]].ai[0] != State_Circling && j < 40)
                    {
                        j++;
                    }
                    Main.npc[globalnpc.Add[j]].ai[0] = State_Attacking;   //Setting the State of the Add
                    Main.npc[globalnpc.Add[j]].ai[2] = 0;   //carefull -1 or 0!!!!!!!. Resetting timer of the Add
                    Main.npc[globalnpc.Add[j]].localAI[0] = 1;  //Assigning the Attack state of the Add
                    j++;
                }
            }
            if (AI_Timer >= 240)
            {
                AI_State = State_Moving;
                AI_Timer = -1;
            }
        }
        private void LightningStrike(int StrikeCount)
        {
            const int SpawnDelay = 60;
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            Moving();
            int j = 0;
            if (AI_Timer % SpawnDelay == 0)
            {
                while (Main.npc[globalnpc.Add[j]].ai[0] != State_Circling && j < 40)
                {
                    j++;
                }
                Main.npc[globalnpc.Add[j]].ai[0] = State_Attacking;   //Setting the State of the Add
                Main.npc[globalnpc.Add[j]].ai[2] = 0;   //carefull -1 or 0!!!!!!!. Resetting timer of the Add
                Main.npc[globalnpc.Add[j]].localAI[0] = 0;  //Assigning the Attack state of the Add
            }
            if (AI_Timer >= SpawnDelay * (StrikeCount - 1))
            {
                AI_State = State_Moving;
                AI_Timer = -1;
            }
        }
        private void BigDashAttack()
        {
            TrinitarianGlobalNPC globalnpc = npc.GetGlobalNPC<TrinitarianGlobalNPC>();
            if (AI_Timer == 0)
            {
                for (int i = 0; i < AddNumber; i++)
                {
                    Main.npc[globalnpc.Add[i]].ai[0] = State_Attacking;   //Setting the State of the Add
                    Main.npc[globalnpc.Add[i]].ai[2] = 0;   //carefull -1 or 0!!!!!!!. Resetting timer of the Add
                    Main.npc[globalnpc.Add[i]].localAI[0] = 2;  //Assigning the Attack state of the Add
                }
            }
            if (AI_Timer >= 180)
            {
                Dash(200);
            }
            if (AI_Timer >= DashTime + 200 && TimesDashed < MaxDashes)
            {
                AI_Timer = 180;
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
        //Don't like this attack :(
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

            if (AI_Timer == 300)
            {
                if (changedPhase2)
                {
                    AI_State = State_Moving;
                    AI_Timer = -1;
                }
                else
                {
                    AI_State = State_Moving;
                    AI_Timer = -1;
                }
            }
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
