using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Bars
{
    public class TrueStarSteel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Star Steel");
            Tooltip.SetDefault("A metal that truly comes from the heavens");
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
            recipe.AddIngredient(ModContent.ItemType<StarSteel>(), 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}