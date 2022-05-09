using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.NPCs.Enemies.Ocean
{
    public class SeaSnake : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Snake");
            Main.npcFrameCount[base.NPC.type] = 1;
        }

        public override void SetDefaults()
        {
            base.NPC.noGravity = true;
            base.NPC.chaseable = false;
            base.NPC.damage = 34;
            base.NPC.width = 50;
            base.NPC.height = 28;
            base.NPC.defense = 12;
            base.NPC.lifeMax = 110;
            base.NPC.aiStyle = -1;
            aiType = -1; ;
            base.NPC.HitSound = SoundID.NPCHit33;
            base.NPC.DeathSound = SoundID.NPCDeath28;
            base.NPC.knockBackResist = 0.3f;
        }

        public override void AI()
        {
            base.NPC.spriteDirection = ((base.NPC.direction > 0) ? 1 : (-1));
            int num = 200;
            if (base.NPC.ai[2] == 0f)
            {
                base.NPC.alpha = num;
                base.NPC.TargetClosest();
                if (!Main.player[base.NPC.target].dead && (Main.player[base.NPC.target].Center - base.NPC.Center).Length() < 170f && Collision.CanHit(base.NPC.position, base.NPC.width, base.NPC.height, Main.player[base.NPC.target].position, Main.player[base.NPC.target].width, Main.player[base.NPC.target].height))
                {
                    base.NPC.ai[2] = -16f;
                }
                if (base.NPC.justHit)
                {
                    base.NPC.ai[2] = -16f;
                }
                if (base.NPC.collideX)
                {
                    base.NPC.velocity.X = base.NPC.velocity.X * -1f;
                    base.NPC.direction *= -1;
                }
                if (base.NPC.collideY)
                {
                    if (base.NPC.velocity.Y > 0f)
                    {
                        base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y) * -1f;
                        base.NPC.directionY = -1;
                        base.NPC.ai[0] = -1f;
                    }
                    else if (base.NPC.velocity.Y < 0f)
                    {
                        base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y);
                        base.NPC.directionY = 1;
                        base.NPC.ai[0] = 1f;
                    }
                }
                base.NPC.velocity.X = base.NPC.velocity.X + (float)base.NPC.direction * 0.02f;
                base.NPC.rotation = base.NPC.velocity.X * 0.4f;
                if (base.NPC.velocity.X < -1f || base.NPC.velocity.X > 1f)
                {
                    base.NPC.velocity.X = base.NPC.velocity.X * 0.95f;
                }
                if (base.NPC.ai[0] == -1f)
                {
                    base.NPC.velocity.Y = base.NPC.velocity.Y - 0.01f;
                    if (base.NPC.velocity.Y < -1f)
                    {
                        base.NPC.ai[0] = 1f;
                    }
                }
                else
                {
                    base.NPC.velocity.Y = base.NPC.velocity.Y + 0.01f;
                    if (base.NPC.velocity.Y > 1f)
                    {
                        base.NPC.ai[0] = -1f;
                    }
                }
                int num2 = (int)(base.NPC.position.X + (float)(base.NPC.width / 2)) / 16;
                int num3 = (int)(base.NPC.position.Y + (float)(base.NPC.height / 2)) / 16;
                if (Framing.GetTileSafely(num2, num3 - 1).LiquidAmount> 128)
                {
                    if (Framing.GetTileSafely(num2, num3 + 1).HasTile)
                    {
                        base.NPC.ai[0] = -1f;
                    }
                    else if (Framing.GetTileSafely(num2, num3 + 2).HasTile)
                    {
                        base.NPC.ai[0] = -1f;
                    }
                }
                else
                {
                    base.NPC.ai[0] = 1f;
                }
                if ((double)base.NPC.velocity.Y > 1.2 || (double)base.NPC.velocity.Y < -1.2)
                {
                    base.NPC.velocity.Y = base.NPC.velocity.Y * 0.99f;
                }
            }
            else if (base.NPC.ai[2] < 0f)
            {
                if (base.NPC.alpha > 0)
                {
                    base.NPC.alpha -= num / 16;
                    if (base.NPC.alpha < 0)
                    {
                        base.NPC.alpha = 0;
                    }
                }
                base.NPC.ai[2] += 1f;
                if (base.NPC.ai[2] == 0f)
                {
                    base.NPC.ai[0] = 0f;
                    base.NPC.ai[2] = 1f;
                    base.NPC.velocity.X = base.NPC.direction * 2;
                }
            }
            else
            {
                if (base.NPC.ai[2] != 1f)
                {
                    return;
                }
                base.NPC.chaseable = true;
                if (base.NPC.direction == 0)
                {
                    base.NPC.TargetClosest();
                }
                if (base.NPC.wet || base.NPC.noTileCollide)
                {
                    bool flag = false;
                    base.NPC.TargetClosest(faceTarget: false);
                    if (Main.player[base.NPC.target].wet && !Main.player[base.NPC.target].dead)
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        if (!Collision.SolidCollision(base.NPC.position, base.NPC.width, base.NPC.height))
                        {
                            base.NPC.noTileCollide = false;
                        }
                        if (base.NPC.collideX)
                        {
                            base.NPC.velocity.X = base.NPC.velocity.X * -1f;
                            base.NPC.direction *= -1;
                            base.NPC.netUpdate = true;
                        }
                        if (base.NPC.collideY)
                        {
                            base.NPC.netUpdate = true;
                            if (base.NPC.velocity.Y > 0f)
                            {
                                base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y) * -1f;
                                base.NPC.directionY = -1;
                                base.NPC.ai[0] = -1f;
                            }
                            else if (base.NPC.velocity.Y < 0f)
                            {
                                base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y);
                                base.NPC.directionY = 1;
                                base.NPC.ai[0] = 1f;
                            }
                        }
                    }
                    if (flag)
                    {
                        if (Collision.CanHit(base.NPC.position, base.NPC.width, base.NPC.height, Main.player[base.NPC.target].position, Main.player[base.NPC.target].width, Main.player[base.NPC.target].height))
                        {
                            if (base.NPC.ai[3] > 0f && !Collision.SolidCollision(base.NPC.position, base.NPC.width, base.NPC.height))
                            {
                                base.NPC.ai[3] = 0f;
                                base.NPC.ai[1] = 0f;
                                base.NPC.netUpdate = true;
                            }
                        }
                        else if (base.NPC.ai[3] == 0f)
                        {
                            base.NPC.ai[1] += 1f;
                        }
                        if (base.NPC.ai[1] >= 150f)
                        {
                            base.NPC.ai[3] = 1f;
                            base.NPC.ai[1] = 0f;
                            base.NPC.netUpdate = true;
                        }
                        if (base.NPC.ai[3] == 0f)
                        {
                            base.NPC.alpha = 0;
                            base.NPC.noTileCollide = false;
                        }
                        else
                        {
                            base.NPC.alpha = 200;
                            base.NPC.noTileCollide = true;
                        }
                        base.NPC.TargetClosest();
                        base.NPC.velocity.X = base.NPC.velocity.X + (float)base.NPC.direction * 0.2f;
                        base.NPC.velocity.Y = base.NPC.velocity.Y + (float)base.NPC.directionY * 0.2f;
                        if (base.NPC.velocity.X > 9f)
                        {
                            base.NPC.velocity.X = 9f;
                        }
                        if (base.NPC.velocity.X < -9f)
                        {
                            base.NPC.velocity.X = -9f;
                        }
                        if (base.NPC.velocity.Y > 7f)
                        {
                            base.NPC.velocity.Y = 7f;
                        }
                        if (base.NPC.velocity.Y < -7f)
                        {
                            base.NPC.velocity.Y = -7f;
                        }
                    }
                    else
                    {
                        if (!Collision.SolidCollision(base.NPC.position, base.NPC.width, base.NPC.height))
                        {
                            base.NPC.noTileCollide = false;
                        }
                        base.NPC.velocity.X = base.NPC.velocity.X + (float)base.NPC.direction * 0.1f;
                        if (base.NPC.velocity.X < -1f || base.NPC.velocity.X > 1f)
                        {
                            base.NPC.velocity.X = base.NPC.velocity.X * 0.95f;
                        }
                        if (base.NPC.ai[0] == -1f)
                        {
                            base.NPC.velocity.Y = base.NPC.velocity.Y - 0.01f;
                            if ((double)base.NPC.velocity.Y < -0.3)
                            {
                                base.NPC.ai[0] = 1f;
                            }
                        }
                        else
                        {
                            base.NPC.velocity.Y = base.NPC.velocity.Y + 0.01f;
                            if ((double)base.NPC.velocity.Y > 0.3)
                            {
                                base.NPC.ai[0] = -1f;
                            }
                        }
                    }
                    int num4 = (int)(base.NPC.position.X + (float)(base.NPC.width / 2)) / 16;
                    int num5 = (int)(base.NPC.position.Y + (float)(base.NPC.height / 2)) / 16;
                    
                    if (Framing.GetTileSafely(num4, num5 - 1).LiquidAmount> 128)
                    {
                        if (Framing.GetTileSafely(num4, num5 + 1).HasTile)
                        {
                            base.NPC.ai[0] = -1f;
                        }
                        else if (Framing.GetTileSafely(num4, num5 + 2).HasTile)
                        {
                            base.NPC.ai[0] = -1f;
                        }
                    }
                    if ((double)base.NPC.velocity.Y > 0.4 || (double)base.NPC.velocity.Y < -0.4)
                    {
                        base.NPC.velocity.Y = base.NPC.velocity.Y * 0.95f;
                    }
                }
                else
                {
                    if (base.NPC.velocity.Y == 0f)
                    {
                        base.NPC.velocity.X = base.NPC.velocity.X * 0.94f;
                        if ((double)base.NPC.velocity.X > -0.2 && (double)base.NPC.velocity.X < 0.2)
                        {
                            base.NPC.velocity.X = 0f;
                        }
                    }
                    base.NPC.velocity.Y = base.NPC.velocity.Y + 0.25f;
                    if (base.NPC.velocity.Y > 7f)
                    {
                        base.NPC.velocity.Y = 7f;
                    }
                    base.NPC.ai[0] = 1f;
                }
                base.NPC.rotation = base.NPC.velocity.Y * (float)base.NPC.direction * 0.1f;
                if ((double)base.NPC.rotation < -0.2)
                {
                    base.NPC.rotation = -0.2f;
                }
                if ((double)base.NPC.rotation > 0.2)
                {
                    base.NPC.rotation = 0.2f;
                }
            }
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            player.AddBuff(BuffID.Venom, 120);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.Ocean.Chance * 0.50f;
            }
            else
            {
                return 0f;
            }
        }
    }
}