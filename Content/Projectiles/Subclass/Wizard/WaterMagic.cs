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
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 16;
            Projectile.aiStyle = 43;
            aiType = 227;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 54;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 4)
            {
                Projectile.frame = 0;
            }
            Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.025f) / 255f, ((255 - Projectile.alpha) * 0.25f) / 255f, ((255 - Projectile.alpha) * 0.05f) / 255f);
            Projectile.velocity.Y += Projectile.ai[0];
            var vector = Projectile.velocity * 1.08f;
            Projectile.velocity = vector;
        }
    }
}
