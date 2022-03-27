using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.BlueBlade;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.BlueBlade
{
    public class BlueBlade : ModItem
    {
        public bool NPCHit;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Star Blade");
        }

        public override void SetDefaults()
        {
            item.damage = 145;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 55, 0, 0);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileID.FlamingArrow;
            item.shootSpeed = 60f;
        }

        public override bool UseItem(Player player)
        {
            player.direction = (Main.MouseWorld.X - player.Center.X > 0) ? 1 : -1;
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<SunWrath>();
            {
                for (int i = -4; i < 4; i++)
                {
                    position = Main.MouseWorld + new Vector2(i * 20, -850);
                    Vector2 velocity = (Main.MouseWorld - position).SafeNormalize(Vector2.Zero).RotatedByRandom(0.05f) * item.shootSpeed;
                    Projectile.NewProjectile(position, velocity, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}