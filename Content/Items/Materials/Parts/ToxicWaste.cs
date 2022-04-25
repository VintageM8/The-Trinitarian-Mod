using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class ToxicWaste : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Waste");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Plutonium>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}