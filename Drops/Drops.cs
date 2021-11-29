using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Accessories;
using Trinitarian.Items.Bags;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Weapons.Melee.Hardmode;
using Trinitarian.Items.Weapons.Ranged;

namespace Trinitarian.Drops
{
    class Drops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.BlueSlime)
            {
                if (Main.rand.NextFloat() < .50f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RustyScraps>(), 4);
                }

                if (Main.rand.NextFloat() < .05f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarlyLootBag>(), 1);
                }
            }

            if (npc.type == NPCID.IceBat)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceShards>(), 3);
                }
            }

            if (npc.type == NPCID.IceSlime)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<IceShards>(), 3);
                }
            }

            if (npc.type == NPCID.Shark)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .30f)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TheMermaid>(), 1);
                    }
            }

            if (npc.type == NPCID.UndeadViking || npc.type == NPCID.ArmoredViking)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .45f)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<VikingMetal>(), 2);
                    }
            }

            if (npc.type == NPCID.Harpy)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .05f)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AngleBow>(), 1);
                    }
            }

            if (npc.type == NPCID.AngryNimbus)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .15f)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StormEnergy>(), 3);
                    }
            }

            if (npc.type == NPCID.MisterStabby)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .25f)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StabbyKnife>(), 1);
                    }
            }

            //boss drops
            if (npc.type == NPCID.Golem)
            {
                if (Main.rand.NextFloat() < .01f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TempleStormer>(), 1);
                }
            }
        }
    }
}
