using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    public class MoonBlast : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.timeLeft = 2;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.alpha = 255;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 100; k++)
                Dust.NewDustPerfect(Projectile.Center, DustType<VortexDust>(), Vector2.One.RotatedByRandom(6.28f) * 5);
        }
    }
}
