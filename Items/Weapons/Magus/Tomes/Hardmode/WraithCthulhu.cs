using Terraria;
using Terraria.ID;
using Trinitarian.Items.Materials.Bars;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Magus.Tomes.Hardmode
{
    public class WraithCthulhu : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wraith of Cthulhu");
            Tooltip.SetDefault("Unleash massive rain drops from the sky that turn into waternado's");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 69;
            item.width = 112;
            item.height = 40;
            item.useTime = 16;
            item.useAnimation = 16;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<HugeRain>();
            item.shootSpeed = 20f;
        }

        public override bool UseItem(Player player)
        {
            player.direction = (Main.MouseWorld.X - player.Center.X > 0) ? 1 : -1;
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<HugeRain>();
            {
                for (int i = -2; i < 2; i++)
                {
                    position = Main.MouseWorld + new Vector2(i * 20, -850);
                    Vector2 velocity = (Main.MouseWorld - position).SafeNormalize(Vector2.Zero).RotatedByRandom(0.05f) * item.shootSpeed;
                    Projectile.NewProjectile(position, velocity, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe.AddIngredient(ModContent.ItemType<OceanBar>(), 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}