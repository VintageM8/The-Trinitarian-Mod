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
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 15;
            player.manaRegen += 2;
            player.GetArmorPenetration(DamageClass.Generic) += 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.SharkToothNecklace, 1)
                .AddIngredient(ModContent.ItemType<GildedLotus>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}