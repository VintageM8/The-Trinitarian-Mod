using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Snow
{
    public class SnowQuestBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Quest Bag");
            Tooltip.SetDefault("Contains info on Snow Quests\n{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.consumable = true;
            item.width = 26;
            item.height = 34;
            item.rare = ItemRarityID.Blue;
            item.expert = false;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType<HolyLight>(), 1);
            player.QuickSpawnItem(ModContent.ItemType<FrozenFire>(), 1);
        }
    }
}
