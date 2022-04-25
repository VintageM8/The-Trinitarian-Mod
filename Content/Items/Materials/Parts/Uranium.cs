using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class Uranium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Uranium");
            Tooltip.SetDefault("Such a chotic metal");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 80);
            Item.maxStack = 999;
        }
    }
}