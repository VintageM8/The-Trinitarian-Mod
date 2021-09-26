using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class ShotGun1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("20 Gauge");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 46;
            item.useAnimation = 46;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<RustyScraps>(), 14);
            recipe.AddIngredient(ModContent.ItemType<GunParts>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}