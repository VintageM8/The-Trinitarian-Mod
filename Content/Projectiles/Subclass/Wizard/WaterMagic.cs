using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    public class WaterMagic : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Magic");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 16;
            projectile.aiStyle = 43;
            aiType = 227;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 54;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.frame = 0;
            }
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.025f) / 255f, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
            projectile.velocity.Y += projectile.ai[0];
            var vector = projectile.velocity * 1.08f;
            projectile.velocity = vector;
        }
    }
}
