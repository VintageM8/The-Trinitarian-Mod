using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Ammo;

namespace Trinitarian.Items.Ammo
{
    public class RustedBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Bullet");
            Tooltip.SetDefault("Make your enemies burn from the heat on impact");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.damage = 10;
            item.crit = 0;
            item.ammo = AmmoID.Bullet;
            item.width = 12;
            item.height = 16;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 50);
            item.maxStack = 999;
            item.consumable = true;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<RustedBulletproj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 50);
            recipe.AddIngredient(ModContent.ItemType<RustyMetal>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}