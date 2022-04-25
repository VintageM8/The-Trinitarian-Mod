using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Bars
{
    public class Mechtide : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide");
            Tooltip.SetDefault("Legands say its the strongest metal");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 3);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}