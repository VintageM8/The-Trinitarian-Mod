using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Accessories.Ranged
{
    public class SteelChain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Chain");
            Tooltip.SetDefault("Increases range damage by 5%");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 85, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<SteelBar>(), 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}