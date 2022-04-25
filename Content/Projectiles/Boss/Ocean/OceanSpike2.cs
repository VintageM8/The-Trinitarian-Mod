using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Ocean
{
    class OceanSpike2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 360;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
        }
    }
}