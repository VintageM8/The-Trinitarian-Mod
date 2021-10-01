using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Accessories.Melee
{
    public class WarriorOcean : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior's Ocean");
            Tooltip.SetDefault("Increases melee damage by 5% and provides water breathing");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 85, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.05f;
            player.gills = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}