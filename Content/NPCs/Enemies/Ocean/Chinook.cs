using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.NPCs.Enemies.Ocean
{
    public class Chinook : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chinook");
            Main.npcFrameCount[NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 30;
            NPC.defense = 1;
            NPC.damage = 10;
            NPC.lifeMax = 120;
            NPC.HitSound = SoundID.NPCHit38;
            NPC.DeathSound = SoundID.NPCDeath41;
            NPC.value = 25f;
            NPC.aiStyle = -1;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Ocean.Chance * 0.50f;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            
        }


        private float speed = 7f;
        private float speedY = 4f;
        private float acceleration = 0.25f;
        private float accelerationY = 0.2f;
        private float correction = 0.95f;
        private bool targetDryPlayer = true;
        private float idleSpeed = 2f;
        private bool bounces = true;

        public override void AI()
        {
            if (NPC.direction == 0)
            {
                NPC.TargetClosest(true);
            }
            if (NPC.wet)
            {
                bool flag30 = false;
                NPC.TargetClosest(false);
                if (Main.player[NPC.target].wet && !Main.player[NPC.target].dead)
                {
                    flag30 = true;
                }
                if (!flag30)
                {
                    if (NPC.collideX)
                    {
                        NPC.velocity.X *= -1f;
                        NPC.direction *= -1;
                        NPC.netUpdate = true;
                    }
                    if (NPC.collideY)
                    {
                        NPC.netUpdate = true;
                        if (NPC.velocity.Y > 0f)
                        {
                            NPC.velocity.Y = -NPC.velocity.Y;
                            NPC.directionY = -1;
                            NPC.ai[0] = -1f;
                        }
                        else if (NPC.velocity.Y < 0f)
                        {
                            NPC.velocity.Y = -NPC.velocity.Y;
                            NPC.directionY = 1;
                            NPC.ai[0] = 1f;
                        }
                    }
                }
                if (flag30)
                {
                    NPC.TargetClosest(true);
                    if (NPC.velocity.X * NPC.direction < 0f)
                    {
                        NPC.velocity.X *= correction;
                    }
                    NPC.velocity.X += NPC.direction * acceleration;
                    NPC.velocity.Y += NPC.directionY * accelerationY;
                    if (NPC.velocity.X > speed)
                    {
                        NPC.velocity.X = speed;
                    }
                    if (NPC.velocity.X < -speed)
                    {
                        NPC.velocity.X = -speed;
                    }
                    if (NPC.velocity.Y > speedY)
                    {
                        NPC.velocity.Y = speedY;
                    }
                    if (NPC.velocity.Y < -speedY)
                    {
                        NPC.velocity.Y = -speedY;
                    }
                }
                else
                {
                    if (targetDryPlayer)
                    {
                        if (Main.player[NPC.target].position.Y > NPC.position.Y)
                        {
                            NPC.directionY = 1;
                        }
                        else
                        {
                            NPC.directionY = -1;
                        }
                        NPC.velocity.X += (float)NPC.direction * 0.1f * idleSpeed;
                        if (NPC.velocity.X < -idleSpeed || NPC.velocity.X > idleSpeed)
                        {
                            NPC.velocity.X *= 0.95f;
                        }
                        if (NPC.ai[0] == -1f)
                        {
                            float num356 = -0.3f * idleSpeed;
                            if (NPC.directionY < 0)
                            {
                                num356 = -0.5f * idleSpeed;
                            }
                            if (NPC.directionY > 0)
                            {
                                num356 = -0.1f * idleSpeed;
                            }
                            NPC.velocity.Y -= 0.01f * idleSpeed;
                            if (NPC.velocity.Y < num356)
                            {
                                NPC.ai[0] = 1f;
                            }
                        }
                        else
                        {
                            float num357 = 0.3f * idleSpeed;
                            if (NPC.directionY < 0)
                            {
                                num357 = 0.1f * idleSpeed;
                            }
                            if (NPC.directionY > 0)
                            {
                                num357 = 0.5f * idleSpeed;
                            }
                            NPC.velocity.Y += 0.01f * idleSpeed;
                            if (NPC.velocity.Y > num357)
                            {
                                NPC.ai[0] = -1f;
                            }
                        }
                    }
                    else
                    {
                        NPC.velocity.X += (float)NPC.direction * 0.1f * idleSpeed;
                        if (NPC.velocity.X < -idleSpeed || NPC.velocity.X > idleSpeed)
                        {
                            NPC.velocity.X *= 0.95f;
                        }
                        if (NPC.ai[0] == -1f)
                        {
                            NPC.velocity.Y -= 0.01f * idleSpeed;
                            if ((double)NPC.velocity.Y < -0.3)
                            {
                                NPC.ai[0] = 1f;
                            }
                        }
                        else
                        {
                            NPC.velocity.Y += 0.01f * idleSpeed;
                            if ((double)NPC.velocity.Y > 0.3)
                            {
                                NPC.ai[0] = -1f;
                            }
                        }
                    }
                    int num358 = (int)(NPC.position.X + (float)(NPC.width / 2)) / 16;
                    int num359 = (int)(NPC.position.Y + (float)(NPC.height / 2)) / 16;
                    if (Main.tile[num358, num359 - 1] == null)
                    {
                        Main.tile[num358, num359 - 1] = new Tile();
                    }
                    if (Main.tile[num358, num359 + 1] == null)
                    {
                        Main.tile[num358, num359 + 1] = new Tile();
                    }
                    if (Main.tile[num358, num359 + 2] == null)
                    {
                        Main.tile[num358, num359 + 2] = new Tile();
                    }
                    if (Main.tile[num358, num359 - 1].liquid > 128)
                    {
                        if (Main.tile[num358, num359 + 1].HasTile)
                        {
                            NPC.ai[0] = -1f;
                        }
                        else if (Main.tile[num358, num359 + 2].HasTile)
                        {
                            NPC.ai[0] = -1f;
                        }
                    }
                    if (!targetDryPlayer && ((double)NPC.velocity.Y > 0.4 || (double)NPC.velocity.Y < -0.4))
                    {
                        NPC.velocity.Y *= 0.95f;
                    }
                }
            }
            else
            {
                if (NPC.velocity.Y == 0f)
                {
                    if (!bounces)
                    {
                        NPC.velocity.X *= 0.94f;
                        if ((double)NPC.velocity.X > -0.2 && (double)NPC.velocity.X < 0.2)
                        {
                            NPC.velocity.X = 0f;
                        }
                    }
                    else if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        NPC.velocity.Y = (float)Main.rand.Next(-50, -20) * 0.1f;
                        NPC.velocity.X = (float)Main.rand.Next(-20, 20) * 0.1f;
                        NPC.netUpdate = true;
                    }
                }
                NPC.velocity.Y += 0.3f;
                if (NPC.velocity.Y > 10f)
                {
                    NPC.velocity.Y = 10f;
                }
                NPC.ai[0] = 1f;
            }
            NPC.rotation = NPC.velocity.Y * (float)NPC.direction * 0.1f;
            if ((double)NPC.rotation < -0.2)
            {
                NPC.rotation = -0.2f;
            }
            if ((double)NPC.rotation > 0.2)
            {
                NPC.rotation = 0.2f;
            }
        }


        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            /*npc.frameCounter += 1.0;
			if (npc.wet)
			{
				npc.frameCounter %= 24.0;
				npc.frame.Y = frameHeight * (int)(npc.frameCounter / 6.0);
			}
			else
			{
				npc.frameCounter %= 12.0;
				if (npc.frameCounter < 6.0)
				{
					npc.frame.Y = frameHeight * 4;
				}
				else
				{
					npc.frame.Y = frameHeight * 5;
				}
			}*/
        }
    }
}