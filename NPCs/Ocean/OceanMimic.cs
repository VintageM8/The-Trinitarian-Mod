using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.NPCs.Ocean
{

	public class OceanMimic : ModNPC
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Mimic");
            Main.npcFrameCount[npc.type] = 14;
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
            npc.aiStyle = 87;
            aiType = NPCID.BigMimicHallow;
            animationType = NPCID.BigMimicHallow;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.OceanMonster.Chance * 0.5f;
            }
            else
            {
                return 0f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;

            if (npc.frameCounter % 24f == 23f) // Ticks per frame
            {
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * 14) // 2 is max # of frames
            {
                npc.frame.Y = 0; // Reset back to default
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
