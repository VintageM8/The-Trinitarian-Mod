using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Magus.Tome
{
	public class AbolethRage : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Aboleth Rage");
			Main.projFrames[base.projectile.type] = 3;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 26;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.magic = true;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 3;
			base.projectile.timeLeft = 90;
		}

		public override void AI()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 4)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame >= Main.projFrames[base.projectile.type])
			{
				base.projectile.frame = 0;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.25f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f);
			if (base.projectile.ai[0] > 7f)
			{
				float num = 1f;
				if (base.projectile.ai[0] == 8f)
				{
					num = 0.25f;
				}
				else if (base.projectile.ai[0] == 9f)
				{
					num = 0.5f;
				}
				else if (base.projectile.ai[0] == 10f)
				{
					num = 0.75f;
				}
				base.projectile.ai[0] += 1f;
				int type = 127;
				if (Main.rand.NextBool(3))
				{
					int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, type, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[num2];
					if (Main.rand.NextBool(3))
					{
						dust.noGravity = true;
						dust.scale *= 2f;
						dust.velocity.X *= 2f;
						dust.velocity.Y *= 2f;
					}
					else
					{
						dust.scale *= 1.5f;
					}
					dust.velocity.X *= 1.2f;
					dust.velocity.Y *= 1.2f;
					dust.scale *= num;
				}
			}
			else
			{
				base.projectile.ai[0] += 1f;
			}
			base.projectile.rotation = (float)Math.Atan2(base.projectile.velocity.Y, base.projectile.velocity.X) - (float)Math.PI / 2f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 600);
		}
	}
}