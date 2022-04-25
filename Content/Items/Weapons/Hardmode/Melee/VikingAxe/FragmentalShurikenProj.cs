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
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 0;
			Projectile.width = 75;
			Projectile.timeLeft = 600;
			Projectile.penetrate = 5;
			Projectile.height = 75;
			Projectile.friendly = true;
			Projectile.light = 0.75f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{ 
			target.AddBuff(BuffID.Confused, 120);
			target.AddBuff(BuffID.Ichor, 120);
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 50; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke);
			Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
			Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<FragmentalFragment>(), 273, 5f, Projectile.owner);
			perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
			Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<FragmentalFragment>(), 159, 5f, Projectile.owner);
			perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));

		}
		public override void AI()
		{
			Projectile.rotation += 0.5f;
			if (Projectile.alpha > 70)
			{
				Projectile.alpha -= 15;
				if (Projectile.alpha < 70)
				{
					Projectile.alpha = 70;
				}
			}
			if (Projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 200f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
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
				Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
				AdjustMagnitude(ref Projectile.velocity);
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