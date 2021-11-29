using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Melee;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee.Hardmode
{
    public class InfusedZozarBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infused Zozar's Blade");
            Tooltip.SetDefault("Shoots a projectile, same as Zozar's Blade");
        }

        public override void SetDefaults()
        {
            item.damage = 82;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 10, 50, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ZozarBladeproj>();
            item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ModContent.ItemType<UraniumBar>(), 5);
            recipe.AddIngredient(ItemType<ZozarBlade>(), 1);
            recipe.AddIngredient(ItemType<VikingMetal>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}