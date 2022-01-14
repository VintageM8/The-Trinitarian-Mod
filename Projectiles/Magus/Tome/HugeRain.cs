using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;

namespace Trinitarian.Projectiles.Magus.Tome
{
	public class HugeRain : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Huge Rain");
			Main.projFrames[base.projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 90;
		}

		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
			Main.PlaySound(SoundID.Dig, projectile.position);
			for (int i = 0; i < Main.rand.Next(1, 2); i++)
			{
				Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<WaterStormBottom>(), 40, 5f, projectile.owner);
			}

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 600);
		}
	}
}