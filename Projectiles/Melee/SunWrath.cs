using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Melee
{
    public class SunWrath : ModProjectile
    {
        int i;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Wrath");
        }
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            drawOffsetX = -45;
            projectile.alpha = 255;
            drawOriginOffsetY = 0;
            projectile.damage = 65;
            drawOriginOffsetX = 23;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            i++;
            if (i % 1 == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width / 2, projectile.height / 2, 164);
            }
        }
    }
}