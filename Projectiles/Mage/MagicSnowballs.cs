using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class MagicSnowballs : ModProjectile
    {
        private float CircleArr = 1;
        private int PosCheck = 0;
        private int PosPlay = 0;

        private int OrignalDamage = 0;
        private int NumProj = 0;

        private bool charge = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowballs");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.netImportant = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 2;
        }


        public override void AI()
        {
            projectile.timeLeft = projectile.timeLeft + 1;
            projectile.rotation = (Main.MouseWorld - projectile.Center).ToRotation();
            projectile.tileCollide = false;

            if (Main.player[projectile.owner].channel && !charge)
            {

                NumProj = Main.player[projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<MagicSnowballs>()];
                PosCheck++;
                if (PosCheck == 1)
                {
                    PosPlay = NumProj;
                    OrignalDamage = projectile.damage;
                }


                if (PosCheck == 2)
                {
                    CircleArr = NumProj * 20;
                }

                if (PosCheck > 2)
                {
                    projectile.damage = OrignalDamage * NumProj;
                    double deg = (double)CircleArr; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                    double rad = deg * (Math.PI / 180); //Convert degrees to radian

                    projectile.position.X = 50 * (float)Math.Cos(rad) + Main.player[projectile.owner].Center.X - projectile.width / 2;
                    projectile.position.Y = 50 * (float)Math.Sin(rad) + Main.player[projectile.owner].Center.Y - projectile.height / 2;


                    CircleArr += 1.7f;
                }
            }
            else if (!charge)
            {
                if (PosCheck > 2)
                {
                    Vector2 position = projectile.Center;
                    Vector2 targetPosition = Main.MouseWorld + projectile.position - Main.player[projectile.owner].Center;
                    Vector2 direction = targetPosition - position;
                    direction.Normalize();
                    float speed = 11;
                    Main.PlaySound(SoundID.Item, projectile.position, 8);
                    charge = true;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, direction.X * speed, direction.Y * speed, ModContent.ProjectileType<ShotBall>(), projectile.damage, 0f, projectile.owner, 0f);
                }
                projectile.Kill();
            }

            if (PosPlay > 9 && PosCheck < 30)
            {
                projectile.Kill();
            }
        }
    }
}