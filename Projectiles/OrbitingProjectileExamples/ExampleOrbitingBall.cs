using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Projectiles;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Projectiles.OrbitingProjectileExamples
{
    public class ExampleOrbitingBall : OrbitingProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = false;
            projectile.width = 30;
            projectile.penetrate = 1;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.light = 1f;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.timeLeft = 60 * 60 * 3;
            ProjectileSlot = 1;
            Period = 300;
            PeriodFast = 100;
            ProjectileSpeed = 8;
            OrbitingRadius = 300;
            CurrentOrbitingRadius = 300;
        }
        public override void AI()
        {
            player = Main.player[projectile.owner];
            RelativeVelocity = player.velocity;
            OrbitCenter = player.Center;
            base.AI();
        }
        public override void Kill(int timeLeft)
        {
            if (Proj_State == 1 || Proj_State == 2)
            {
                GeneratePositionsAfterKill();
            }

            for (int i = 0; i < 30; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
			Main.PlaySound(SoundID.Dig, projectile.position);
			for (int i = 0; i < Main.rand.Next(3, 5); i++)
			{
				Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FragmentalShurikenProj>(), 40, 5f, projectile.owner);
			}

        }
        public override void Attack()
        {
            Vector2 ProjectileVelocity = Main.MouseWorld - projectile.Center;
            if (ProjectileVelocity != Vector2.Zero)
            {
                ProjectileVelocity.Normalize();
            }
            ProjectileVelocity *= 16;
            projectile.velocity = ProjectileVelocity;
            Proj_State = 5;
            //This method is responsible for correctly reordering the projetiles when one of them dies. We call this here to make sure the already fired projectiles do not count towards the current ones.
            GeneratePositionsAfterKill();
        }
    }
}