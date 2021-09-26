using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Snow
{
    public class HolyLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Light");
            Tooltip.SetDefault("Down in the depth of the frozen tundra, there lay an ancient scroll used by the Elder Paladins. This scroll contains the knowladge of a true Paladin, read it and gain their powers.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.maxStack = 999;
        }
    }
}