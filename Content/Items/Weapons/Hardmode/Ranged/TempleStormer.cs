using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged
{
    public class TempleStormer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temple Stormer");
            Tooltip.SetDefault("Converts bullets into RocketII\n Shoots a 3 round burst");
        }

        public override void SetDefaults()
        {
            Item.damage = 98;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 7;
            Item.useAnimation = 12;
            Item.reuseDelay = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 9f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.RocketII;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }
    }
}