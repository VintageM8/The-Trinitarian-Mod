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
            Item.damage = 145;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 55, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.FlamingArrow;
            Item.shootSpeed = 60f;
        }

        public override bool? UseItem(Player player)
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
                    Vector2 velocity = (Main.MouseWorld - position).SafeNormalize(Vector2.Zero).RotatedByRandom(0.05f) * Item.shootSpeed;
                    Projectile.NewProjectile(position, velocity, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.FragmentSolar, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}