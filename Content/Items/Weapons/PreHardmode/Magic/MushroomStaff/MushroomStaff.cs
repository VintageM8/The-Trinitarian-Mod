using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.mana = 8;
            Item.UseSound = SoundID.Item20;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 15;
            Item.useTurn = false;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.width = 48;
            Item.height = 46;
            Item.shoot = ProjectileID.MoonlordTurretLaser;
            Item.shootSpeed = 8f;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.GlowingMushroom, 22)
                .AddIngredient(ModContent.ItemType<SteelBar>(), 10)
                .AddIngredient(ItemID.Wood, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Projectile.NewProjectile(source, player.Center.X + Main.rand.Next(-75, 76), player.Center.Y + Main.rand.Next(-75, 76), 0, 0, ProjectileID.TruffleSpore, Item.damage, 3, player.whoAmI);
            }
            return true;
        }
    }
}