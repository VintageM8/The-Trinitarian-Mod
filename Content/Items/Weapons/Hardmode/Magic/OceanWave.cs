using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using Terraria.ModLoader;
using Terraria.DataStructures;

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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           float numberProjectiles = 6 + Main.rand.Next(6);
			float rotation = MathHelper.ToRadians(20);
			position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 2f, player.whoAmI);
			}
			return false;
		}
    }
}
