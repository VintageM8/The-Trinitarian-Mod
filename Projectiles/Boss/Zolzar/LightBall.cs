﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Boss.Zolzar;

namespace Trinitarian.Projectiles.Boss.Zolzar
{
	public class LightBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Ball");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = false;
			projectile.aiStyle = -1;
			projectile.timeLeft = 30;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}
		}

		public override Color? GetAlpha(Color lightColor) => Color.White;

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 14f, 0f, ModContent.ProjectileType<LightBlast>(), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -14f, 0f, ModContent.ProjectileType<LightBlast>(), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 14f, ModContent.ProjectileType<LightBlast>(), projectile.damage, 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, -14f, ModContent.ProjectileType<LightBlast>(), projectile.damage, 0f, projectile.owner, 0f, 0f);

			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 50;
			projectile.height = 50;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

			for (int num621 = 0; num621 < 20; num621++)
			{
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CopperCoin, 0f, 0f, 100, default, 2f);
				Main.dust[num622].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num622].scale = 0.5f;
					Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num623 = 0; num623 < 35; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CopperCoin, 0f, 0f, 100, default, 3f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 5f;
				num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CopperCoin, 0f, 0f, 100, default, 2f);
				Main.dust[num624].velocity *= 2f;
			}

			for (int num625 = 0; num625 < 3; num625++)
			{
				float scaleFactor10 = 0.33f;
				if (num625 == 1)
					scaleFactor10 = 0.66f;
				else if (num625 == 2)
					scaleFactor10 = 1f;

				int num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Main.gore[num626].velocity.X += 1f;
				Main.gore[num626].velocity.Y += 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Main.gore[num626].velocity.X -= 1f;
				Main.gore[num626].velocity.Y += 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Main.gore[num626].velocity.X += 1f;
				Main.gore[num626].velocity.Y -= 1f;
				num626 = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default, Main.rand.Next(61, 64), 1f);
				Main.gore[num626].velocity *= scaleFactor10;
				Main.gore[num626].velocity.X -= 1f;
				Main.gore[num626].velocity.Y -= 1f;
			}
		}

	}
}
