using Trinitarian.Items.Materials.Parts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.NPCs.Bosses.Zolzar;
using Trinitarian.Items.Accessories;

namespace Trinitarian.Items.Bags.Boss
{
    public class VikingBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {

            int choice = Main.rand.Next(4);
            // Always drops one of:
            if (choice == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<UlvkilSoul>(), 2);
                player.QuickSpawnItem(ModContent.ItemType<ZolzarsShield>(), 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<VikingBoss>();
    }
}