using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Microsoft.Xna.Framework;

namespace Trinitarian.Content.NPCs.Enemies.Slimes
{

    class RadioactiveSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radioactive Slime");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 30;
            npc.aiStyle = NPCID.BlueSlime;
            npc.defense = 1;
            npc.damage = 8;
            npc.lifeMax = 12;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 25f;
            animationType = NPCID.BlueSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.3f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int dmg = 10;
            if (npc.life > 0)
            {
                for (int num333 = 0; (double)num333 < dmg / (double)npc.lifeMax * 50.0; num333++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 3, hitDirection, -1f);
                }
                return;
            }
            for (int num331 = 0; num331 < 20; num331++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Bone, 2.5f * (float)hitDirection, -2.5f);
            }

            Gore.NewGore(npc.position, npc.velocity, 42, npc.scale);
            Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + 20f), npc.velocity, 43, npc.scale);
            Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + 20f), npc.velocity, 43, npc.scale);
            Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + 34f), npc.velocity, 44, npc.scale);
            Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + 34f), npc.velocity, 44, npc.scale);
        }


        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ModContent.ItemType<Uranium>(), 5);
            Item.NewItem(npc.getRect(), ItemID.Gel, 2);
        }
    }
}