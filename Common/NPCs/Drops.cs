using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common.DropConditions;
using Trinitarian.Content.Items.Bags;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.LongBows;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic;

namespace Trinitarian.Common.NPCs;

internal class Drops : GlobalNPC {
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
        HardmodeCondition hardmodeCondition = new();

        switch (npc.type) {
            case NPCID.BlueSlime: {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarlyLootBag>(), 20));
                break;
            }
            case NPCID.IceBat:
            case NPCID.IceSlime: {
                npcLoot.Add(new CommonDrop(ModContent.ItemType<IceShards>(), 20, 1, 1, 9));

                break;
            }
            case NPCID.UndeadViking:
            case NPCID.ArmoredViking: {
                npcLoot.Add(ItemDropRule.ByCondition(hardmodeCondition, ModContent.ItemType<VikingMetal>(), 20,
                    chanceNumerator: 9));

                break;
            }
            case NPCID.Harpy: {
                npcLoot.Add(ItemDropRule.ByCondition(hardmodeCondition, ModContent.ItemType<AngleBow>(), 20));

                break;
            }
            case NPCID.AngryNimbus: {
                npcLoot.Add(ItemDropRule.ByCondition(hardmodeCondition, ModContent.ItemType<StormEnergy>(), 20,
                    chanceNumerator: 3));

                break;
            }
            case NPCID.MisterStabby: {
                npcLoot.Add(ItemDropRule.ByCondition(hardmodeCondition, ModContent.ItemType<StabbyKnife>(), 4,
                    chanceNumerator: 1));

                break;
            }
            //boss drops
            case NPCID.Golem: {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TempleStormer>(), 10));

                break;
            }
            case NPCID.QueenBee: {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PoisonStaff>(), 3));

                break;
            }
            case NPCID.DD2Betsy: {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PoisonStaff>(), 4));

                break;
            }
        }
    }
}