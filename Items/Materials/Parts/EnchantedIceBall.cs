using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.Parts
{
    public class EnchantedIceBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EnchantedIceBall");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.maxStack = 999;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 100);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}