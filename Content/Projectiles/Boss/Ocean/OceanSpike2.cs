using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Boss.Ocean
{
    class OceanSpike2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 360;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
        }
    }
}