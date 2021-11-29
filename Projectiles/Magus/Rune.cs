using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Magus
{
    public class Rune : OrbitingProjectile
    {
        private float projectileRadius = 100;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune");
        }

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

            // Do stuff against friendly players
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (Main.player[i].active)
                {
                    float distance = Vector2.Distance(projectile.Center, Main.player[i].Center);
                    if (distance <= projectileRadius)
                    {
                        if (projectile.ai[1] % (int)MathHelper.Lerp(50, 10, projectile.ai[0] / 850) == 0)
                        {
                            Main.player[i].AddBuff(BuffID.Gills, 2800);
                        }
                    }
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Proj_State == 1 || Proj_State == 2)
            {
                GeneratePositionsAfterKill();
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

