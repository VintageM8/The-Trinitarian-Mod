using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Projectiles.Ammo;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class AR15 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AR 15");
            Tooltip.SetDefault("11% Chance to not consume ammo\nChanges Bullets to Rusted Bullets");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 70, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .11f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<RustedBulletproj>();
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<RustyScraps>(), 22);
            recipe.AddIngredient(ModContent.ItemType<GunParts>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}