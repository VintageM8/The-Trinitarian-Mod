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
            Main.npcFrameCount[base.npc.type] = 1;
        }

        public override void SetDefaults()
        {
            base.npc.noGravity = true;
            base.npc.chaseable = false;
            base.npc.damage = 34;
            base.npc.width = 50;
            base.npc.height = 28;
            base.npc.defense = 12;
            base.npc.lifeMax = 110;
            base.npc.aiStyle = -1;
            aiType = -1; ;
            base.npc.HitSound = SoundID.NPCHit33;
            base.npc.DeathSound = SoundID.NPCDeath28;
            base.npc.knockBackResist = 0.3f;
        }

        public override void AI()
        {
            base.npc.spriteDirection = ((base.npc.direction > 0) ? 1 : (-1));
            int num = 200;
            if (base.npc.ai[2] == 0f)
            {
                base.npc.alpha = num;
                base.npc.TargetClosest();
                if (!Main.player[base.npc.target].dead && (Main.player[base.npc.target].Center - base.npc.Center).Length() < 170f && Collision.CanHit(base.npc.position, base.npc.width, base.npc.height, Main.player[base.npc.target].position, Main.player[base.npc.target].width, Main.player[base.npc.target].height))
                {
                    base.npc.ai[2] = -16f;
                }
                if (base.npc.justHit)
                {
                    base.npc.ai[2] = -16f;
                }
                if (base.npc.collideX)
                {
                    base.npc.velocity.X = base.npc.velocity.X * -1f;
                    base.npc.direction *= -1;
                }
                if (base.npc.collideY)
                {
                    if (base.npc.velocity.Y > 0f)
                    {
                        base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y) * -1f;
                        base.npc.directionY = -1;
                        base.npc.ai[0] = -1f;
                    }
                    else if (base.npc.velocity.Y < 0f)
                    {
                        base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y);
                        base.npc.directionY = 1;
                        base.npc.ai[0] = 1f;
                    }
                }
                base.npc.velocity.X = base.npc.velocity.X + (float)base.npc.direction * 0.02f;
                base.npc.rotation = base.npc.velocity.X * 0.4f;
                if (base.npc.velocity.X < -1f || base.npc.velocity.X > 1f)
                {
                    base.npc.velocity.X = base.npc.velocity.X * 0.95f;
                }
                if (base.npc.ai[0] == -1f)
                {
                    base.npc.velocity.Y = base.npc.velocity.Y - 0.01f;
                    if (base.npc.velocity.Y < -1f)
                    {
                        base.npc.ai[0] = 1f;
                    }
                }
                else
                {
                    base.npc.velocity.Y = base.npc.velocity.Y + 0.01f;
                    if (base.npc.velocity.Y > 1f)
                    {
                        base.npc.ai[0] = -1f;
                    }
                }
                int num2 = (int)(base.npc.position.X + (float)(base.npc.width / 2)) / 16;
                int num3 = (int)(base.npc.position.Y + (float)(base.npc.height / 2)) / 16;
                if (Main.tile[num2, num3 - 1] == null)
                {
                    Main.tile[num2, num3 - 1] = new Tile();
                }
                if (Main.tile[num2, num3 + 1] == null)
                {
                    Main.tile[num2, num3 + 1] = new Tile();
                }
                if (Main.tile[num2, num3 + 2] == null)
                {
                    Main.tile[num2, num3 + 2] = new Tile();
                }
                if (Main.tile[num2, num3 - 1].liquid > 128)
                {
                    if (Main.tile[num2, num3 + 1].active())
                    {
                        base.npc.ai[0] = -1f;
                    }
                    else if (Main.tile[num2, num3 + 2].active())
                    {
                        base.npc.ai[0] = -1f;
                    }
                }
                else
                {
                    base.npc.ai[0] = 1f;
                }
                if ((double)base.npc.velocity.Y > 1.2 || (double)base.npc.velocity.Y < -1.2)
                {
                    base.npc.velocity.Y = base.npc.velocity.Y * 0.99f;
                }
            }
            else if (base.npc.ai[2] < 0f)
            {
                if (base.npc.alpha > 0)
                {
                    base.npc.alpha -= num / 16;
                    if (base.npc.alpha < 0)
                    {
                        base.npc.alpha = 0;
                    }
                }
                base.npc.ai[2] += 1f;
                if (base.npc.ai[2] == 0f)
                {
                    base.npc.ai[0] = 0f;
                    base.npc.ai[2] = 1f;
                    base.npc.velocity.X = base.npc.direction * 2;
                }
            }
            else
            {
                if (base.npc.ai[2] != 1f)
                {
                    return;
                }
                base.npc.chaseable = true;
                if (base.npc.direction == 0)
                {
                    base.npc.TargetClosest();
                }
                if (base.npc.wet || base.npc.noTileCollide)
                {
                    bool flag = false;
                    base.npc.TargetClosest(faceTarget: false);
                    if (Main.player[base.npc.target].wet && !Main.player[base.npc.target].dead)
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        if (!Collision.SolidCollision(base.npc.position, base.npc.width, base.npc.height))
                        {
                            base.npc.noTileCollide = false;
                        }
                        if (base.npc.collideX)
                        {
                            base.npc.velocity.X = base.npc.velocity.X * -1f;
                            base.npc.direction *= -1;
                            base.npc.netUpdate = true;
                        }
                        if (base.npc.collideY)
                        {
                            base.npc.netUpdate = true;
                            if (base.npc.velocity.Y > 0f)
                            {
                                base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y) * -1f;
                                base.npc.directionY = -1;
                                base.npc.ai[0] = -1f;
                            }
                            else if (base.npc.velocity.Y < 0f)
                            {
                                base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y);
                                base.npc.directionY = 1;
                                base.npc.ai[0] = 1f;
                            }
                        }
                    }
                    if (flag)
                    {
                        if (Collision.CanHit(base.npc.position, base.npc.width, base.npc.height, Main.player[base.npc.target].position, Main.player[base.npc.target].width, Main.player[base.npc.target].height))
                        {
                            if (base.npc.ai[3] > 0f && !Collision.SolidCollision(base.npc.position, base.npc.width, base.npc.height))
                            {
                                base.npc.ai[3] = 0f;
                                base.npc.ai[1] = 0f;
                                base.npc.netUpdate = true;
                            }
                        }
                        else if (base.npc.ai[3] == 0f)
                        {
                            base.npc.ai[1] += 1f;
                        }
                        if (base.npc.ai[1] >= 150f)
                        {
                            base.npc.ai[3] = 1f;
                            base.npc.ai[1] = 0f;
                            base.npc.netUpdate = true;
                        }
                        if (base.npc.ai[3] == 0f)
                        {
                            base.npc.alpha = 0;
                            base.npc.noTileCollide = false;
                        }
                        else
                        {
                            base.npc.alpha = 200;
                            base.npc.noTileCollide = true;
                        }
                        base.npc.TargetClosest();
                        base.npc.velocity.X = base.npc.velocity.X + (float)base.npc.direction * 0.2f;
                        base.npc.velocity.Y = base.npc.velocity.Y + (float)base.npc.directionY * 0.2f;
                        if (base.npc.velocity.X > 9f)
                        {
                            base.npc.velocity.X = 9f;
                        }
                        if (base.npc.velocity.X < -9f)
                        {
                            base.npc.velocity.X = -9f;
                        }
                        if (base.npc.velocity.Y > 7f)
                        {
                            base.npc.velocity.Y = 7f;
                        }
                        if (base.npc.velocity.Y < -7f)
                        {
                            base.npc.velocity.Y = -7f;
                        }
                    }
                    else
                    {
                        if (!Collision.SolidCollision(base.npc.position, base.npc.width, base.npc.height))
                        {
                            base.npc.noTileCollide = false;
                        }
                        base.npc.velocity.X = base.npc.velocity.X + (float)base.npc.direction * 0.1f;
                        if (base.npc.velocity.X < -1f || base.npc.velocity.X > 1f)
                        {
                            base.npc.velocity.X = base.npc.velocity.X * 0.95f;
                        }
                        if (base.npc.ai[0] == -1f)
                        {
                            base.npc.velocity.Y = base.npc.velocity.Y - 0.01f;
                            if ((double)base.npc.velocity.Y < -0.3)
                            {
                                base.npc.ai[0] = 1f;
                            }
                        }
                        else
                        {
                            base.npc.velocity.Y = base.npc.velocity.Y + 0.01f;
                            if ((double)base.npc.velocity.Y > 0.3)
                            {
                                base.npc.ai[0] = -1f;
                            }
                        }
                    }
                    int num4 = (int)(base.npc.position.X + (float)(base.npc.width / 2)) / 16;
                    int num5 = (int)(base.npc.position.Y + (float)(base.npc.height / 2)) / 16;
                    if (Main.tile[num4, num5 - 1] == null)
                    {
                        Main.tile[num4, num5 - 1] = new Tile();
                    }
                    if (Main.tile[num4, num5 + 1] == null)
                    {
                        Main.tile[num4, num5 + 1] = new Tile();
                    }
                    if (Main.tile[num4, num5 + 2] == null)
                    {
                        Main.tile[num4, num5 + 2] = new Tile();
                    }
                    if (Main.tile[num4, num5 - 1].liquid > 128)
                    {
                        if (Main.tile[num4, num5 + 1].active())
                        {
                            base.npc.ai[0] = -1f;
                        }
                        else if (Main.tile[num4, num5 + 2].active())
                        {
                            base.npc.ai[0] = -1f;
                        }
                    }
                    if ((double)base.npc.velocity.Y > 0.4 || (double)base.npc.velocity.Y < -0.4)
                    {
                        base.npc.velocity.Y = base.npc.velocity.Y * 0.95f;
                    }
                }
                else
                {
                    if (base.npc.velocity.Y == 0f)
                    {
                        base.npc.velocity.X = base.npc.velocity.X * 0.94f;
                        if ((double)base.npc.velocity.X > -0.2 && (double)base.npc.velocity.X < 0.2)
                        {
                            base.npc.velocity.X = 0f;
                        }
                    }
                    base.npc.velocity.Y = base.npc.velocity.Y + 0.25f;
                    if (base.npc.velocity.Y > 7f)
                    {
                        base.npc.velocity.Y = 7f;
                    }
                    base.npc.ai[0] = 1f;
                }
                base.npc.rotation = base.npc.velocity.Y * (float)base.npc.direction * 0.1f;
                if ((double)base.npc.rotation < -0.2)
                {
                    base.npc.rotation = -0.2f;
                }
                if ((double)base.npc.rotation > 0.2)
                {
                    base.npc.rotation = 0.2f;
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