﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Projectiles.Boss.Ocean;
using Trinitarian.NPCs.Bosses.Ocean;
using Trinitarian.Projectiles.Boss.Zolzar;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Items.Weapons.Mage.Hardmode;
using Trinitarian.Items.Weapons.Ranged.Hardmode;
using Trinitarian.Items.Weapons.Magus.Spells.Hardmode;

namespace Trinitarian.NPCs.Bosses.Ocean
{
    [AutoloadBossHead]
    public class OceanGhost : ModNPC
    {
        int spritetimer = 0;
        int frame = 1;
        int attackCounter = 0;
        Vector2 teleportPosition = Vector2.Zero;
        bool changedPhase2 = false;
        bool changedPhase2Indicator = false;

        int Direction = -1;
        bool direction = false;

        int RandomCase = 0;
        int LastCase = 1;
        int RandomCeiling;
        bool movement = true;

        bool npcDashing = false;
        int spriteDirectionStore = 0;

        bool dead = false;


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Fallen Captian");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 102;
            npc.height = 102;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.damage = 75;//15;
            npc.defense = 24;
            npc.lifeMax = 40500;
            npc.HitSound = SoundID.NPCHit4;
            npc.value = Item.buyPrice(gold: 5);
            npc.boss = true;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/STONEBROS");
            //bossBag = ModContent.ItemType<KnightBag>();
        }

        public override void AI()
        {
            // reset boolean
            TrinitarianWorld.downedOceanGhost = false;

            Player player = Main.player[npc.target];

            // Reset counters
            int countMinions = 0;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == NPCType<ShipCrew>())
                {
                    countMinions++;
                }
            }

            // AI [0] = Case Value
            // AI [1] = Timer
            // AI [2] = 
            // AI [3] = 

            if (npc.ai[3] > 0f && dead == true)
            {
                npc.velocity = Vector2.Zero;
                npc.rotation = 0;

                if (npc.ai[2] > 0)
                {
                    npc.ai[2]--;
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

                    if (Main.rand.NextBool(5) && npc.ai[3] < 120f)
                    {
                        
                        for (int dustNumber = 0; dustNumber < 6; dustNumber++)
                        {
                            Dust dust = Main.dust[Dust.NewDust(npc.Left, npc.width, npc.height / 2, DustID.Water, 0f, 0f, 0, default(Color), 1f)];
                            dust.position = npc.Center + Vector2.UnitY.RotatedByRandom(4.1887903213500977) * new Vector2(npc.width * 1.5f, npc.height * 1.1f) * 0.8f * (0.8f + Main.rand.NextFloat() * 0.2f);
                            dust.velocity.X = 0f;
                            dust.velocity.Y = -Math.Abs(dust.velocity.Y - (float)dustNumber + npc.velocity.Y - 4f) * 3f;
                            dust.noGravity = true;
                            dust.fadeIn = 1f;
                            dust.scale = 1f + Main.rand.NextFloat() + (float)dustNumber * 0.3f;
                        }
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

            if (npc.life <= npc.lifeMax * 0.5f)
            {
                changedPhase2 = true;
            }

            switch (npc.ai[0])
            {
                case -4: // half hp roar
                    if (!PlayerAlive(player)) { break; }

                    npc.immortal = true;
                    npc.dontTakeDamage = true;
                    if (npc.ai[1] == 45)
                    {
                        Main.PlaySound(new Terraria.Audio.LegacySoundStyle(SoundID.NPCKilled, 10), (int)npc.Center.X, (int)npc.Center.Y);
                    }

                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        float distance = Vector2.Distance(npc.Center, Main.player[i].Center);
                        if (distance <= 600)
                        {
                            Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 30;
                        }
                    }

                    if (++npc.ai[1] > 240)
                    {
                        npcDashing = false;
                        npc.dontTakeDamage = false;
                        npc.immortal = false;
                        changedPhase2Indicator = true;
                        npc.ai[1] = 0;
                        npc.ai[2] = 1;
                        npc.ai[0] = -1;
                        npc.ai[3] = 0;
                    }
                    break;
                case -3: // spawn sequence
                    if (!PlayerAlive(player)) { break; }

                    // reset boolean
                    TrinitarianWorld.downedOceanGhost = false;

                    npc.velocity = Vector2.UnitY * 0.7f;
                    npc.dontTakeDamage = true;

                    if (++npc.ai[1] > 380)
                    {
                        // check if no minions
                        if (countMinions <= 0)
                        {
                            npc.ai[0] = 1;
                            npc.ai[1] = 0;
                        }
                        else
                        {
                            npc.ai[0] = 0;
                            npc.ai[1] = 0;
                        }

                        npc.dontTakeDamage = false;
                        player.GetModPlayer<TrinitarianPlayer>().ShowText = false;
                        npc.velocity = Vector2.Zero;
                        Main.PlaySound(new Terraria.Audio.LegacySoundStyle(SoundID.NPCKilled, 10), (int)npc.Center.X, (int)npc.Center.Y);
                        for (int i = 0; i < Main.maxPlayers; i++)
                        {
                            float distance = Vector2.Distance(npc.Center, Main.player[i].Center);
                            if (distance <= 600)
                            {
                                Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 30;
                            }
                        }
                        npcDashing = false;
                    }
                    break;
                case -2: // fast movement towards player

                    if (!PlayerAlive(player)) { break; }

                    Vector2 moveTo = player.Center;
                    var move = moveTo - npc.Center;
                    var speed = 10;

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

                    if (++npc.ai[1] > (changedPhase2 ? 150 : 180))
                    {
                        if (changedPhase2 == true && changedPhase2Indicator == false)
                        {
                            npc.ai[0] = -4;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                        else
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                    }

                    break;
                case -1: // case switching
                    {
                        if (movement == true)
                        {
                            if (changedPhase2 == true) { RandomCeiling = 4; }
                            else { RandomCeiling = 2; }
                            while (RandomCase == LastCase)
                            {
                                RandomCase = Main.rand.Next(RandomCeiling);
                            }
                            LastCase = RandomCase;
                            movement = false;
                            npc.ai[0] = RandomCase;
                        }
                        else
                        {
                            movement = true;
                            npc.ai[0] = -2;
                        }
                    }
                    break;
                case 0: // dash towards player
                    if (changedPhase2 && !changedPhase2Indicator)
                    {
                        npc.ai[0] = -4;
                        npc.ai[1] = 0;
                        break;
                    }

                    if (!PlayerAlive(player)) { break; }

                    if (npc.ai[1] > 5 && npc.ai[1] < 30)
                    {
                        if (++npc.ai[2] % 5 == 0)
                        {
                            Vector2 origin = npc.Center;
                            float radius = 45;
                            int numLocations = 30;
                            for (int i = 0; i < 30; i++)
                            {
                                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                                Vector2 dustvelocity = new Vector2(0f, 20f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                                int dust = Dust.NewDust(position, 2, 2, DustID.Water, dustvelocity.X, dustvelocity.Y, 0, default, 2);
                                Main.dust[dust].noGravity = true;
                            }
                        }
                    }

                    if (npc.ai[1] == 30)
                    {
                        if (Main.player[npc.target].Center.X < npc.Center.X && npcDashing == false)
                        {
                            npc.rotation = npc.DirectionTo(player.Center).RotatedBy(MathHelper.ToRadians(180)).ToRotation();
                            npc.spriteDirection = -1;
                        }
                        else
                        {
                            npc.rotation = npc.DirectionTo(player.Center).ToRotation();
                        }
                        spriteDirectionStore = npc.spriteDirection;
                        npcDashing = true;
                    }

                    if (npc.ai[1] > 30 && npc.ai[1] < /*90*/ 60 && npc.ai[1] % /*10*/ 11 == 0 && changedPhase2 == true)
                    {
                        for (int i = -1; i < 1; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(npc.Center, new Vector2(0, 5 + (10 * i)).RotatedBy(npc.rotation), ProjectileType<Bubble>(), npc.damage / 3, 5f, Main.myPlayer);
                            }
                        }
                    }

                    if (++npc.ai[1] == 30)
                    {
                        npc.velocity = (changedPhase2 ? 12 : 8) * npc.DirectionTo(new Vector2(Main.rand.NextFloat(player.Center.X - 25, player.Center.X + 25), Main.rand.NextFloat(player.Center.Y - 25, player.Center.Y + 25)));
                    }
                    else if (npc.ai[1] > 60 && npc.ai[1] < 120)
                    {
                        npc.velocity = new Vector2(MathHelper.Lerp(npc.velocity.X, 0, changedPhase2 ? 0.05f : 0.025f), MathHelper.Lerp(npc.velocity.Y, 0, changedPhase2 ? 0.05f : 0.025f));
                    }
                    else if (npc.ai[1] > 120)
                    {
                        npc.ai[1] = 0;
                        attackCounter++;
                        npcDashing = false;
                    }
                    if (attackCounter == (changedPhase2 ? 7 : 5))
                    {
                        if (changedPhase2 == true && changedPhase2Indicator == false)
                        {
                            npc.ai[0] = -4;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                        else
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                    }
                    break;
                case 3: // telebombs
                    if (!PlayerAlive(player)) { break; }

                    if (npc.ai[1] == 15)
                    {
                        teleportPosition = player.Center + Main.rand.NextVector2Circular(333, 333);

                        while (Main.tile[(int)teleportPosition.X / 16, (int)teleportPosition.Y / 16].active())
                        {
                            teleportPosition = player.Center + Main.rand.NextVector2Circular(333, 333);
                        }
                    }

                    if (npc.ai[1] > 30)
                    {
                        if (++npc.ai[2] % 5 == 0)
                        {
                            Vector2 origin = teleportPosition;
                            float radius = 20;
                            int numLocations = 30;
                            for (int i = 0; i < 30; i++)
                            {
                                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                                Vector2 dustvelocity = new Vector2(0f, 15f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                                int dust = Dust.NewDust(position, 2, 2, DustID.Water, dustvelocity.X, dustvelocity.Y, 0, default, 2);
                                Main.dust[dust].noGravity = true;
                            }
                        }
                    }
                    if (++npc.ai[1] > 90)
                    {
                        npc.Teleport(teleportPosition + new Vector2(-51, -51), 206);
                        int projectiles = 4 + (attackCounter * (changedPhase2 ? 3 : 2));
                        for (int j = 0; j < projectiles; j++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(npc.Center, new Vector2(0f, 5f).RotatedBy(j * MathHelper.TwoPi / projectiles), ProjectileType<DangerBubble>(), npc.damage / 2, 10f, Main.myPlayer);
                            }
                        }
                        attackCounter++;
                        npc.ai[1] = 0;
                    }
                    if (attackCounter == 4)
                    {
                        if (changedPhase2 == true && changedPhase2Indicator == false)
                        {
                            npc.ai[0] = -4;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                        else
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                    }
                    break;
                case 2: // bubbleing bubbles in patterss
                    if (!PlayerAlive(player)) { break; }

                    if (npc.ai[2] == 0)
                    {
                        direction = Main.rand.NextBool();
                        Direction = direction ? -1 : 1;
                        npc.ai[2]++;
                    }

                    if (npc.ai[1] > 5 && npc.ai[1] < 40)
                    {
                        if (++npc.ai[2] % 5 == 0)
                        {
                            Vector2 origin = new Vector2(player.Center.X + (-600 * Direction), player.Center.Y);
                            float radius = 15;
                            int numLocations = 30;
                            for (int i = 0; i < 30; i++)
                            {
                                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                                Vector2 dustvelocity = new Vector2(0f, 10f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                                int dust = Dust.NewDust(position, 2, 2, DustID.Water, dustvelocity.X, dustvelocity.Y, 0, default, 2);
                                Main.dust[dust].noGravity = true;
                            }
                        }
                    }

                    if (npc.ai[1] > 40)
                    {
                        npc.position = new Vector2(player.Center.X + (-600 * Direction) - 51, player.Center.Y - 51);
                    }

                    if (++npc.ai[1] % (changedPhase2 ? 45 : 60) == 0)
                    {
                        Vector2 direction = player.Center - npc.Center;
                        direction.Normalize();
                        int projectiles = Main.rand.Next(6, 12);
                        for (int i = projectiles * -1 / 2; i < projectiles / 2; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Projectile.NewProjectile(npc.Center, direction.RotatedBy(i * 3) * (changedPhase2 ? 7f : 5f), ProjectileType<Bubble>(), npc.damage / 2, 10f, Main.myPlayer);
                            }
                        }
                        attackCounter++;
                    }
                    if (attackCounter == 8)
                    {
                        if (changedPhase2 == true && changedPhase2Indicator == false)
                        {
                            npc.ai[0] = -4;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                        else
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                    }
                    break;
                case 1: // minions
                    if (changedPhase2 && !changedPhase2Indicator)
                    {
                        npc.ai[0] = -4;
                        npc.ai[1] = 0;
                        break;
                    }

                    if (!PlayerAlive(player)) { break; }

                    if (npc.ai[2] == 0)
                    {
                        direction = Main.rand.NextBool();
                        Direction = direction ? -1 : 1;
                        npc.ai[2]++;
                    }

                    if (npc.ai[1] > 5 && npc.ai[1] < 240) //90)
                    {
                        if (++npc.ai[2] % 5 == 0)
                        {
                            Vector2 origin1 = new Vector2(player.Center.X + 300 * Direction, player.Center.Y);
                            float radius1 = 7.5f; //15;
                            int numLocations1 = 25; //30;
                            for (int i = 0; i < 25; i++)
                            {
                                Vector2 position = origin1 + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations1 * i)) * radius1;
                                Vector2 dustvelocity = new Vector2(0f, /*10*/ 7.5f).RotatedBy(MathHelper.ToRadians(360f / numLocations1 * i));
                                int dust = Dust.NewDust(position, 2, 2, DustID.Water, dustvelocity.X, dustvelocity.Y, 0, default, 1.5f); //2);
                                Main.dust[dust].noGravity = true;
                            }

                            if (npc.ai[1] > 5 && npc.ai[1] < 90)
                            {
                                Vector2 origin = new Vector2(player.Center.X + -300 * Direction, player.Center.Y);
                                float radius = 15;
                                int numLocations = 30;
                                for (int i = 0; i < 30; i++)
                                {
                                    Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                                    Vector2 dustvelocity = new Vector2(0f, 10f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                                    int dust = Dust.NewDust(position, 2, 2, DustID.Water, dustvelocity.X, dustvelocity.Y, 0, default, 2);
                                    Main.dust[dust].noGravity = true;
                                }
                            }
                        }
                    }

                    if (npc.ai[1] > 90)
                    {
                        npc.position = new Vector2(player.Center.X + -300 * Direction - 51, player.Center.Y - 51);
                    }

                    if (++npc.ai[1] % 120 == 0 && npc.ai[1] < 360)
                    {
                        for (int i = -1; i < 1; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                NPC.NewNPC((int)((player.Center.X + 300 * Direction - 51) + (/*150*/ 75 + (/*300*/ 150 * i))), (int)npc.Center.Y, NPCType<ShipCrew>(), 0, 0, 0, changedPhase2 ? 1 : 0);
                            }
                        }
                        int count = 0;
                        for (int k = 0; k < 200; k++)
                        {
                            if (Main.npc[k].active && Main.npc[k].type == mod.NPCType("ShipCrew"))
                            {
                                if (count < 4)
                                {
                                    count++;
                                }
                                else
                                {
                                    ((ShipCrew)Main.npc[k].modNPC).kill = true;
                                }
                            }
                        }
                    }

                    if (npc.ai[1] == 420)
                    {
                        if (changedPhase2 == true && changedPhase2Indicator == false)
                        {
                            npc.ai[0] = -4;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                        else
                        {
                            npc.ai[0] = -1;
                            npc.ai[1] = 0;
                            npc.ai[2] = 0;
                            attackCounter = 0;
                            npc.velocity = Vector2.Zero;
                            npc.rotation = 0;
                            npcDashing = false;
                            teleportPosition = Vector2.Zero;
                        }
                    }
                    break;

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

        public override void FindFrame(int frameHeight)
        {

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


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
    }
}