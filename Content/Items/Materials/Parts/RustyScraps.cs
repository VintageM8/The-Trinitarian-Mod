using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class RustyScraps : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusty Scraps");
            Tooltip.SetDefault("This could make some useful metals");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.maxStack = 999;
        }
    }
}