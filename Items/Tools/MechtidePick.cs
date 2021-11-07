using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Tools
{
    public class MechtidePick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Pickaxe");
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 3, 45, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.pick = 235;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}