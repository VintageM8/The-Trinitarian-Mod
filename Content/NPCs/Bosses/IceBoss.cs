using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Bags.Boss;
using Trinitarian.Content.Projectiles.Boss.Ice;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee;
using Trinitarian.Content.Items.Weapons.PreHardmode.Ranged;

namespace Trinitarian.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class IceBoss : ModNPC
    {
        private bool doDustAttack = false;
        private Vector2 rotationCenter;
        private int enrageTimer;
        private bool enraged;
        bool movingup = true;
        bool leftofplayer = true;
        bool halflife = false;
        bool fourthlife = false;
        bool circleactive = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Njor, the Frozen Elemental");
            Main.npcFrameCount[NPC.type] = 18;
        }

        public override void SetDefaults()
        {
            NPC.width = 136;
            NPC.height = 112;
            NPC.aiStyle = -1;
            NPC.damage = 15;
            NPC.defense = 12;
            NPC.lifeMax = 4300;
            NPC.HitSound = SoundID.NPCHit23;
            NPC.DeathSound = SoundID.NPCDeath39;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.boss = true;
            NPC.npcSlots = 10f;
            //music = MusicID.Boss5;
            music = Mod.GetSoundSlot(SoundType.Music, "Sounds/Music/NjorsTheme");
            bossBag = ModContent.ItemType<IceBossBag>();
        }

        public override void AI()
        {
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];

            NPC.spriteDirection = NPC.direction;

            if (NPC.life <= NPC.lifeMax * 0.5f) { halflife = true; }
            if (NPC.life <= NPC.lifeMax * 0.25f) { fourthlife = true; }
            if (NPC.ai[0] == 1 && fourthlife) { circleactive = true; }
            else { circleactive = false; }

            // Handles Despawning
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }

            if (!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                NPC.velocity.Y = 2000;
            }

            if (!player.ZoneSnow)
            {
                if (enrageTimer == 120)
                {
                    enraged = true;
                }
                else
                {
                    enraged = false;
                    enrageTimer++;
                }
            }
            else
            {
                enraged = false;
                enrageTimer = 0;
            }

            if (NPC.ai[0] == 3)
            {
                NPC.ai[1] += 10f;
            }
            else
            {
                NPC.ai[1]++;
            }

            if (NPC.ai[0] == 2 || NPC.ai[0] == 3 || circleactive == true)
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
            }

            switch (NPC.ai[0])
            {
                case 0: // General case: Move towards player
                    if (!player.ZoneSnow && enraged)
                    {
                        NPC.ai[0] = 1.5f;
                        NPC.ai[1] = 0;
                        NPC.ai[2] = 900;
                        break;
                    }

                    Vector2 moveTo = player.Center;
                    var move = moveTo - NPC.Center;
                    var speed = 5;

                    float length = move.Length();
                    if (length > speed)
                    {
                        move *= speed / length;
                    }
                    var turnResistance = 45;
                    move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
                    length = move.Length();
                    if (length > 10)
                    {
                        move *= speed / length;
                    }
                    NPC.velocity.X = move.X;
                    NPC.velocity.Y = move.Y * .98f;

                    /*
                    if(npc.ai[1] == 10) EZ CODE TESTER FOR ATTACKS
                    {
                        npc.ai[0] = 3;
                        npc.ai[1] = 0;
                    }*/
                    if (NPC.ai[1] == 360)
                    {
                        if (doDustAttack)
                        {
                            NPC.ai[0] = 1.5f;
                            NPC.ai[1] = 0;
                            NPC.ai[2] = 900;
                            doDustAttack = false;
                        }
                        else
                        {
                            NPC.ai[0] = 1f;
                            NPC.ai[1] = 0;
                        }
                    }
                    break;
                case 1: // Spawn random shit from off screen
                    if (!player.ZoneSnow && enraged)
                    {
                        NPC.ai[0] = 1.5f;
                        NPC.ai[1] = 0;
                        NPC.ai[2] = 900;
                        break;
                    }
                    if (fourthlife == false)
                    {
                        NPC.velocity = Vector2.Zero;

                        if (NPC.ai[1] % 60 == 0)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                for (int i = 0; i < Main.rand.Next(3, 6); i++)
                                {
                                    NPC.netUpdate = true;
                                    Projectile.NewProjectile(new Vector2(player.Center.X + Main.rand.Next(1200, 1500), NPC.Center.Y + Main.rand.Next(-360, 360)), new Vector2(Main.rand.Next(-11, -6), 0), ModContent.ProjectileType<FrozenCluster>(), NPC.damage / (Main.expertMode ? 4 : 2), 0f, Main.myPlayer);
                                }

                                if (NPC.life <= NPC.lifeMax * 0.5f)
                                {
                                    for (int i = 0; i < Main.rand.Next(3, 6); i++)
                                    {
                                        NPC.netUpdate = true;
                                        Projectile.NewProjectile(new Vector2(player.Center.X - Main.rand.Next(1200, 1500), NPC.Center.Y + Main.rand.Next(-360, 360)), new Vector2(Main.rand.Next(6, 11), 0), ModContent.ProjectileType<FrozenCluster>(), NPC.damage / (Main.expertMode ? 4 : 2), 0f, Main.myPlayer);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (NPC.ai[1] == 1)
                        {
                            NPC.hide = true;
                            NPC.width = 68;
                            NPC.height = 56;
                            //playercentersnapshot = player.Center;
                        }

                        if (NPC.ai[2]++ > 0 && NPC.ai[1] > 2)
                        {
                            NPC.position = /*playercentersnapshot*/ player.Center + new Vector2(-475, 0).RotatedBy(MathHelper.ToRadians(4 * NPC.ai[3]));
                            NPC.position.X -= NPC.width / 2;
                            NPC.position.Y -= NPC.height / 2;
                            NPC.ai[3]++;
                            NPC.ai[2] = 0;
                        }

                        if (NPC.ai[1] % /*30*/15 == 0)
                        {
                            Projectile.NewProjectileDirect(NPC.Center, NPC.DirectionTo(/*playercentersnapshot*/player.Center) * 7.5f, ModContent.ProjectileType<FrozenCluster>(), NPC.damage / (Main.expertMode ? 4 : 2), 0, Main.myPlayer, 0, NPC.ai[3]);
                        }
                    }

                    if (NPC.ai[1] == 600)
                    {
                        if (!doDustAttack)
                        {
                            doDustAttack = true;
                        }
                        NPC.hide = false;
                        NPC.width = 136;
                        NPC.height = 112;
                        NPC.ai[0] = 0f;
                        NPC.ai[1] = 0;
                    }
                    break;
                case 1.5f: // Do dust swirl animation
                    NPC.velocity = Vector2.Zero;

                    for (int i = 0; i < 18; i++)
                    {
                        Vector2 dustPos = NPC.Center + new Vector2(NPC.ai[2], 0).RotatedBy(MathHelper.ToRadians(i * 20 + NPC.ai[1]));
                        Dust dust = Main.dust[Dust.NewDust(dustPos, 15, 15, DustID.Snow, 0f, 0f, 0, default, 2.04f)];
                        dust.noGravity = true;
                    }

                    NPC.ai[2] -= 15;

                    if (NPC.ai[2] == 0)
                    {
                        NPC.ai[0] = 2;
                        NPC.ai[1] = 0;
                        NPC.ai[2] = 0;
                    }
                    break;
                case 2: // Turn into dust cloud
                    NPC.hide = true;

                    if (NPC.ai[2] == (Main.expertMode ? 50 : 66))
                    {
                        NPC.velocity = Vector2.Zero;
                    }

                    NPC.width = 68;
                    NPC.height = 56;
                    if (NPC.ai[1] <= 600)
                    {
                        if (NPC.ai[2] <= 0)
                        {
                            float chargeSpeed = !player.ZoneSnow ? 30 : 22;
                            move = player.Center - NPC.Center;
                            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                            move *= chargeSpeed / magnitude;
                            NPC.velocity = move;
                            NPC.netUpdate = true;
                            if (!player.ZoneSnow)
                            {
                                NPC.ai[2] = 40;
                            }
                            else
                            {
                                NPC.ai[2] = 80; // charging delay
                            }
                        }
                        NPC.ai[2] -= 1f;
                        if (NPC.ai[1] == 600)
                        {
                            NPC.ai[2] = -100;
                        }
                    }
                    else if (halflife == true)
                    {
                        if (NPC.ai[2] == -100)
                        {
                            leftofplayer = Main.rand.NextBool();
                            NPC.ai[2] = 0;
                        }
                        if (leftofplayer == true)
                        {
                            if (NPC.ai[2] == 1)
                            {
                                NPC.Teleport(player.Center + new Vector2(-700, (NPC.height / 2) - 90), 32);
                                NPC.velocity = Vector2.Zero;
                            }
                            if (NPC.ai[2] % 30 == 0)
                            {
                                if (movingup == true)
                                {
                                    NPC.velocity = new Vector2(Main.rand.Next(10, 13), Main.rand.Next(-13, -10));
                                    movingup = false;
                                }
                                else
                                {
                                    NPC.velocity = new Vector2(Main.rand.Next(10, 13), Main.rand.Next(10, 13));
                                    movingup = true;
                                }
                            }
                            if (NPC.ai[2] == 150)
                            {
                                NPC.ai[2] = 0;
                                leftofplayer = false;
                            }
                        }
                        else
                        {
                            if (NPC.ai[2] == 1)
                            {
                                NPC.Teleport(player.Center + new Vector2(700, (NPC.height / 2) - 90), 32);
                                NPC.velocity = Vector2.Zero;
                            }
                            if (NPC.ai[2] % 30 == 0)
                            {
                                if (movingup == true)
                                {
                                    NPC.velocity = new Vector2(Main.rand.Next(-13, -10), Main.rand.Next(-13, -10));
                                    movingup = false;
                                }
                                else
                                {
                                    NPC.velocity = new Vector2(Main.rand.Next(-13, -10), Main.rand.Next(10, 13));
                                    movingup = true;
                                }
                            }
                            if (NPC.ai[2] == 150)
                            {
                                NPC.ai[2] = 0;
                                leftofplayer = true;
                            }
                        }
                        NPC.ai[2] += 1f;
                    }

                    if (NPC.ai[1] == (halflife ? 900 : 600))
                    {
                        if (player.ZoneSnow)
                        {
                            NPC.width = 136;
                            NPC.height = 112;

                            NPC.velocity = Vector2.Zero;
                            NPC.hide = false;

                            NPC.ai[2] = 0;

                            if (Main.expertMode)
                            {
                                NPC.ai[0] = 3;
                                NPC.ai[1] = 0;
                            }
                            else
                            {
                                NPC.ai[0] = 0;
                                NPC.ai[1] = 0;
                            }
                        }
                        else
                        {
                            NPC.ai[0] = 2;
                            NPC.ai[1] = 0;
                        }
                    }
                    break;
                case 3: // Spin in a circle

                    // Get center to spin around
                    if (NPC.ai[1] == 10)
                    {
                        rotationCenter = new Vector2(NPC.Center.X + 50, NPC.Center.Y);
                    }

                    double deg = (double)NPC.ai[1];
                    double rad = deg * (Math.PI / 180); //Convert degrees to radians
                    double dist = 50; //Distance away from the player

                    NPC.position.X = rotationCenter.X - (int)(Math.Cos(rad) * dist) - NPC.width / 2;
                    NPC.position.Y = rotationCenter.Y - (int)(Math.Sin(rad) * dist) - NPC.height / 2;

                    if (NPC.ai[1] % 50 == 0)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Projectile.NewProjectile(NPC.Center, Vector2.One.RotatedByRandom(Math.PI) * 6, ModContent.ProjectileType<FrozenCluster>(), NPC.damage / 4, 0f, Main.myPlayer);
                            }
                        }
                    }
                    // Move the NPC around the center
                    if (NPC.ai[1] == 2400)
                    {
                        NPC.ai[0] = 0;
                        NPC.ai[1] = 0;
                    }
                    break;
                    /*case 4:
                        {
                            if (leftofplayer == true)
                            {
                                if (npc.ai[1] == 1)
                                {
                                    npc.Teleport(player.Center + Vector2.UnitX * -700);
                                    npc.velocity = Vector2.Zero;
                                }
                                if (npc.ai[1] % 30 == 0)
                                {
                                    if (movingup == true)
                                    {
                                        npc.velocity = new Vector2(Main.rand.Next(10, 13), Main.rand.Next(-13, -10));
                                        movingup = false;
                                    }
                                    else
                                    {
                                        npc.velocity = new Vector2(Main.rand.Next(10, 13), Main.rand.Next(10, 13));
                                        movingup = true;
                                    }
                                }
                                if (npc.ai[1] == 150)
                                {
                                    npc.ai[1] = 0;
                                    leftofplayer = false;
                                }
                            }
                            else
                            {
                                if (npc.ai[1] == 1)
                                {
                                    npc.Teleport(player.Center + Vector2.UnitX * 700);
                                    npc.velocity = Vector2.Zero;
                                }
                                if (npc.ai[1] % 30 == 0)
                                {
                                    if (movingup == true)
                                    {
                                        npc.velocity = new Vector2(Main.rand.Next(-13, -10), Main.rand.Next(-13, -10));
                                        movingup = false;
                                    }
                                    else
                                    {
                                        npc.velocity = new Vector2(Main.rand.Next(-13, -10), Main.rand.Next(10, 13));
                                        movingup = true;
                                    }
                                }
                                if (npc.ai[1] == 150)
                                {
                                    npc.ai[1] = 0;
                                    leftofplayer = true;
                                }
                            }
                        }
                        break;*/
            }

            if (NPC.ai[0] != 2 && NPC.ai[0] != 3 && circleactive != true)
            {
                if (Main.rand.NextFloat() < 0.5526316f)
                {

                    for (int num1202 = 0; num1202 < 4; num1202++)
                    {
                        Dust.NewDust(NPC.Center - new Vector2(NPC.width / 4, -35), NPC.width / 3, NPC.height, DustID.Snow, 0, 2.63f, default, default, 1.45f);
                    }
                }
            }
            else
            {
                for (int num1101 = 0; num1101 < 6; num1101++)
                {
                    int num1110 = Dust.NewDust(new Vector2(NPC.Center.X, NPC.Center.Y), NPC.width, NPC.height, DustID.Snow, NPC.velocity.X, NPC.velocity.Y, 50, default(Color), 3f);
                    Main.dust[num1110].position = (Main.dust[num1110].position + NPC.Center) / 2f;
                    Main.dust[num1110].noGravity = true;
                    Dust dust81 = Main.dust[num1110];
                    dust81.velocity *= 0.5f;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;

            if (NPC.frameCounter % 6f == 5f)
            {
                NPC.frame.Y += frameHeight;
            }
            if (NPC.frame.Y >= frameHeight * 18) // 18 is max # of frames
            {
                NPC.frame.Y = 0; // Reset back to default
            }
        }

        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                NPC.DropBossBags();
            }
            else
            {
                int choice = Main.rand.Next(5);
                // Always drops one of:
                if (choice == 0) // Warrior
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<IceSword>());
                }
                else if (choice == 1) // Mage
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<NjorsStaff>());
                }
                else if (choice == 2) // Range
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<IcyTundra>());
                }
                else if (choice == 3) // Summoner
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<RustedBow>());
                }
            
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
        }
    }
}