using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.NPCs
{

    class GiantSnowball : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Snowball");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Tumbleweed];
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 30;
            npc.aiStyle = NPCID.Tumbleweed;
            npc.defense = 15;
            npc.damage = 45;
            npc.lifeMax = 90;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 25f;
            animationType = 99;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!spawnInfo.player.ZoneSnow || !Main.hardMode)
            {
                return 0f;
            }
            return 0.007f;
        }
    }
}