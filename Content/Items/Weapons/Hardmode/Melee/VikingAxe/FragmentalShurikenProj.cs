using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe
{
	public class FragmentalShurikenProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 0;
			projectile.width = 75;
			projectile.timeLeft = 600;
			projectile.penetrate = 5;
			projectile.height = 75;
			projectile.friendly = true;
			projectile.light = 0.75f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{ 
			target.AddBuff(BuffID.Confused, 120);
			target.AddBuff(BuffID.Ichor, 120);
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 50; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
			Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<FragmentalFragment>(), 273, 5f, projectile.owner);
			perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<FragmentalFragment>(), 159, 5f, projectile.owner);
			perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));

		}
		public override void AI()
		{
			projectile.rotation += 0.5f;
			if (projectile.alpha > 70)
			{
				projectile.alpha -= 15;
				if (projectile.alpha < 70)
				{
					projectile.alpha = 70;
				}
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 200f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
		}
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 15f)
			{
				vector *= 15f / magnitude;
			}
		}
	}
}