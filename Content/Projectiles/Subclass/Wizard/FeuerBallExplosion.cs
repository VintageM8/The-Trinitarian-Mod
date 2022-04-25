using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    public class FeuerBallExplosion : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 128;
            projectile.height = 128;
            projectile.timeLeft = 2;
            projectile.penetrate = -1;
            projectile.friendly = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 100; k++)
                Dust.NewDustPerfect(projectile.Center, DustType<SolarDust>(), Vector2.One.RotatedByRandom(6.28f) * 5);
        }
    }
}
