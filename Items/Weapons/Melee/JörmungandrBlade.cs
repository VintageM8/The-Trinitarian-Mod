using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
    public class JörmungandrBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jörmungandr's Blade");
            Tooltip.SetDefault("Does stuff");
        }

        public override void SetDefaults()
        {
            item.damage = 37;
            item.melee = true;
            item.width = 20;
            item.height = 25;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 35, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PrismSlash");
            item.shootSpeed = 25f;
            item.channel = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}