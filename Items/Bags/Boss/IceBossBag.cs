using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Weapons.Mage.PreHardmode;
using Trinitarian.Items.Weapons.Melee.PreHardmode;
using Trinitarian.Items.Weapons.Ranged;
using Trinitarian.Items.Weapons.Summoner.PreHardmode;
using Trinitarian.NPCs.Bosses;

namespace Trinitarian.Items.Bags.Boss
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
                player.QuickSpawnItem(ModContent.ItemType<NjorsMinion>(), 1);
            }
        }

        public override int BossBagNPC => ModContent.NPCType<IceBoss>();
    }
}
