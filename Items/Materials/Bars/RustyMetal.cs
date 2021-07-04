using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Materials.Bars
{
    public class RustyMetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusty Metel");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Charcoal>(), 3);
            recipe.AddIngredient(ModContent.ItemType<RustyScraps>(), 10);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}