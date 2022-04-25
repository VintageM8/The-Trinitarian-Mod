using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Materials.Bars
{ 
    public class RustyMetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusty Metel");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<Charcoal>(), 3)
                .AddIngredient(ModContent.ItemType<RustyScraps>(), 10)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}