using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.MushroomStaff
{
    public class MushroomStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Staff");
            Tooltip.SetDefault("Spews Mushrooms\nDon't eat them");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Blue;
            item.mana = 8;
            item.UseSound = SoundID.Item20;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 15;
            item.useTurn = false;
            item.useAnimation = 14;
            item.useTime = 14;
            item.width = 48;
            item.height = 46;
            item.shoot = ProjectileID.MoonlordTurretLaser;
            item.shootSpeed = 8f;
            item.knockBack = 3f;
            item.magic = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GlowingMushroom, 22);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Projectile.NewProjectile(player.Center.X + Main.rand.Next(-75, 76), player.Center.Y + Main.rand.Next(-75, 76), 0, 0, ProjectileID.TruffleSpore, item.damage, 3, player.whoAmI);
            }
            return true;
        }
    }
}