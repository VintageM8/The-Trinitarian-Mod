using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Accessories.Magus
{
    public class RustyRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusty Ring");
            Tooltip.SetDefault("4% increased Magus damage, and 4% crit");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 15, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.04f;
            modPlayer.magusCrit += 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SnowCuffs>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RustyMetal>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}