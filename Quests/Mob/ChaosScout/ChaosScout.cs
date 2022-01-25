﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.ChaosScout
{
    public class ChaosScout : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Scout");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 100;
            npc.damage = 58;
            npc.defense = 5;
            npc.aiStyle = -1;
            npc.knockBackResist = 0.6f;
            npc.width = 38;
            npc.height = 24;
            animationType = 2;
            npc.HitSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.buffImmune[31] = false;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 15, 0);

        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            var player = Main.player[npc.target];
            if (Main.rand.Next(40) == 0)
            {
                //VANILLA CODE
                int k = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
                Dust expr_3390_cp_0 = Main.dust[k];
                expr_3390_cp_0.velocity.X = expr_3390_cp_0.velocity.X * 0.5f;
                Dust expr_33AE_cp_0 = Main.dust[k];
                expr_33AE_cp_0.velocity.Y = expr_33AE_cp_0.velocity.Y * 0.1f;
            }
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.5f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f) { npc.velocity.X = 2f; }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f) { npc.velocity.X = -2f; }
                npc.velocity.X *= 1f;
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f) { npc.velocity.Y = 1f; }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f) { npc.velocity.Y = -1f; }
                npc.velocity.Y *= 1f;
            }
            if (Main.dayTime && (double)npc.position.Y <= Main.worldSurface * 16.0)
            {
                if (npc.timeLeft > 10) { npc.timeLeft = 10; }
                npc.directionY = -1;
                if (npc.velocity.Y > 0f) { npc.direction = 1; }
                npc.direction = -1;
                if (npc.velocity.X > 0f) { npc.direction = 1; }
            }
            else
            {
                npc.TargetClosest(true);
                if (player.dead)
                {
                    if (npc.timeLeft > 10) { npc.timeLeft = 10; }
                    npc.directionY = -1;
                    if (npc.velocity.Y > 0f) { npc.direction = 1; }
                    npc.direction = -1;
                    if (npc.velocity.X > 0f) { npc.direction = 1; }
                }
            }
            if (npc.direction == -1 && npc.velocity.X > -6f)
            {
                npc.velocity.X = npc.velocity.X - 0.2f;
                if (npc.velocity.X > 4f) { npc.velocity.X = npc.velocity.X - 0.1f; }
                else
                    if (npc.velocity.X > 0f) { npc.velocity.X = npc.velocity.X + 0.05f; }
                if (npc.velocity.X < -4f) { npc.velocity.X = -6f; }
            }
            else
                if (npc.direction == 1 && npc.velocity.X < 6f)
            {
                npc.velocity.X = npc.velocity.X + 0.2f;
                if (npc.velocity.X < -6f) { npc.velocity.X = npc.velocity.X + 0.1f; }
                else
                    if (npc.velocity.X < 0f) { npc.velocity.X = npc.velocity.X - 0.05f; }

                if (npc.velocity.X > 6f) { npc.velocity.X = 6f; }
            }
            if (npc.directionY == -1 && (double)npc.velocity.Y > -1.5f)
            {
                npc.velocity.Y = npc.velocity.Y - 0.08f;
                if ((double)npc.velocity.Y > 1.5f) { npc.velocity.Y = npc.velocity.Y - 0.05f; }
                else
                    if (npc.velocity.Y > 0f) { npc.velocity.Y = npc.velocity.Y + 0.03f; }

                if ((double)npc.velocity.Y < -1.5f) { npc.velocity.Y = -1.5f; }
            }
            else
                if (npc.directionY == 1 && (double)npc.velocity.Y < 1.5f)
            {
                npc.velocity.Y = npc.velocity.Y + 0.08f;
                if ((double)npc.velocity.Y < -1.5f) { npc.velocity.Y = npc.velocity.Y + 0.05f; }
                else
                    if (npc.velocity.Y < 0f) { npc.velocity.Y = npc.velocity.Y - 0.03f; }

                if ((double)npc.velocity.Y > 1.5f) { npc.velocity.Y = 1.5f; }
            }
            if (npc.wet)
            {
                if (npc.velocity.Y > 0f) { npc.velocity.Y = npc.velocity.Y * 0.95f; }
                npc.velocity.Y = npc.velocity.Y - 0.5f;
                if (npc.velocity.Y < -1.5f * 1.5f) { npc.velocity.Y = -1.5f * 1.5f; }
                npc.TargetClosest(true);
                return;
            }
        }
    }
}