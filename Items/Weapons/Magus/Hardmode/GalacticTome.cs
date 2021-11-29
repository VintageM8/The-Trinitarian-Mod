using System;
using Trinitarian.Projectiles.Magus;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
	public class GalacticTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Galactic Tome");
			base.Tooltip.SetDefault("Casts an array of cosmic powers");
		}

		public override void SetDefaults()
		{
			item.damage = 95;
			item.width = 28;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5f;
			item.value = Item.buyPrice(1, 20);
			item.rare = 10;
			item.UseSound = SoundID.Item84;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<GalacticTomeProj>();
			item.shootSpeed = 16f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = 0.783f;
			double num2 = Math.Atan2(speedX, speedY) - (double)(num / 2f);
			double num3 = num / 8f;
			for (int i = 0; i < 4; i++)
			{
				double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
				Projectile.NewProjectile(position.X, position.Y, (float)(Math.Sin(num4) * 5.0), (float)(Math.Cos(num4) * 5.0), type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, (float)((0.0 - Math.Sin(num4)) * 5.0), (float)((0.0 - Math.Cos(num4)) * 5.0), type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}
	}
}