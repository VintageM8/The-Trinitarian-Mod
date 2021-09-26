using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Ranged;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class SteelBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Bow");
            Tooltip.SetDefault("Shoots a cluster of fast steel bolts");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 20;
            item.height = 48;
            item.useTime = 16;
            item.useAnimation = 16;
            item.crit = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<SteelBolt>();
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num = 2;
            float num2 = MathHelper.ToRadians(2f);
            for (int i = 0; i < num + 1; i++)
            {
                Vector2 vector = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(0f - num2, num2, i / (num - 1)));
                Projectile.NewProjectile(position.X, position.Y, vector.X, vector.Y, ModContent.ProjectileType<SteelBolt>(), damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SteelBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}