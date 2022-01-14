using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class Mushrooms : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushrooms");
        }

        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 20;
            projectile.aiStyle = 105;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.SporeTrap2;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Blood);
            }
            if (projectile.velocity != Vector2.Zero && projectile.velocity.LengthSquared() < 2)
            {
                projectile.velocity.Normalize();
                projectile.velocity *= 2;
            }
            //this is needed to make sure the projectile doesn't despawn when you don't have the spore sac
            projectile.ai[0] = 100;
        }
    }
}