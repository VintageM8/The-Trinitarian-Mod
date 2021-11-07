using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Ranged;

namespace Trinitarian.Subclasses.Elf
{
    public class ForestBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest's Bow");
            Tooltip.SetDefault("Fire's a spread of Forest Arrows");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.damage = 22;
            item.ranged = true;
            item.width = 48;
            item.height = 40;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.scale = 0.8f;
            item.noMelee = true;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item17;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = -8; i <= 8; i += 8)
            {
                Vector2 velocity = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(i));
                Projectile.NewProjectile(position, velocity, ModContent.ProjectileType<Elfarrow>(), damage / 4, 0f, player.whoAmI);
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}