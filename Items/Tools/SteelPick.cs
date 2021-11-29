using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Tools
{
    public class SteelPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 45, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.pick = 63;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}