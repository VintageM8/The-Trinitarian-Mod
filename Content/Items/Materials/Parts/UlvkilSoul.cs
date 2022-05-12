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
            Item.width = 22;
            Item.height = 22;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.maxStack = 999;
        }
    }
}