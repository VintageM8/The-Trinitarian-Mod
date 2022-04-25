using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class OceanWave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceanic Wave");
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Magic;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.width = 24;
            Item.height = 24;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<WaterScythe>();
            Item.shootSpeed = 24f;
            Item.mana = 24;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item8;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.knockBack = 2f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float rot = new Vector2(speedX, speedY).ToRotation();
            float rotOffset = MathHelper.PiOver2 / 5f;
            float speed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            for (int i = 0; i < 5; i++)
            {
                Vector2 velo = new Vector2(1f, 0f).RotatedBy(rot + (i - 2) * rotOffset);
                Projectile.NewProjectile(position + velo * 10f, velo, type, damage, knockBack, player.whoAmI, 0f, speed * 0.01f);
            }
            return false;
        }
    }
}