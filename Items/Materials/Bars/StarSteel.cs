using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Bars
{
    public class StarSteel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Steel");
            Tooltip.SetDefault("A holy metel");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            item.value = 25000; // 100 = silver, 10000 = gold
            item.useAnimation = 20;
            item.useTime = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 5);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}