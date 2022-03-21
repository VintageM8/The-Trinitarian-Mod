using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Boss.Zolzar
{
    public class LightningCrystal : ModProjectile
    {
         private bool canGrow = false;
        private int storeDamage;
        private Vector2 storeVelocity;
        private enum spawnDirection { left, right }
        private spawnDirection chooseDirection;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Crystal");
        }

        public override void SetDefaults()
        {
            projectile.width = 106;
            projectile.height = 124;
            projectile.penetrate = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 540;
            projectile.ignoreWater = true;
            projectile.scale = 1.33f;
        }

      
        public override void AI()
        {
            // Projectile special property initialization
            if (projectile.ai[0] == 0) // Store the initial damage value when first spawned, but make it deal no damage
            {
                storeDamage = projectile.damage;
                storeVelocity = projectile.velocity;
                projectile.damage = 0;
                projectile.velocity = Vector2.Zero;

                int direction = Main.rand.Next(2);

                if (direction == 0)
                {
                    chooseDirection = spawnDirection.left;
                }
                else
                {
                    chooseDirection = spawnDirection.right;
                }
            }
            projectile.ai[0]++;

            // Initial dust spawning to show where it is spawning
            if (!canGrow)
            {
                projectile.velocity = Vector2.Zero;
                projectile.alpha = 255;

                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 3f)
                {
                    // Change dust to green/brown
                    int randChoice = Main.rand.Next(2);
                    if (randChoice == 0)
                    {
                        int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Dirt, 0, 0, 0, default, 1.84f);
                        Main.dust[dust].noGravity = true;
                    }
                    else
                    {
                        int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Grass, 0, 0, 0, default, 1.84f);
                        Main.dust[dust].noGravity = true;
                    }
                }

                if (projectile.ai[0] % 180 == 0) // Spend 3 seconds doing nothing
                {
                    canGrow = true;
                    Main.PlaySound(new LegacySoundStyle(SoundID.Grass, 0)); // Grass
                }
            }
            else // Start spawning the projectile
            {
                projectile.damage = storeDamage;
                projectile.velocity = storeVelocity;
                projectile.alpha = 0;

                if (projectile.ai[0] >= 360) // Stop spawning the thorn body
                {
                    projectile.velocity = Vector2.Zero;
                }
            }

            if (projectile.timeLeft <= 60)
            {
                projectile.alpha += 5;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}