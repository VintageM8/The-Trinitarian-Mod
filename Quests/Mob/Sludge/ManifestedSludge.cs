using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs;

namespace Trinitarian.Quests.Mob.Sludge
{
    public class ManifestedSludge : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Manifested Sludge");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 50;
            npc.height = 40;
            npc.damage = 28;
            npc.defense = 10;
            npc.lifeMax = 680;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            npc.buffImmune[20] = true;
            npc.netAlways = true;
        }

        int chance = 1;
        bool regen = false;
        public override void AI()
        {
            Player P = Main.player[npc.target];
            npc.netUpdate = true;
            if (Vector2.Distance(npc.Center, P.Center) > 1500 || npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
                P = Main.player[npc.target];
                if (!P.active || P.dead || Vector2.Distance(npc.Center, P.Center) > 1500)
                {
                    regen = true;
                }
            }
            if (!regen)
            {
                npc.life = npc.life < npc.lifeMax ? npc.life + 1 + (int)((float)npc.lifeMax * 0.001f) : npc.lifeMax;
                if (Collision.CanHitLine(new Vector2(npc.Center.X, npc.Center.Y), 1, 1, new Vector2(P.Center.X, P.Center.Y), 1, 1) || Vector2.Distance(npc.Center, P.Center) < 400)
                {
                    regen = true;
                }
            }
            if (npc.velocity.Y == 0)
            {
                if (chance != 0)
                {
                    chance = Main.rand.Next(150);
                }
                else
                {
                    if (Collision.CanHitLine(new Vector2(npc.Center.X, npc.Center.Y), 1, 1, new Vector2(P.Center.X, P.Center.Y), 1, 1))
                    {
                        npc.velocity.Y = -(float)Math.Sqrt(2 * 0.3f * Math.Abs((P.position.Y - 100) - npc.Center.Y));
                        npc.velocity.X = (P.Center.X + P.velocity.X - npc.Center.X) / 90;
                        chance = 1;
                    }
                }
            }
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(ModContent.BuffType<Nosferatu>(), 420);
        }
    }
}