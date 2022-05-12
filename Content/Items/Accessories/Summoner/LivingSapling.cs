using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories.Summoner
{
    public class LivingSapling : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Wood Sapling");
            Tooltip.SetDefault("Increses minion damage by 2%");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 36;
            Item.height = 36;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.02f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.Wood, 8)
                .AddTile(TileID.LivingLoom)
                .Register();
        }
    }
}