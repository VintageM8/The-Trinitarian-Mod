using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Trinitarian.Content.NPCs.Enemies.IceMan
{
    public class IceMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Man");
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 53;
            NPC.damage = 100;
            NPC.defense = 20;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath53;
            NPC.value = 60f;
            NPC.knockBackResist = 0.8f;
            NPC.aiStyle = 3;
            AIType = NPCID.GoblinScout;
        }

        public override void AI()
        {
            if (NPC.wet)
            {
                NPC.velocity.Y -= .65f;
            }

            if (NPC.collideX && NPC.velocity.Y == 0)
            {
                NPC.velocity.Y -= 6f;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return spawnInfo.Player.ZoneSnow && !Main.dayTime ? .1f : 0f;
            }
            else
            {
                return 0f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = -NPC.direction;
            NPC.frameCounter++;

            if (NPC.frameCounter % 6 == 5f) // Ticks per frame
            {
                NPC.frame.Y += frameHeight;
            }
            if (NPC.frame.Y >= frameHeight * 4) // 4 is max # of frames
            {
                NPC.frame.Y = 0; // Reset back to default
            }
        }
    }
}