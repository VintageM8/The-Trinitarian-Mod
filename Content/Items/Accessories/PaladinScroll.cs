using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Accessories
{
    public class PaladinScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Paladin's Scroll");
            base.Tooltip.SetDefault("Doubles your max HP");
        }

        public override void SetDefaults()
        {
            base.item.width = 26;
            base.item.height = 26;
            item.consumable = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrinitarianPlayer>().PaladinScroll = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarOre, 60);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
