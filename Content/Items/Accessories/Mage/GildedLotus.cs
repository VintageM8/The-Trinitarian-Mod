using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Accessories.Mage
{
    public class GildedLotus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gilded Lotus");
            Tooltip.SetDefault("Increased max mana by 15 and increases mana regen by 10%.");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 15;
            player.manaRegen += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<StarSteel>(), 3)
                .AddIngredient(ItemID.FallenStar, 2)
                .AddIngredient(ItemID.Daybloom, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
