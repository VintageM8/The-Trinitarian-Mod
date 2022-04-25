using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class MechtideStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 54;
            item.magic = true;
            item.mana = 15;
            item.width = 70;
            item.height = 68;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 3, 80, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<MechtideStaffProj>();
            item.shootSpeed = 8f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 360; i += 90)
            {
                Vector2 SpawnPos = Main.MouseWorld + new Vector2(90).RotatedBy(MathHelper.ToRadians(i));
                Vector2 Velociry = Main.MouseWorld - SpawnPos;
                Velociry.Normalize();
                Projectile.NewProjectile(SpawnPos, Velociry * 5, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Mechtide>(), 18);
            recipe.AddIngredient(ItemType<TrueStarSteel>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}