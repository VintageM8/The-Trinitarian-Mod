using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Projectiles.Melee;
using Trinitarian.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Items.Bags.Boss;
using System.IO;
using Terraria.Localization;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;

namespace Trinitarian.NPCs.Bosses.Zolzar
{
    [AutoloadBossHead]
    public class VikingBoss : ModNPC
    {
        int spritetimer = 0;
        int frame = 1;
        int attackCounter = 0;
        Vector2 teleportPosition = Vector2.Zero;
        bool changedPhase2 = false;
        bool changedPhase2Indicator = false;
        private int bufferCount = 0;

        int Direction = -1;
        bool direction = true;

        int RandomCase = 0;
        int LastCase = 4;
        int RandomCeiling;
        bool movement = true;

        bool npcDashing = false;
        int spriteDirectionStore = 0;
        private bool Dashing = false;
        private int myProjectileStore;
        private int myProjectileStore2;

        bool dead = false;
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
            if (!TrinitarianWorld.downedViking)
            {
                npc.dontTakeDamage = true;
                npc.netUpdate = true;
                npc.ai[3]++;
                if (npc.ai[3] <= 600)
                {
                    return;
                }
                else
                {
                    npc.dontTakeDamage = false;
                    npc.netUpdate = true;
                }
            }

            Player player = Main.player[npc.target];

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

            if (npc.life <= npc.lifeMax * 0.5f)
            {
                changedPhase2 = true;
            }

            if (npc.ai[3] == 90)
            {
                Main.PlaySound(new Terraria.Audio.LegacySoundStyle(SoundID.NPCKilled, 10), npc.Center); // every half second while dying, play a sound
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    float distance = Vector2.Distance(npc.Center, Main.player[i].Center);
                    if (distance <= 600)
                    {
                        Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 30;
                    }
                }
            }

            switch (npc.ai[0])
            {
                case 0: // General case
                    // Do nothing
                    if (npc.ai[1] == 30)
                    {
                        int randCeiling = npc.life <= npc.lifeMax * 0.5f ? 3 : 5;
                        int waveChance = Main.expertMode ? Main.rand.Next(0, randCeiling) : -1;

                        if (changedPhase2)
                        {
                            if (waveChance != -1) // Expert mode version
                            {
                                if (waveChance == 0)
                                {
                                    npc.ai[0] = 4;
                                    npc.ai[1] = 0;
                                }
                                else
                                {
                                    npc.ai[0] = 2;
                                    npc.ai[1] = 0;
                                }
                            }
                            else // Default Non-expert mode version
                            {
                                npc.ai[0] = 2;
                                npc.ai[1] = 0;
                            }
                        }
                        else
                        {
                            if (waveChance != -1) // Expert mode version
                            {
                                if (waveChance == 0)
                                {
                                    npc.ai[0] = 4;
                                    npc.ai[1] = 0;
                                }
                                else
                                {
                                    npc.ai[0] = 2;
                                    npc.ai[1] = 0;
                                }
                            }
                            else // Default Non-expert mode version
                            {
                                npc.ai[0] = 2;
                                npc.ai[1] = 0;
                            }
                        }
                    }
                    break;
                case 1: // Spawn thorns
                    if (npc.ai[1] % 60 == 0 && npc.ai[1] < 240)
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

                    if (npc.ai[1] == 240)
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

                    if (npc.ai[1] == 300)
                    {
                        npc.ai[0] = 0;
                        npc.ai[1] = 1;
                    }
                    break;
                case 2: // Shoot seeds
                    if (npc.ai[1] % 75 == 0)
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

                    if (npc.ai[1] == 300)
                    {
                        if (changedPhase2)
                        {
                            npc.ai[0] = 3;
                            npc.ai[1] = 0;
                        }
                        else
                        {
                            npc.ai[0] = 1;
                            npc.ai[1] = 0;
                        }
                    }
                    break;
                case 3: // Multiple thorns
                    if (npc.ai[1] % 120 == 0)
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

                    if (npc.ai[1] == 320)
                    {
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                    }
                    break;
                case 4: // Thorns wave
                    if (npc.ai[1] % 15 == 0)
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

                    if (npc.ai[1] == 180)
                    {
                        npc.ai[0] = 2;
                        npc.ai[1] = 0;

                        bufferCount = 0;
                    }
                    break;
            }

            npc.ai[1]++;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/Bosses/Zolzar/VikingBoss");
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
