using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

namespace Trinitarian.Content.NPCs.Enemies.Slimes
{

    class RadioactiveSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radioactive Slime");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 38;
            NPC.height = 30;
            NPC.aiStyle = NPCID.BlueSlime;
            NPC.defense = 1;
            NPC.damage = 8;
            NPC.lifeMax = 12;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 25f;
            AnimationType = NPCID.BlueSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.3f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int dmg = 10;
            if (NPC.life > 0)
            {
                for (int num333 = 0; (double)num333 < dmg / (double)NPC.lifeMax * 50.0; num333++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 3, hitDirection, -1f);
                }
                return;
            }
            for (int num331 = 0; num331 < 20; num331++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Bone, 2.5f * (float)hitDirection, -2.5f);
            }

            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 42, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + 20f), NPC.velocity, 43, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + 20f), NPC.velocity, 43, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + 34f), NPC.velocity, 44, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X, NPC.position.Y + 34f), NPC.velocity, 44, NPC.scale);
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Uranium>(), 5));
        }
    }
}
