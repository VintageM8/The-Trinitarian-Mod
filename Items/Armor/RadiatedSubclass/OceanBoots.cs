using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Legs)]
    public class OceanBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Boots");
            Tooltip.SetDefault("5% increased speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
