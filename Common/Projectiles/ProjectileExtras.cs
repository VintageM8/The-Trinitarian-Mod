using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Common.Projectiles
{
	public delegate void ExtraAction();

	public static class ProjectileExtras
	{
		public static void Explode(int index, int sizeX, int sizeY, ExtraAction visualAction = null, bool weakerExplosion = false)
		{
			Projectile projectile = Main.projectile[index];
			if (!projectile.active)
				return;

			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = sizeX;
			projectile.height = sizeY;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			if (weakerExplosion)
			{
				projectile.damage = (int)(projectile.damage * .75f);
			}
			projectile.Damage();
			Main.projectileIdentity[projectile.owner, projectile.identity] = -1;
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = (int)((float)sizeX / 5.8f);
			projectile.height = (int)((float)sizeY / 5.8f);
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			if (visualAction == null)
			{
				for (int i = 0; i < 30; i++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num].velocity *= 1.4f;
				}
				for (int j = 0; j < 20; j++)
				{
					int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].velocity *= 7f;
					num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num2].velocity *= 3f;
				}
				for (int k = 0; k < 2; k++)
				{
					float scaleFactor = 0.4f;
					if (k == 1)
					{
						scaleFactor = 0.8f;
					}
					int num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore = Main.gore[num3];
					gore.velocity.X = gore.velocity.X + 1f;
					Gore gore2 = Main.gore[num3];
					gore2.velocity.Y = gore2.velocity.Y + 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore3 = Main.gore[num3];
					gore3.velocity.X = gore3.velocity.X - 1f;
					Gore gore4 = Main.gore[num3];
					gore4.velocity.Y = gore4.velocity.Y + 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore5 = Main.gore[num3];
					gore5.velocity.X = gore5.velocity.X + 1f;
					Gore gore6 = Main.gore[num3];
					gore6.velocity.Y = gore6.velocity.Y - 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore7 = Main.gore[num3];
					gore7.velocity.X = gore7.velocity.X - 1f;
					Gore gore8 = Main.gore[num3];
					gore8.velocity.Y = gore8.velocity.Y - 1f;
				}
				return;
			}
			visualAction();
		}
	}
}