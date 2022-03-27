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
            Main.npcFrameCount[npc.type] = 18;
        }

        public override void SetDefaults()
        {
            npc.width = 136;
            npc.height = 112;
            npc.aiStyle = -1;
            npc.damage = 15;
            npc.defense = 12;
            npc.lifeMax = 4300;
            npc.HitSound = SoundID.NPCHit23;
            npc.DeathSound = SoundID.NPCDeath39;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            npc.npcSlots = 10f;
            //music = MusicID.Boss5;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/NjorsTheme");
            bossBag = ModContent.ItemType<IceBossBag>();
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];

            npc.spriteDirection = npc.direction;

            if (npc.life <= npc.lifeMax * 0.5f) { halflife = true; }
            if (npc.life <= npc.lifeMax * 0.25f) { fourthlife = true; }
            if (npc.ai[0] == 1 && fourthlife) { circleactive = true; }
            else { circleactive = false; }

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

            if (npc.ai[0] == 3)
            {
                npc.ai[1] += 10f;
            }
            else
            {
                npc.ai[1]++;
            }

            if (npc.ai[0] == 2 || npc.ai[0] == 3 || circleactive == true)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }

            switch (npc.ai[0])
            {
                case 0: // General case: Move towards player
                    if (!player.ZoneSnow && enraged)
                    {
                        npc.ai[0] = 1.5f;
                        npc.ai[1] = 0;
                        npc.ai[2] = 900;
                        break;
                    }

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

                    /*
                    if(npc.ai[1] == 10) EZ CODE TESTER FOR ATTACKS
                    {
                        npc.ai[0] = 3;
                        npc.ai[1] = 0;
                    }*/
                    if (npc.ai[1] == 360)
                    {
                        if (doDustAttack)
                        {
                            npc.ai[0] = 1.5f;
                            npc.ai[1] = 0;
                            npc.ai[2] = 900;
                            doDustAttack = false;
                        }
                        else
                        {
                            npc.ai[0] = 1f;
                            npc.ai[1] = 0;
                        }
                    }
                    break;
                case 1: // Spawn random shit from off screen
                    if (!player.ZoneSnow && enraged)
                    {
                        npc.ai[0] = 1.5f;
                        npc.ai[1] = 0;
                        npc.ai[2] = 900;
                        break;
                    }
                    if (fourthlife == false)
                    {
                        npc.velocity = Vector2.Zero;

                        if (npc.ai[1] % 60 == 0)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                for (int i = 0; i < Main.rand.Next(3, 6); i++)
                                {
                                    npc.netUpdate = true;
                                    Projectile.NewProjectile(new Vector2(player.Center.X + Main.rand.Next(1200, 1500), npc.Center.Y + Main.rand.Next(-360, 360)), new Vector2(Main.rand.Next(-11, -6), 0), ModContent.ProjectileType<FrozenCluster>(), npc.damage / (Main.expertMode ? 4 : 2), 0f, Main.myPlayer);
                                }

                                if (npc.life <= npc.lifeMax * 0.5f)
                                {
                                    for (int i = 0; i < Main.rand.Next(3, 6); i++)
                                    {
                                        npc.netUpdate = true;
                                        Projectile.NewProjectile(new Vector2(player.Center.X - Main.rand.Next(1200, 1500), npc.Center.Y + Main.rand.Next(-360, 360)), new Vector2(Main.rand.Next(6, 11), 0), ModContent.ProjectileType<FrozenCluster>(), npc.damage / (Main.expertMode ? 4 : 2), 0f, Main.myPlayer);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (npc.ai[1] == 1)
                        {
                            npc.hide = true;
                            npc.width = 68;
                            npc.height = 56;
                            //playercentersnapshot = player.Center;
                        }

                        if (npc.ai[2]++ > 0 && npc.ai[1] > 2)
                        {
                            npc.position = /*playercentersnapshot*/ player.Center + new Vector2(-475, 0).RotatedBy(MathHelper.ToRadians(4 * npc.ai[3]));
                            npc.position.X -= npc.width / 2;
                            npc.position.Y -= npc.height / 2;
                            npc.ai[3]++;
                            npc.ai[2] = 0;
                        }

                        if (npc.ai[1] % /*30*/15 == 0)
                        {
                            Projectile.NewProjectileDirect(npc.Center, npc.DirectionTo(/*playercentersnapshot*/player.Center) * 7.5f, ModContent.ProjectileType<FrozenCluster>(), npc.damage / (Main.expertMode ? 4 : 2), 0, Main.myPlayer, 0, npc.ai[3]);
                        }
                    }

                    if (npc.ai[1] == 600)
                    {
                        if (!doDustAttack)
                        {
                            doDustAttack = true;
                        }
                        npc.hide = false;
                        npc.width = 136;
                        npc.height = 112;
                        npc.ai[0] = 0f;
                        npc.ai[1] = 0;
                    }
                    break;
                case 1.5f: // Do dust swirl animation
                    npc.velocity = Vector2.Zero;

                    for (int i = 0; i < 18; i++)
                    {
                        Vector2 dustPos = npc.Center + new Vector2(npc.ai[2], 0).RotatedBy(MathHelper.ToRadians(i * 20 + npc.ai[1]));
                        Dust dust = Main.dust[Dust.NewDust(dustPos, 15, 15, DustID.Snow, 0f, 0f, 0, default, 2.04f)];
                        dust.noGravity = true;
                    }

                    npc.ai[2] -= 15;

                    if (npc.ai[2] == 0)
                    {
                        npc.ai[0] = 2;
                        npc.ai[1] = 0;
                        npc.ai[2] = 0;
                    }
                    break;
                case 2: // Turn into dust cloud
                    npc.hide = true;

                    if (npc.ai[2] == (Main.expertMode ? 50 : 66))
                    {
                        npc.velocity = Vector2.Zero;
                    }

                    npc.width = 68;
                    npc.height = 56;
                    if (npc.ai[1] <= 600)
                    {
                        if (npc.ai[2] <= 0)
                        {
                            float chargeSpeed = !player.ZoneSnow ? 30 : 22;
                            move = player.Center - npc.Center;
                            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                            move *= chargeSpeed / magnitude;
                            npc.velocity = move;
                            npc.netUpdate = true;
                            if (!player.ZoneSnow)
                            {
                                npc.ai[2] = 40;
                            }
                            else
                            {
                                npc.ai[2] = 80; // charging delay
                            }
                        }
                        npc.ai[2] -= 1f;
                        if (npc.ai[1] == 600)
                        {
                            npc.ai[2] = -100;
                        }
                    }
                    else if (halflife == true)
                    {
                        if (npc.ai[2] == -100)
                        {
                            leftofplayer = Main.rand.NextBool();
                            npc.ai[2] = 0;
                        }
                        if (leftofplayer == true)
                        {
                            if (npc.ai[2] == 1)
                            {
                                npc.Teleport(player.Center + new Vector2(-700, (npc.height / 2) - 90), 32);
                                npc.velocity = Vector2.Zero;
                            }
                            if (npc.ai[2] % 30 == 0)
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
                            if (npc.ai[2] == 150)
                            {
                                npc.ai[2] = 0;
                                leftofplayer = false;
                            }
                        }
                        else
                        {
                            if (npc.ai[2] == 1)
                            {
                                npc.Teleport(player.Center + new Vector2(700, (npc.height / 2) - 90), 32);
                                npc.velocity = Vector2.Zero;
                            }
                            if (npc.ai[2] % 30 == 0)
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
                            if (npc.ai[2] == 150)
                            {
                                npc.ai[2] = 0;
                                leftofplayer = true;
                            }
                        }
                        npc.ai[2] += 1f;
                    }

                    if (npc.ai[1] == (halflife ? 900 : 600))
                    {
                        if (player.ZoneSnow)
                        {
                            npc.width = 136;
                            npc.height = 112;

                            npc.velocity = Vector2.Zero;
                            npc.hide = false;

                            npc.ai[2] = 0;

                            if (Main.expertMode)
                            {
                                npc.ai[0] = 3;
                                npc.ai[1] = 0;
                            }
                            else
                            {
                                npc.ai[0] = 0;
                                npc.ai[1] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[0] = 2;
                            npc.ai[1] = 0;
                        }
                    }
                    break;
                case 3: // Spin in a circle

                    // Get center to spin around
                    if (npc.ai[1] == 10)
                    {
                        rotationCenter = new Vector2(npc.Center.X + 50, npc.Center.Y);
                    }

                    double deg = (double)npc.ai[1];
                    double rad = deg * (Math.PI / 180); //Convert degrees to radians
                    double dist = 50; //Distance away from the player

                    npc.position.X = rotationCenter.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
                    npc.position.Y = rotationCenter.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;

                    if (npc.ai[1] % 50 == 0)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Projectile.NewProjectile(npc.Center, Vector2.One.RotatedByRandom(Math.PI) * 6, ModContent.ProjectileType<FrozenCluster>(), npc.damage / 4, 0f, Main.myPlayer);
                            }
                        }
                    }
                    // Move the NPC around the center
                    if (npc.ai[1] == 2400)
                    {
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
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

            if (npc.ai[0] != 2 && npc.ai[0] != 3 && circleactive != true)
            {
                if (Main.rand.NextFloat() < 0.5526316f)
                {

                    for (int num1202 = 0; num1202 < 4; num1202++)
                    {
                        Dust.NewDust(npc.Center - new Vector2(npc.width / 4, -35), npc.width / 3, npc.height, DustID.Snow, 0, 2.63f, default, default, 1.45f);
                    }
                }
            }
            else
            {
                for (int num1101 = 0; num1101 < 6; num1101++)
                {
                    int num1110 = Dust.NewDust(new Vector2(npc.Center.X, npc.Center.Y), npc.width, npc.height, DustID.Snow, npc.velocity.X, npc.velocity.Y, 50, default(Color), 3f);
                    Main.dust[num1110].position = (Main.dust[num1110].position + npc.Center) / 2f;
                    Main.dust[num1110].noGravity = true;
                    Dust dust81 = Main.dust[num1110];
                    dust81.velocity *= 0.5f;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;

            if (npc.frameCounter % 6f == 5f)
            {
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 18) // 18 is max # of frames
            {
                npc.frame.Y = 0; // Reset back to default
            }
        }

        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int choice = Main.rand.Next(5);
                // Always drops one of:
                if (choice == 0) // Warrior
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceSword>());
                }
                else if (choice == 1) // Mage
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<NjorsStaff>());
                }
                else if (choice == 2) // Range
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IcyTundra>());
                }
                else if (choice == 3) // Summoner
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RustedBow>());
                }
            
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
        }
    }
}