using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Trinitarian.NPCs
{
    public class IceMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Man");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 34;
            npc.height = 53;
            npc.damage = 100;
            npc.defense = 20;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit50;
            npc.DeathSound = SoundID.NPCDeath53;
            npc.value = 60f;
            npc.knockBackResist = 0.8f;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;
        }

        public override void AI()
        {
            if (npc.wet)
            {
                npc.velocity.Y -= .65f;
            }

            if (npc.collideX && npc.velocity.Y == 0)
            {
                npc.velocity.Y -= 6f;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return spawnInfo.player.ZoneSnow && !Main.dayTime ? .1f : 0f;
            }
            else
            {
                return 0f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = -npc.direction;
            npc.frameCounter++;

            if (npc.frameCounter % 6 == 5f) // Ticks per frame
            {
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 4) // 4 is max # of frames
            {
                npc.frame.Y = 0; // Reset back to default
            }
        }
    }
}