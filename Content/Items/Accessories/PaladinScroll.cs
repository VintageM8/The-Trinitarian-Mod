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
            base.Item.width = 26;
            base.Item.height = 26;
            Item.consumable = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrinitarianPlayer>().PaladinScroll = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.LunarOre, 60)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
