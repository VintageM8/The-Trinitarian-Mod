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
            projectile.width = 14;
            projectile.height = 14;
            projectile.timeLeft = 100;
            projectile.penetrate = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            timer++;
            if (timer > 20)
            {
                projectile.tileCollide = true;
            }
        }
    }
}