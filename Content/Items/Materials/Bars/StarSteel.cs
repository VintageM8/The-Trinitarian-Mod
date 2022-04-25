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
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.useAnimation = 20;
            Item.useTime = 20;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<SteelBar>(), 1)
                .AddIngredient(ItemID.FallenStar, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}