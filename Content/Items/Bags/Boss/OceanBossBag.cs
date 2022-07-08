using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.Ghariel;
using Trinitarian.Content.Items.Weapons.Hardmode.Magic;
using Trinitarian.Content.NPCs.Bosses.Ocean;

namespace Trinitarian.Content.Items.Bags.Boss
{
    public class OceanBossBag : ModItem
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
            if (choice == 0) // 
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<VellamoThrow>(), 1);
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<WaveTomeUpgrade>(), 1);
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<GharielRifle>(), 1);
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.DirtBlock, 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<OceanGhost>();
    }
}
