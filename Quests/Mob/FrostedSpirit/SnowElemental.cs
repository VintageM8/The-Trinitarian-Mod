using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.FrostedSpirit
{
    public class SnowElemental : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Elemental");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 120;
            npc.damage = 32;
            npc.defense = 6;
            npc.knockBackResist = 0.2f;
            npc.width = 32;
            npc.height = 54;
            npc.aiStyle = -1;
            animationType = 48;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit52;
            npc.noGravity = true;
            npc.buffImmune[31] = false;
            npc.noTileCollide = true;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = Item.buyPrice(0, 0, 5, 0);
        }


        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }


        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                if (npc.velocity.X > 0.0f)
                    npc.velocity.X = npc.velocity.X + 0.75f;
                else
                    npc.velocity.X = npc.velocity.X - 0.75f;
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            Vector2 vector2 = new Vector2(npc.Center.X, npc.Center.Y);
            float x = player.Center.X - vector2.X;
            float y = player.Center.Y - vector2.Y;
            float distance = 6f / (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
            float velocityX = x * distance;
            float velocityY = y * distance;
            npc.velocity.X = (float)(((double)npc.velocity.X * 100.0 + (double)velocityX) / 101.0);
            npc.velocity.Y = (float)(((double)npc.velocity.Y * 100.0 + (double)velocityY) / 101.0);
            npc.rotation = (float)Math.Atan2((double)velocityY, (double)velocityX) - 1.57f;
        }
    }
}