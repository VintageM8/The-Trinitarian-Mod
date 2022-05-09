using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic;
using Trinitarian.Content.Items.Weapons.PreHardmode.Ranged;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee;
using Trinitarian.Content.NPCs.Bosses;

namespace Trinitarian.Content.Items.Bags.Boss
{
    public class IceBossBag : ModItem
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
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<IceSword>(), 1);
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<NjorsStaff>(), 1);
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<IcyTundra>(), 1);
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<RustedBow>(), 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<IceBoss>();
    }
}
