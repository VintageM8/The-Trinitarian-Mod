﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Boss.Zolzar
{
	public class LightBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Bolt");
		}

		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.width = 28;
			projectile.tileCollide = false;
			projectile.height = 28;
			projectile.timeLeft = 300;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);

			for (int num621 = 0; num621 < 15; num621++)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.UnusedWhiteBluePurple, 0f, 0f, 100, default, 2f);
			}
		}

		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			projectile.velocity.Y *= 1.01f;
			projectile.velocity.X *= 1.01f;

			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				projectile.tileCollide = false;
				projectile.ai[1] = 0f;
				projectile.alpha = 255;
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 30;
				projectile.height = 30;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				projectile.knockBack = 4f;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}