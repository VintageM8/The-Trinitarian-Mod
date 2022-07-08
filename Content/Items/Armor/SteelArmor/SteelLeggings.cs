using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.SteelArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SteelLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Leggings");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<SteelBar>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}