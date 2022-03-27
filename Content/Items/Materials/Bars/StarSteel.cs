using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Bars
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
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.useAnimation = 20;
            item.useTime = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 1);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}