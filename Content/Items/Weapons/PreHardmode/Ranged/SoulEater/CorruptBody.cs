using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater
{
    public class CorruptBody : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 85;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.alpha = Projectile.alpha + 3;
            if (Projectile.ai[0] == 1)
            {
                Projectile.alpha = 255;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
            else
            {
                Projectile.velocity.Y = 0;
                Projectile.velocity.X = 0;
            }
            if (Projectile.ai[0] == 2)
            {
                Projectile.alpha = 0;
            }
        }
    }
}