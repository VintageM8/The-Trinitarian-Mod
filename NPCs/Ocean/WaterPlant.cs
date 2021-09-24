using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.NPCs.Ocean
{

    public class WaterPlant : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Plant");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 42;
            npc.damage = 50;//change it vintage?
            npc.defense = 6;
            npc.lifeMax = 3500;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 3000f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 6;
            aiType = NPCID.ManEater;
            animationType = NPCID.ManEater;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            {
                return SpawnCondition.Ocean.Chance * 0.50f;
            }
            return 0;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;

            if (npc.frameCounter % 24f == 23f) 
            {
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 3) 
            {
                npc.frame.Y = 0; 
            }
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextBool(50))
            {
                Item.NewItem(npc.getRect(), ItemID.SandBlock);//add stuff vintage. Later hibub.
            }
        }
    }
}
