using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Materials.Bars
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
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.useAnimation = 20;
            item.useTime = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StarSteel>(), 5);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}