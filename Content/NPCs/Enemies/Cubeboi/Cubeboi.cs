using System;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Items.Materials.Parts;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace Trinitarian.Content.NPCs.Enemies.Cubeboi
{
    public class Cubeboi : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cube boi");
            Main.npcFrameCount[NPC.type] = 24;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 80;
            NPC.damage = 8;
            NPC.defense = 1;
            NPC.knockBackResist = 0.1f;
            NPC.width = 32;
            NPC.height = 54;
            NPC.aiStyle = -1;
            NPC.npcSlots = 0.5f;
            NPC.HitSound = SoundID.NPCHit52;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }


        public override void AI()
        {
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                if (NPC.velocity.X > 0.0f)
                    NPC.velocity.X = NPC.velocity.X + 0.75f;
                else
                    NPC.velocity.X = NPC.velocity.X - 0.75f;
                NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                    return;
                }
            }
            Vector2 vector2 = new Vector2(NPC.Center.X, NPC.Center.Y);
            float x = player.Center.X - vector2.X;
            float y = player.Center.Y - vector2.Y;
            float distance = 6f / (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
            float velocityX = x * distance;
            float velocityY = y * distance;
            NPC.velocity.X = (float)(((double)NPC.velocity.X * 100.0 + (double)velocityX) / 101.0);
            NPC.velocity.Y = (float)(((double)NPC.velocity.Y * 100.0 + (double)velocityY) / 101.0);
            NPC.rotation = (float)Math.Atan2((double)velocityY, (double)velocityX) - 1.57f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.3f;
        }
        
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustyScraps>(), 3));
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = -NPC.direction;
            NPC.frameCounter++;

            if (NPC.frameCounter % 6f == 5f)
            {
                NPC.frame.Y += frameHeight;
            }
            if (NPC.frame.Y >= frameHeight * 24) // 10 is max # of frames
            {
                NPC.frame.Y = 0; // Reset back to default
            }
        }
    }
}
