using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Bags;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.LongBows;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged;
using Trinitarian.Content.Items.Consumables.Potions;
using Terraria.GameContent.ItemDropRules;

namespace Trinitarian.Common.NPCs
{
    class Drops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BlueSlime)
            {
                if (Main.rand.NextFloat() < .05f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarlyLootBag>(), 1));
                }
            }

            if (npc.type == NPCID.IceBat)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceShards>(), 3));
                }
            }

            if (npc.type == NPCID.IceSlime)
            {
                if (Main.rand.NextFloat() < .45f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceShards>(), 3));
                }
            }

            if (npc.type == NPCID.UndeadViking || npc.type == NPCID.ArmoredViking)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .45f)
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingMetal>(), 2));
                    }
            }

            if (npc.type == NPCID.Harpy)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .05f)
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngleBow>(), 1));
                    }
            }

            if (npc.type == NPCID.AngryNimbus)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .15f)
                    {
                       npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormEnergy>(), 3));
                    }
            }

            if (npc.type == NPCID.MisterStabby)
            {
                if (Main.hardMode)
                    if (Main.rand.NextFloat() < .25f)
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StabbyKnife>(), 1));
                    }
            }

            //boss drops
            if (npc.type == NPCID.Golem)
            {
                if (Main.rand.NextFloat() < .01f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TempleStormer>(), 1));;
                }
            }

            if (npc.type == NPCID.QueenBee)
            {
                if (Main.rand.NextFloat() < .30f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PoisonStaff>(), 1));
                }
            }

            if (npc.type == NPCID.DD2Betsy)
            {
                if (Main.rand.NextFloat() < .25f)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DragonBlood>(), 1));
                }
            }
        }
    }
}
