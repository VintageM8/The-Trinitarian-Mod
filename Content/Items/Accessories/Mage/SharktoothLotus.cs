using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Accessories.Mage;

namespace Trinitarian.Content.Items.Accessories.Mage
{
    public class SharktoothLotus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharktooth Lotus");
            Tooltip.SetDefault("Increased max mana by 15 and increases mana regen by 10%\n Increases armor penetration by 5");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 15;
            player.manaRegen += 2;
            player.armorPenetration += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SharkToothNecklace, 1);
            recipe.AddIngredient(ModContent.ItemType<GildedLotus>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}