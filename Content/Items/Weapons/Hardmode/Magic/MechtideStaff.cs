using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class MechtideStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 54;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 15;
            Item.width = 70;
            Item.height = 68;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 3, 80, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MechtideStaffProj>();
            Item.shootSpeed = 8f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 360; i += 90)
            {
                Vector2 SpawnPos = Main.MouseWorld + new Vector2(90).RotatedBy(MathHelper.ToRadians(i));
                Vector2 Velociry = Main.MouseWorld - SpawnPos;
                Velociry.Normalize();
                Projectile.NewProjectile(source, SpawnPos, Velociry * 5, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<Mechtide>(), 18)
                .AddIngredient(ItemType<TrueStarSteel>(), 15)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}