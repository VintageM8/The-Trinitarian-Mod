using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Items.Bags.Boss;
using Trinitarian.Projectiles;

namespace Trinitarian.NPCs.Bosses.Zolzar
{
    [AutoloadBossHead]
    public class VikingBossP2 : ModNPC
    {
        private bool changedPhase2 = false;
        private int StopHeal = 0;
        bool npcDashing = false;
        int spriteDirectionStore = 0;
        private bool Dashing = false;

        bool leafatt = false;

        bool dead = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar, God of Demise");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            // Afterimage effect
            NPCID.Sets.TrailCacheLength[npc.type] = 7;
            NPCID.Sets.TrailingMode[npc.type] = 1;

            // Reduced size
            npc.width = 368;
            npc.height = 338;

            // Actual dimensions
            //npc.width = 368;
            //npc.height = 338;

            npc.aiStyle = -1;
            npc.damage = 195;
            npc.defense = 52;
            npc.lifeMax = 24500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.Item25;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            npc.value = Item.buyPrice(gold: 3);
            npc.npcSlots = 10f;
            music = MusicID.Boss5;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/TreeBoss");
            bossBag = ModContent.ItemType<IceBossBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale * 0.65f);
            npc.defense = 17;
        }

        private void BossText(string text) // boss messages
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, Color.Blue);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), Color.Blue);
            }
        }

        int RandomCase = 0;
        int LastCase = 0;
        int RandomCeiling;
        bool movement = true;

        public override void AI()
        {
            StopHeal--;
            // Death animation code
            if (npc.ai[3] > 0f)
            {
                npc.velocity = Vector2.Zero;

                if (npc.ai[2] > 0)
                {
                    npc.ai[2]--;

                    if (npc.ai[2] == 480)
                    {
                        BossText("I deem thee fit to inherit their powers.");
                    }

                    if (npc.ai[2] == 300)
                    {
                        BossText("Thou Dryad shalt guide thee.");
                    }

                    if (npc.ai[2] == 120)
                    {
                        BossText("Fare thee well.");
                    }
                }
                else
                {
                    npc.dontTakeDamage = true;
                    npc.ai[3]++; // Death timer
                    npc.velocity.X *= 0.95f;

                    if (npc.velocity.Y < 0.5f)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.01f;
                    }

                    if (npc.velocity.X > 0.5f)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.01f;
                    }

                    if (npc.ai[3] > 120f)
                    {
                        npc.Opacity = 1f - (npc.ai[3] - 120f) / 60f;
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
                    if (npc.ai[3] >= 180f)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 0);
                        npc.checkDead(); // This will trigger ModNPC.CheckDead the second time, causing the real death.
                    }
                }
                return;
            }

            npc.TargetClosest(true);
            Player player = Main.player[npc.target];

            npc.spriteDirection = npc.direction;

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
                npc.velocity.Y = -2000;
            }

            if (npc.life > npc.lifeMax)
            {
                npc.life = npc.lifeMax;
            }

            npc.ai[1]++;

            if (npc.life <= npc.lifeMax * 0.5f)
            {
                changedPhase2 = true;
            }

            switch (npc.ai[0])
            {
                case -1: // case switching
                    {
                        if (movement == true)
                        {
                            if (changedPhase2 == true) { RandomCeiling = 4; }
                            else { RandomCeiling = 3; }
                            while (RandomCase == LastCase)
                            {
                                RandomCase = Main.rand.Next(1, RandomCeiling);
                            }
                            LastCase = RandomCase;
                            movement = false;
                            npc.ai[0] = RandomCase;
                        }
                        else
                        {
                            movement = true;
                            npc.ai[0] = 0;
                        }
                    }
                    break;
                case 0: // Follow player
                    if (npc.ai[0] == 0)
                    {
                        Vector2 moveTo = player.Center;
                        var move = moveTo - npc.Center;
                        var speed = 5;

                        float length = move.Length();
                        if (length > speed)
                        {
                            move *= speed / length;
                        }
                        var turnResistance = 45;
                        move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
                        length = move.Length();
                        if (length > 10)
                        {
                            move *= speed / length;
                        }
                        npc.velocity.X = move.X;
                        npc.velocity.Y = move.Y * .98f;

                        if (npc.ai[1] > (changedPhase2 ? 90 : 120))
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                        }
                    }
                    break;
                case 1: // Shoot scythes
                    if (npc.ai[0] == 1)
                    {
                        Vector2 moveTo = player.Center;
                        var move = moveTo - npc.Center;
                        var speed = 5;

                        float length = move.Length();
                        if (length > speed)
                        {
                            move *= speed / length;
                        }
                        var turnResistance = 45;
                        move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
                        length = move.Length();
                        if (length > 10)
                        {
                            move *= speed / length;
                        }
                        npc.velocity.X = move.X;
                        npc.velocity.Y = move.Y * .98f;

                        if (npc.ai[1] % 90 == 0)
                        {
                            int shootSpeed = Main.rand.Next(8, 12);
                            Vector2 position = npc.Center;
                            Vector2 targetPosition = Main.player[npc.target].Center;
                            Vector2 direction = targetPosition - position;
                            direction.Normalize();
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(npc.Center, direction * shootSpeed, ProjectileID.CultistBossIceMist, npc.damage / 2, 3f, Main.myPlayer, 0, 0);
                            }
                        }

                        if (npc.ai[1] > 600)
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                        }
                    }
                    break;
                case 2: // Absorb energy
                    npc.velocity = Vector2.Zero;
                    if (StopHeal > 1)
                    {
                        npc.ai[0] = -1;
                    }
                    // Summon projectiles from off-screen that move towards the boss
                    if (npc.ai[1] % 20 == 0)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            float randPositionX = npc.Center.X + Main.rand.Next(-10, 10) * 600;
                            float randPositionY = npc.Center.Y + Main.rand.Next(-10, 10) * 600;
                            npc.netUpdate = true;
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(new Vector2(randPositionX, randPositionY), new Vector2(0, 0), ProjectileID.PhantasmalEye, npc.damage / 3, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            }
                        }
                    }

                    if (npc.ai[1] > 660)
                    {
                        StopHeal = 7500;
                        npc.ai[0] = 4;
                        npc.ai[1] = 0;
                    }
                    break;
                case 4: // Shoot Lightning shit
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
                    if (npc.ai[1] > 240)
                    {
                        npc.ai[0] = -1;
                        npc.ai[1] = 0;
                    }
                    break;
                case 3: // scythes
                    {
                        Vector2 moveTo = player.Center;
                        moveTo.X += 50 * (npc.Center.X < moveTo.X ? -1 : 1);
                        var move = moveTo - npc.Center;
                        var speed = 1;

                        float length = move.Length();
                        if (length > speed)
                        {
                            move *= speed / length;
                        }
                        var turnResistance = 45;
                        move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
                        length = move.Length();
                        if (length > 10)
                        {
                            move *= speed / length;
                        }
                        npc.velocity.X = move.X;
                        npc.velocity.Y = move.Y * .98f;
                        if (npc.ai[1] == 180)
                        {
                            if (npc.spriteDirection == 1)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        float ProjectileSpawnX = npc.Center.X + 150 + (333 * i);
                                        Projectile.NewProjectile(new Vector2(ProjectileSpawnX, npc.TopLeft.Y - 50), Vector2.UnitY * 5, ProjectileID.CultistBossLightningOrb, 17, 1f, Main.myPlayer, 0, 1);
                                        Projectile.NewProjectile(new Vector2(ProjectileSpawnX, npc.BottomLeft.Y + 50), -Vector2.UnitY * 5, ProjectileID.CultistBossLightningOrb, 17, 1f, Main.myPlayer, 0, 1);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        float ProjectileSpawnX = npc.Center.X - 150 - (333 * i);
                                        Projectile.NewProjectile(new Vector2(ProjectileSpawnX, npc.TopRight.Y - 50), Vector2.UnitY * 5, ProjectileID.CultistBossLightningOrb, 17, 1f, Main.myPlayer, 0, 1);
                                        Projectile.NewProjectile(new Vector2(ProjectileSpawnX, npc.BottomRight.Y + 50), -Vector2.UnitY * 5, ProjectileID.CultistBossLightningOrb, 17, 1f, Main.myPlayer, 0, 1);
                                    }
                                }
                            }
                        }
                        if (npc.ai[1] > 540)
                        {
                            npc.ai[0] = 0;
                            npc.ai[1] = 0;
                        }
                        break;
                    }
            }
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
            if (npc.frame.Y >= frameHeight * 9) // 10 is max # of frames
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
            if (npc.ai[3] == 0f)
            {
                npc.ai[2] = 0;
                dead = true;
                npc.ai[3] = 1f;
                npc.damage = 0;
                npc.life = npc.lifeMax;
                npc.dontTakeDamage = true;
                npc.netUpdate = true;
                return false;
            }
            return true;
        }

        public override void NPCLoot()
        {
            //void
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
        }
    }
}