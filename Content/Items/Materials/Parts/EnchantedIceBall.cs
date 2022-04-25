using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class EnchantedIceBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Ice Ball");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 0, 2, 50);
            Item.maxStack = 999;
        }


        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.IceBlock, 45)
                .AddIngredient(ItemID.FrostCore, 1)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}