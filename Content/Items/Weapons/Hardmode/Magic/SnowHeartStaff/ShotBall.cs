using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.SnowHeartStaff
{
    public class ShotBall : ModProjectile
    {
        private int timer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Light");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.timeLeft = 100;
            Projectile.penetrate = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            timer++;
            if (timer > 20)
            {
                Projectile.tileCollide = true;
            }
        }
    }
}