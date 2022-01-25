using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Hunts
{
    public class WinterDepths : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Winter Depths");
            Tooltip.SetDefault("Deep in the tundra, there lurk a lost frozen spirit.\nThe soul of this spirit can help you obtain magic powers.");
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
