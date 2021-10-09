using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Melee
{
    public class RustedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Sword");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 25;
            item.useAnimation = 25;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 0, 35, 22);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.scale = 1.2f;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<RustyMetal>(), 8);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}