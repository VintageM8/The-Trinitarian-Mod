using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Projectiles.Ammo;

namespace Trinitarian.Content.Items.Ammo
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
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 10;
            Item.crit = 0;
            Item.ammo = AmmoID.Bullet;
            Item.width = 12;
            Item.height = 16;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.maxStack = 999;
            Item.consumable = true;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<RustedBulletproj>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(50)
                .AddIngredient(ItemID.MusketBall, 50)
                .AddIngredient(ModContent.ItemType<RustyMetal>(), 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}