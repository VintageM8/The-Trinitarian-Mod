﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Boss.Ocean
{
	public class DangerBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Danger Bubble");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.penetrate = 1;
			projectile.timeLeft = 80;
			projectile.height = 40;
			projectile.hostile = true;
            projectile.friendly = false;
			projectile.tileCollide = true;
        }
        int dust1 = 0;
		public override void AI()
		{
			if (projectile.ai[1] > 0f)
			{
				projectile.Center = Main.npc[(int)projectile.ai[0]].Center;
				projectile.ai[1] -= 1f;
				return;
			}
			Vector2 move = new Vector2(0f, 0f);
			float distance = 400f;
			Player target = null;
			for (int k = 0; k < 255; k++)
			{
				if (Main.player[k].active && !Main.player[k].dead)
				{
					Vector2 newMove = Main.player[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = Main.player[k];
					}
				}
			}
			if (target != null)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (5 * projectile.velocity + move) / 6f;
				AdjustMagnitude(ref projectile.velocity);
				if (projectile.Hitbox.Intersects(target.Hitbox))
				{
					target.immune = false;
					target.immuneTime = 0;
					projectile.Damage();
					if (!target.immune && target.immuneTime <= 0)
					{
						target.immune = true;
						target.immuneTime = 60;
					}
				}
			}
			for (int k2 = 0; k2 < 3; k2++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Water);
				Main.dust[dust].velocity /= 2f;
			}
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 7f)
			{
				vector *= 7f / magnitude;
			}
		}
	}
}