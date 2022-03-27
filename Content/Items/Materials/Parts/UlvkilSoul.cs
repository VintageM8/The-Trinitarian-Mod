using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class UlvkilSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ulvkil Souls");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(0, 3, 50, 0);
            item.maxStack = 999;
        }
    }
}