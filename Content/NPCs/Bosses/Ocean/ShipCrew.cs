using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Projectiles.Boss.Ocean;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.NPCs.Bosses.Ocean
{
    public class ShipCrew : ModNPC
    {
        private int moveSpeed;
        public bool kill = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Fallen Crew");
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 38;
            npc.damage = 22;
            npc.defense = 35;
            npc.lifeMax = 450;
            npc.HitSound = SoundID.NPCHit4;
            npc.knockBackResist = 0.4f;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];

            if (npc.lifeMax > 60 || npc.life > 60)
            {
                npc.lifeMax = 60;
                npc.life = 60;
            }

            switch (npc.ai[0])
            {
                case 0:
                    {
                        if (!PlayerAlive(player)) { break; }

                        if (npc.ai[3] == 0)
                        {
                            moveSpeed = Main.rand.Next(5, 10);
                            npc.ai[3]++;
                        }

                        Vector2 moveTo = player.Center;
                        var move = moveTo - npc.Center;

                        float length = move.Length();
                        if (length > moveSpeed)
                        {
                            move *= moveSpeed / length;
                        }
                        var turnResistance = 45;
                        move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
                        length = move.Length();
                        if (length > 10)
                        {
                            move *= moveSpeed / length;
                        }
                        npc.velocity.X = move.X;
                        npc.velocity.Y = move.Y * .98f;

                        if (++npc.ai[1] > 600 + Main.rand.Next(100) && npc.ai[2] == 1)
                        {
                            npc.ai[1] = 0;
                            npc.ai[0] = 1;
                        }
                    }
                    break;
                case 1:
                    {
                        if (!PlayerAlive(player)) { break; }

                        npc.velocity = Vector2.Zero;

                        if (++npc.ai[1] % 60 == 0)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(npc.Center, npc.DirectionTo(player.Center) * 7.5f, ProjectileType<Bubble>(), npc.damage, 10f, Main.myPlayer);
                            }
                            npc.ai[2]++;
                        }

                        if (npc.ai[2] == 1)
                        {
                            npc.ai[2] = 0;
                            npc.ai[1] = 0;
                            npc.ai[0] = 0;
                        }
                    }
                    break;

            }
            if (kill == true)
            {
                npc.active = false;
                npc.life = 0;
            }
        }

        bool PlayerAlive(Player player)
        {
            if (!player.active || player.dead)
            {
                player = Main.player[npc.target];
                npc.TargetClosest();
                if (!player.active || player.dead)
                {
                    if (npc.timeLeft > 25)
                    {
                        npc.timeLeft = 25;
                        npc.velocity = Vector2.UnitY * -7;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}