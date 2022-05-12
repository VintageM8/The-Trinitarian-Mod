using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class Charcoal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charcoal");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.Wood, 1)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}