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
            Item.width = 16;
            Item.height = 16;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<Uranium>(), 1)
                .AddIngredient(ModContent.ItemType<Plutonium>(), 1)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}