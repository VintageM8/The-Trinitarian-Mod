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
            item.damage = 24;
            item.magic = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.width = 24;
            item.height = 24;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.LightRed;
            item.shoot = ModContent.ProjectileType<WaterScythe>();
            item.shootSpeed = 24f;
            item.mana = 24;
            item.autoReuse = true;
            item.UseSound = SoundID.Item8;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.knockBack = 2f;
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