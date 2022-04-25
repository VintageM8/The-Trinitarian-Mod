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
            if (choice == 0) // 
            {
                player.QuickSpawnItem(ModContent.ItemType<IceSword>(), 1);
            }
            else if (choice == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<NjorsStaff>(), 1);
            }
            else if (choice == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType<IcyTundra>(), 1);
            }
            else if (choice == 3)
            {
                player.QuickSpawnItem(ModContent.ItemType<RustedBow>(), 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<IceBoss>();
    }
}
