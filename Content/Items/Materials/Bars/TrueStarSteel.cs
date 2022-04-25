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
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.useAnimation = 20;
            Item.useTime = 20;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ModContent.ItemType<StarSteel>(), 5)
                .AddIngredient(ItemID.SoulofLight, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}