using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Accessories;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.NPCs.Bosses.Zolzar;

namespace Trinitarian.Content.Items.Bags.Boss
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
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;
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